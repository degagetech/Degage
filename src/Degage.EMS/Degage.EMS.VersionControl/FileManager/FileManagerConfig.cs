using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.EMS.VersionControl
{
    /// <summary>
    /// 文件管理配置
    /// </summary>
    public class FileManagerConfig
    {
        /// <summary>
        /// 文件存放的根目录
        /// </summary>
        public String RootDirectory { get; set; } = "Files";
        /// <summary>
        /// Chunk 块的最大大小，单位： MB
        /// </summary>
        public Int32 ChunkMaxSize { get; set; } = 100;

        /// <summary>
        /// 允许同时存在在内存中的块缓存最大数量
        /// </summary>
        public Int32 ChunkCacheMaxCount { get; set; } = 100;
        public static FileManagerConfig Load(String path)
        {
            String text = File.ReadAllText(path);
            return JsonSerializer.Deserialize<FileManagerConfig>(text);
        }
    }
}
