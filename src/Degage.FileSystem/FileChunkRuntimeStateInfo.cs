using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.FileSystem
{
    /// <summary>
    /// 记录文件块运行时的状态信息
    /// </summary>
    public class FileChunkRuntimeStateInfo
    {
        /// <summary>
        /// 表示当前在文件块上正在进行的读操作的计数
        /// </summary>
        public UInt32 ReadOperationCount { get;  set; }
        /// <summary>
        /// 表示当前在文件块上正在进行的写操作的计数
        /// </summary>
        public UInt32 WriteOperationCount { get;  set; }
        /// <summary>
        /// 文件块最后进行操作的时间戳
        /// </summary>
        public Int64 LastOperationTimestamp { get;  set; }
    }
   
}
