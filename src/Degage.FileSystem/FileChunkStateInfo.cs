using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.FileSystem
{
    /// <summary>
    /// 记录文件运行时的状态信息
    /// </summary>
    public class FileChunkStateInfo
    {
        /// <summary>
        /// 表示当前在文件块上正在进行的读操作的计数
        /// </summary>
        public UInt32 ReadOperationCount { get; internal set; }
        /// <summary>
        /// 表示当前在文件块上正在进行的写操作的计数
        /// </summary>
        public UInt32 WriteOperationCount { get; internal set; }
        /// <summary>
        /// 文件块最后进行操作的时间戳
        /// </summary>
        public Int64 LastOperationTimestamp { get; internal set; }
    }
    /// <summary>
    /// 文件块状态的常量的集合
    /// </summary>
    public enum FileChunkState
    {
        /// <summary>
        /// 文件块已创建
        /// </summary>
        Created = 0,
        /// <summary>
        /// 文件块已创建并且已在存储介质上分配空间
        /// </summary>
        Allocated = 1,
        /// <summary>
        /// 文件块已被删除
        /// </summary>
        Deleted = 2,
        /// <summary>
        /// 文件块占用空间已被释放
        /// </summary>
        Released = 3
    }
}
