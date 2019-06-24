using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
namespace Degage.EMS.VersionControl
{
    /// <summary>
    /// 提供对 ZIP 文档的操作能力
    /// </summary>
    public class ZipAssistor : IDisposable
    {
        /// <summary>
        /// 通过指定的路径打开或创建一个 ZIP 文档，并返回与此文档关联的 <see cref="ZipAssistor"/> 对象
        /// </summary>
        /// <param name="path">ZIP 文档的路径</param>
        /// <returns></returns>
        public static ZipAssistor OpenOrCreateZipArchive(String path)
        {
            FileStream stream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            ZipAssistor assistor = new ZipAssistor(stream);
            return assistor;
        }

        public Int64 Length
        {
            get
            {
                return this._stream.Length;
            }
        }

        private ZipArchive _archive;
        private Stream _stream;
        /// <summary>
        /// 通过指定的压缩文档的数据流初始化 <see cref="ZipAssistor"/> 对象
        /// </summary>
        /// <param name="zipStream"></param>
        public ZipAssistor(Stream zipStream)
        {
            ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Update);
            this._archive = archive;
            this._stream = zipStream;
        }

        /// <summary>
        /// 使用指定的数据流向压缩文档中添加项，并指定项所表示的文件的名称以及其所属目录
        /// </summary>
        /// <param name="fileStream">数据流</param>
        /// <param name="fileName">文件名称</param>
        /// <param name="directory">所属目录，可空</param>
        /// <returns></returns>
        public Boolean AddFileStream(Stream fileStream, String fileName, String directory = null)
        {
            String entryName = this.GetEntryName(fileName, directory);
            var zipEntry = this._archive.CreateEntry(entryName);
            using (var entryStream = zipEntry.Open())
            {
                fileStream.CopyTo(entryStream);
            }
            return true;
        }
        public Stream CreateFile(String fileName, String directory = null)
        {
            String entryName = this.GetEntryName(fileName, directory);
            var zipEntry = this._archive.CreateEntry(entryName);
            return zipEntry.Open();
        }
        public List<ZipItem> GetZipItems()
        {
            List<ZipItem> zipItems = new List<ZipItem>();
            var entries = this._archive.Entries;
            foreach (var entry in entries)
            {
                ZipItem item = new ZipItem();
                item.FullName = entry.FullName;
                item.Name = entry.Name;
                item.Length = entry.Length;
                zipItems.Add(item);
            }
            return zipItems;

        }
        /// <summary>
        /// 判断当前压缩文档中是否存在指定名称的压缩文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="directory">文件所属目录，可空</param>
        /// <returns></returns>
        public Boolean IsExistsFile(String fileName, String directory = null)
        {
            String entryName = this.GetEntryName(fileName, directory);
            var entry = this._archive.GetEntry(entryName);
            return entry != null;
        }
        /// <summary>
        /// 通过文件名称以及所属目录获取其在文档的项的名称
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="directory">所属目录，可空</param>
        /// <returns></returns>
        private String GetEntryName(String fileName, String directory = null)
        {
            String entryName = fileName;
            if (directory != null)
            {
                if (!directory.EndsWith('/'))
                {
                    directory += '/';
                }
                entryName = directory + fileName;
            }
            return entryName;
        }
        public Boolean DeleteFile(String fileName, String directory = null)
        {
            String entryName = this.GetEntryName(fileName, directory);
            var entry = this._archive.GetEntry(entryName);
            if (entry != null)
            {
                entry.Delete();
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取压缩文档中指定文件名称所表示的压缩项的数据流，若无此项，此返回空
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="directory">文件所属目录，可空</param>
        /// <returns></returns>
        public Stream GetFileStream(String fileName, String directory = null)
        {
            String entryName = this.GetEntryName(fileName, directory);
            var entry = this._archive.GetEntry(entryName);
            if (entry != null)
            {
                return entry.Open();
            }
            return null;
        }

        /// <summary>
        /// 通过文档中的项信息获取其对应的数据流
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Stream GetItemStream(ZipItem item)
        {
            var entry = this._archive.GetEntry(item.FullName);
            if (entry != null)
            {
                return entry.Open();
            }
            return null;
        }

        /// <summary>
        /// 继承并实现 <see cref="IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            this._archive?.Dispose();
        }


    }
    /// <summary>
    /// 表示压缩文档中的项
    /// </summary>
    public class ZipItem
    {
        public String FullName { get; set; }
        public String Name { get; set; }
        public Int64 Length { get; set; }
    }
}
