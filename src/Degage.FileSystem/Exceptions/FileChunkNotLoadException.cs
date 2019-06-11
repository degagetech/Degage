using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.FileSystem.Exceptions
{
    /// <summary>
    /// 表示使用未完成加载的 <see cref="FileChunk"/> 实例时触发的异常
    /// </summary>
    public class FileChunkNotLoadException : Exception
    {
        /// <summary>
        /// 未完成加载的文件块的标识
        /// </summary>
        public String ChunkId { get; private set; }
        /// <summary>
        /// 使用指定的 ChunkId 构造 <see cref="FileChunkNotLoadException"/> 实例
        /// </summary>
        /// <param name="chunkId"></param>
        public FileChunkNotLoadException(String chunkId, Exception innerException = null) : base("文件块尚未完成加载！", innerException)
        {
            this.ChunkId = chunkId;
        }
    }
}
