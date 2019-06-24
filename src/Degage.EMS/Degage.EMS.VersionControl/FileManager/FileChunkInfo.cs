using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Degage.EMS.VersionControl
{
    public class FileChunkInfo : IDisposable
    {
        public String ChunkId { get; internal set; }
        /// <summary>
        /// 末次访问时间
        /// </summary>
        public DateTime LastAccessTime { get; internal set; } = DateTime.Now;
        public Int32 AccessCount { get; internal set; }
        public String ChunkPath { get; internal set; }
        /// <summary>
        /// 预支长度，在项准备写入，但又尚未完成写入时，应将项长度增加到此属性上，写入完成后长度应从此属性中减去
        /// </summary>
        public Int64 AdvanceLength { get; internal set; }

        public Int64 Length
        {
            get
            {
                return this.ChunkOperator.Length;
            }
        }
        public IDictionary<String, FileChunkItemInfo> ChunItemTable { get; private set; }
        protected ZipAssistor ChunkOperator { get; private set; }
        private Boolean _isFlushing = false;
        private Object _syncObject = new Object();
        private Object _readSyncObject = new Object();
        public FileChunkInfo()
        {
            this.ChunItemTable = new Dictionary<String, FileChunkItemInfo>();
        }
        public FileChunkInfo(String chunkId, String chunkPath) : this()
        {
            this.ChunkId = chunkId;
            this.Load(chunkPath);
        }

        public void Load(String chunkPath)
        {
            this.ChunkOperator = ZipAssistor.OpenOrCreateZipArchive(chunkPath);
            this.ChunkPath = chunkPath;
            var zipItems = this.ChunkOperator.GetZipItems();

            foreach (var zipItem in zipItems)
            {
                FileChunkItemInfo chunkItem = new FileChunkItemInfo();
                chunkItem.ItemId = zipItem.Name;
                chunkItem.Length = zipItem.Length;
                this.AddChunkItemInfo(chunkItem);
            }
        }

        public void Flush()
        {
            this._isFlushing = true;
            try
            {
                this.ChunkOperator.Dispose();
                this.ChunkOperator = ZipAssistor.OpenOrCreateZipArchive(this.ChunkPath);
            }
            finally
            {
                this._isFlushing = false;
            }
        }
        private void AddChunkItemInfo(FileChunkItemInfo chunkItem)
        {
            this.ChunItemTable[chunkItem.ItemId] = chunkItem;
        }
        public FileChunkItemInfo GetChunkItemInfo(String itemId)
        {
            FileChunkItemInfo itemInfo = null;
            if (this.ChunItemTable.ContainsKey(itemId))
            {
                itemInfo = this.ChunItemTable[itemId];
            }
            return itemInfo;
        }
        public Boolean IsExistsItem(String itemId)
        {
            return this.ChunkOperator.IsExistsFile(itemId);
        }

        public Boolean AddChunkItem(String itemId, Stream dataStream)
        {
            FileChunkItemInfo itemInfo = new FileChunkItemInfo();
            itemInfo.ItemId = itemId;
            itemInfo.Length = dataStream.Length;
            this.AddChunkItemInfo(itemInfo);
            Boolean success = false;
            lock (_syncObject)
            {
                success = this.ChunkOperator.AddFileStream(dataStream, itemId);
                this.Flush();
            }
            return success;
        }

        public Stream CreateChunkItem(String itemId)
        {
            if (this._isFlushing)
            {
                this.WaitFlush();
            }
            FileChunkItemInfo itemInfo = new FileChunkItemInfo();
            itemInfo.ItemId = itemId;
            this.AddChunkItemInfo(itemInfo);
            return this.ChunkOperator.CreateFile(itemId);
        }

        /// <summary>
        /// 自旋以等待刷新完成
        /// </summary>
        private void WaitFlush()
        {
            while (this._isFlushing)
            {
                Thread.Sleep(10);
            }
        }
        public Stream GetChunkItem(String itemId)
        {
            if (this._isFlushing)
            {
                this.WaitFlush();
            }
            Stream stream = null;
            lock (_readSyncObject)
            {
                stream = this.ChunkOperator.GetFileStream(itemId);
                return stream;
            }
        }

        public Boolean DeleteChunkItem(String itemId)
        {
            return this.ChunkOperator.DeleteFile(itemId);
        }


        public void Dispose()
        {
            this.ChunkOperator?.Dispose();
        }
    }
}
