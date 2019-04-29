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
        private FileStream _chunkFileStream;

        public FileChunk(String path)
        {

        }

    }
}
