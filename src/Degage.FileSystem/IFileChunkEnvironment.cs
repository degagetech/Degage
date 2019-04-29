using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.FileSystem
{
    /// <summary>
    /// 表示承载文件块相关信息的环境
    /// </summary>
    public interface IFileChunkEnvironment
    {
        /// <summary>
        /// 通过指定的块标识获取文件块的元数据信息
        /// </summary>
        /// <param name="chunkId"></param>
        /// <returns></returns>
        FileChunkMetadataInfo GetChunkMetadataInfo(String chunkId);
        /// <summary>
        /// 通过指定的块标识获取文件块的存储信息
        /// </summary>
        FileChunkStorageInfo GetChunkStorageInfo(String chunkId);

        Boolean UpdateChunkMetadataInfo(FileChunkMetadataInfo info);

        Boolean UpdateChunkStorageInfo(FileChunkStorageInfo info);
    }
}
