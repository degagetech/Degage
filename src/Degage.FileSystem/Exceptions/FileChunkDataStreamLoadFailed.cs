using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.FileSystem.Exceptions
{
    public class FileChunkDataStreamLoadFailed : Exception
    {
        /// <summary>
        /// 加载失败的文件块的标识
        /// </summary>
        public String ChunkId { get; private set; }

        /// <summary>
        /// 使用指定的 ChunkId 构造 <see cref="FileChunkDataStreamLoadFailed"/> 实例
        /// </summary>
        /// <param name="chunkId"></param>
        public FileChunkDataStreamLoadFailed(String chunkId,Exception innerException=null) : base("文件块数据流加载失败！", innerException)
        {
            this.ChunkId = chunkId;
        }
    }
}
