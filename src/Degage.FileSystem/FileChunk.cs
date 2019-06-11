using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using Degage.FileSystem.Exceptions;
using System.Threading;


namespace Degage.FileSystem
{
    /// <summary>
    /// 表示多个文件的数据的集合
    /// </summary>
    public class FileChunk : IDisposable
    {
        /// <summary>
        /// 文件块环境
        /// </summary>
        public IFileChunkEnvironment Environment { get; private set; }
        /// <summary>
        /// 文件块的元数据信息
        /// </summary>
        public FileChunkMetadataInfo MetadataInfo { get; private set; }
        /// <summary>
        /// 文件块的存储项信息
        /// </summary>
        public FileChunkStorageInfo StorageInfo { get; private set; }
        /// <summary>
        /// 文件块当前状态的信息
        /// </summary>
        public FileChunkState StateInfo { get; private set; }
        /// <summary>
        /// 表示此文件块的全局唯一标识
        /// </summary>
        public String ChunkId { get; private set; }
        /// <summary>
        /// 文件块是否已完成加载
        /// </summary>
        public Boolean IsLoaded
        {
            get
            {
                return this._isLoaded != 0;
            }
        }
        public Boolean IsReading
        {
            get
            {
                return this._isReadingFlag != 0;
            }
        }
        /// <summary>
        /// 当前文件块是否正在执行项读取操作
        /// </summary>
        public Boolean IsWriting
        {
            get
            {
                return this._isWritingFlag != 0;
            }
        }
        /// <summary>
        /// 文件块对应的数据流
        /// </summary>
        private Stream _chunkFileStream;
        private Int32 _isLoaded = 0;
        private Object _syncObject = new Object();
        private Int32 _isReadingFlag = 0;
        private Int32 _isWritingFlag = 0;
        private Object _streamReadSync = new Object();
        private Object _streamWriteSync = new Object();


        /// <summary>
        /// 使用指定的块标识以及文件块环境，构造 <see cref="FileChunk"/> 实例
        /// </summary>
        /// <param name="chunkId">块标识</param>
        /// <param name="environment">文件块环境</param>
        public FileChunk(String chunkId, IFileChunkEnvironment environment)
        {
            this.ChunkId = chunkId;
            this.Environment = environment;
        }


        /// <summary>
        /// 使用当前为 <see cref="FileChunk"/> 实例分配的块标识以及文件块环境加载相关信息
        /// </summary>
        public void Load()
        {
            if (this.IsLoaded) return;
            lock (_syncObject)
            {
                if (this.IsLoaded) return;
                //[zh-cn]1:加载块的元数据信息通过文件块环境
                //[en-us]1:load file chunk metadatainfo by environment
                try
                {
                    FileChunkMetadataInfo metadataInfo = this.Environment.GetMetadataInfo(this.ChunkId);
                    if (metadataInfo == null)
                    {
                        throw new FileChunkMetadataLoadFailedException(this.ChunkId);
                    }
                    this.MetadataInfo = metadataInfo;
                }
                catch (Exception innerException)
                {
                    throw new FileChunkMetadataLoadFailedException(this.ChunkId, innerException);
                }

                //[zh-cn]2:加载文件块的数据流
                try
                {
                    var dataStream = this.Environment.LoadChunkDataStream(this.ChunkId);
                    if (dataStream == null)
                    {
                        throw new FileChunkDataStreamLoadFailed(this.ChunkId);
                    }
                    this._chunkFileStream = dataStream;
                }
                catch (Exception innerException)
                {
                    throw new FileChunkDataStreamLoadFailed(this.ChunkId, innerException);
                }


                //[zh-cn]3:加载块的存储项信息
                try
                {
                    FileChunkItemInfo[] itemInfos = this.Environment.LoadItemInfos(this.ChunkId);
                    FileChunkStorageInfo storageInfo = new FileChunkStorageInfo(itemInfos);
                    this.StorageInfo = storageInfo;
                }
                catch (Exception innerException)
                {
                    throw new FileChunkStorageItemLoadFailed(this.ChunkId, innerException);
                }


                Interlocked.Exchange(ref this._isLoaded, 1);
            }
        }




        /// <summary>
        /// <see cref="Load"/> 方法的异步版本
        /// </summary>
        public Task LoadAsync()
        {
            return Task.Run(() => this.Load());
        }

        public Stream ReadFileStream(String fileId)
        {
            if (!this.IsLoaded)
            {
                throw new FileChunkNotLoadException(this.ChunkId);
            }
            lock (this._streamReadSync)
            {
                Stream stream = null;
             //   ArrayPool<Byte>.Shared.Rent
                return stream;
            }
        }

        /// <summary>
        /// 实现 <see cref="IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            if (this.IsLoaded)
            {
                this._chunkFileStream.Dispose();
            }
        }
    }
}
