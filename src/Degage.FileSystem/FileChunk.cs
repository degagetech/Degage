using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
namespace Degage.FileSystem
{
    /// <summary>
    /// 表示多个文件的数据的集合
    /// </summary>
    public class FileChunk
    {
        /// <summary>
        /// 此文件块的元数据
        /// </summary>
        public FileChunkMetadataInfo MetadataInfo { get; private set; }
        /// <summary>
        /// 此文件块的存储项信息
        /// </summary>
        public FileChunkStorageInfo StorageInfo { get; private set; }
        /// <summary>
        /// 表示此文件块的全局唯一标识
        /// </summary>
        public String ChunkId { get; private set; }
        /// <summary>
        /// 文件块对应的文件实体的数据流
        /// </summary>
        private Stream _chunkDataStream;
        private String _chunkPath;

        /// <summary>
        /// 使用指定的块标识构造 <see cref="FileChunk"/> 的实例
        /// </summary>
        /// <param name="chunkId"></param>
        /// <param name="path"></param>
        public FileChunk(String chunkId)
        {
            this.ChunkId = chunkId;
        }

        /// <summary>
        ///从指定数据流中加载文件块的数据信息，注意此函数会将块的所有数据加载到内存中
        /// </summary>
        /// <param name="stream">包含块的数据的流</param>
        public void Load(Stream stream)
        {
            if (_chunkDataStream != null)
            {
                 
            }
        }


    }
}
