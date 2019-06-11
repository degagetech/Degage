using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.FileSystem
{
    /// <summary>
    /// 文件块项的状态的集合
    /// </summary>
    public enum FileChunkItemState
    {
        /// <summary>
        /// 可用
        /// </summary>
        Available = 0,
        /// <summary>
        /// 已被删除，等待回收空间
        /// </summary>
        Deleted = 1,
        /// <summary>
        /// 文件项占用的空间已被回收
        /// </summary>
        Released = 2
    }
}
