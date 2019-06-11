using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.FileSystem
{
    /// <summary>
    /// 用于管理与维护文件块
    /// </summary>
    public class FileChunkManager
    {
        /// <summary>
        /// 表示文件块承载环境
        /// </summary>
        public IFileChunkEnvironment Environment { get; private set; }


    }
}
