using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
namespace Degage.FileSystem
{
    /// <summary>
    /// 维护与管理文件块中的文件存储项
    /// </summary>
    /// <remarks>此类保证所有公开实例方法都是线程安全的</remarks>
    public class FileChunkStorageInfo
    {
        /// <summary>
        /// 存储项的数目
        /// </summary>
        public Int32 Count
        {
            get
            {
                return this._chunkItemTable.Count;
            }
        }

        private ConcurrentDictionary<String, FileChunkItemInfo> _chunkItemTable;

        /// <summary>
        /// 使用默认的构造函数构建一个 <see cref="FileChunkStorageInfo"/> 实例
        /// </summary>
        public FileChunkStorageInfo()
        {
            this._chunkItemTable = new ConcurrentDictionary<String, FileChunkItemInfo>();
        }

        public FileChunkStorageInfo(IEnumerable<FileChunkItemInfo> itemInfos) : this()
        {
            foreach (var item in itemInfos)
            {
                this._chunkItemTable.TryAdd(item.FileId, item);
            }
        }


        /// <summary>
        /// 添加指定的 FileId 以及其关联的文件项信息，若存在则使用新的值更新
        /// </summary>
        public void AddOrUpdateChunkItemInfo(String fileId, FileChunkItemInfo info)
        {
            this._chunkItemTable.AddOrUpdate(fileId, info, (s, o) => info);
        }

        /// <summary>
        /// 获取与指定 FileId 关联的 <see cref="FileChunkItemInfo"/> 信息，若无则返回 NULL
        /// </summary>
        public FileChunkItemInfo GetChunkItemInfo(String fileId)
        {
            if (this._chunkItemTable.TryGetValue(fileId, out var item))
            {
                return item;
            }
            else
            {
                return null;
            }
        }
    }
}
