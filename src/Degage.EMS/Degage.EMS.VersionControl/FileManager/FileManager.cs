using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using System.Threading;
using System.Timers;
using Degage.Extension;
namespace Degage.EMS.VersionControl
{

    using Timer = System.Timers.Timer;

    /// <summary>
    /// 存取与管理文件
    /// </summary>
    public class FileManager : IDisposable
    {
        public FileManagerConfig Config { get; private set; }
        public IDictionary<String, FileChunkInfo> FileChunkCache { get; private set; } = new Dictionary<String, FileChunkInfo>();
        public FileChunkInfo CurrentChunk { get; private set; }
        private Char Hyphens { get; set; } = '-';
        /// <summary>
        /// 表示 Chunk 块文件的后缀名，带 .
        /// </summary>
        private String ChunkFileExt { get; set; } = ".chunk";
        private Object ChunkSyncObject { get; set; } = new Object();
        /// <summary>
        /// 用于及时回收长期未被使用的块缓存
        /// </summary>
        private Timer ChunkCacheCollector { get; set; }
        public FileManager(FileManagerConfig config)
        {
            this.Config = config;
            var rootDirectory = config.RootDirectory;
            if (!Path.IsPathFullyQualified(config.RootDirectory))
            {
                rootDirectory = Path.Combine(AppContext.BaseDirectory, rootDirectory);
            }
            this.Config.RootDirectory = rootDirectory;
            //每15秒回收一次
            this.ChunkCacheCollector = new Timer(15000);
            this.ChunkCacheCollector.Elapsed += ChunkCacheCollector_Elapsed;

            if (!Directory.Exists(this.Config.RootDirectory))
            {
                Directory.CreateDirectory(this.Config.RootDirectory);
            }


        }


        public void Load()
        {
            //加载一些初始块
            //1.块空间未占用满的
            //2.最后访问时间较近的
            //3.最大加载数为 Config.ChunkCacheMaxSize 的 1/3 
            var directoryInfo = new DirectoryInfo(this.Config.RootDirectory);
            var fileInfos = directoryInfo.GetFiles("*" + this.ChunkFileExt).OrderBy(t => t.LastAccessTime);
            Int32 maxCount = this.Config.ChunkCacheMaxCount / 3;
            Int32 count = 0;
            if (fileInfos.Any())
            {
                foreach (var file in fileInfos)
                {
                    if (count >= maxCount) break;
                    if (file.Length < this.Config.ChunkMaxSize * 1024 * 1024)
                    {
                        var chunId = Path.GetFileNameWithoutExtension(file.Name);
                        this.LoadChunk(chunId);
                        count++;
                    }
                }
            }


        }

        private void ChunkCacheCollector_Elapsed(Object sender, ElapsedEventArgs e)
        {
            this.ChunkCacheCollector.Enabled = false;
            try
            {
                this.ChunkCacheGC(this);
            }
            finally
            {
                this.ChunkCacheCollector.Enabled = true;
            }

        }

        /// <summary>
        /// 执行一次块缓存回收操作
        /// </summary>
        /// <param name="state"></param>
        private void ChunkCacheGC(Object state)
        {
            //当块缓存的数量大于最大缓存数量的 2/3 时，则考虑回收部分块
            if (this.FileChunkCache.Count < (this.Config.ChunkCacheMaxCount * 2 / 3))
            {
                return;
            }
            //留下  20% 的热点访问块
            //最近 5 分钟内访问过的块，不参与回收
            var time = DateTime.Now.Subtract(new TimeSpan(0, 5, 0));
            var fileChunkCaches = this.FileChunkCache.Values.Where(t => t.LastAccessTime < time).ToList();
            //如果所有块都在短期内被访问过，则表示缓存的设置无法满足此服务器的负载
            if (fileChunkCaches.Count == 0)
            {
                //TODO:如何合理的动态调整缓存大小
                return;
            }

            //尝试释放相关块
            foreach (var chunk in fileChunkCaches)
            {
                //放在循环内避免长时间占用
                lock (this.ChunkSyncObject)
                {
                    chunk.Dispose();
                    this.RemoveChunk(chunk.ChunkId);
                }
            }
        }
        private Boolean RemoveChunk(String chunkId)
        {
            return this.FileChunkCache.Remove(chunkId);
        }
        /// <summary>
        /// 尝试加载指定标识的块信息，此函数首先尝试从内存中加载，若无则从存储介质中加载，若块不存在则新建
        /// </summary>
        /// <param name="chunkId"></param>
        /// <returns></returns>
        public FileChunkInfo LoadChunk(String chunkId)
        {
            if (this.IsExistedChunkCache(chunkId))
            {
                return this.GetChunkFromCache(chunkId);
            }
            lock (this.ChunkSyncObject)
            {
                if (this.IsExistedChunkCache(chunkId))
                {
                    return this.GetChunkFromCache(chunkId);
                }
                String chunkPath = this.GetChunkPath(chunkId);
                FileChunkInfo chunkInfo = new FileChunkInfo(chunkId, chunkPath);
                this.AddChunkCache(chunkInfo);
                return chunkInfo;
            }
        }
        private void RefreshStatus(FileChunkInfo chunk)
        {
            chunk.LastAccessTime = DateTime.Now;
            chunk.AccessCount++;
        }
        private FileChunkInfo GetChunkFromCache(String chunkId)
        {
            if (this.FileChunkCache.ContainsKey(chunkId))
            {
                var chunk = this.FileChunkCache[chunkId];
                this.RefreshStatus(chunk);
                return this.FileChunkCache[chunkId];
            }
            return null;
        }
        private Boolean IsExistedChunkCache(String chunkId)
        {
            return this.FileChunkCache.ContainsKey(chunkId);
        }
        private void AddChunkCache(FileChunkInfo chunkInfo)
        {
            this.RefreshStatus(chunkInfo);
            this.FileChunkCache[chunkInfo.ChunkId] = chunkInfo;
        }

        private String GetChunkPath(String chunkId)
        {
            String chunkPath = Path.Combine(this.Config.RootDirectory, chunkId + this.ChunkFileExt);
            return chunkPath;
        }
        public Boolean IsExistedChunk(String chunkId)
        {
            if (this.FileChunkCache.ContainsKey(chunkId))
            {
                return true;
            }
            String chunkPath = this.GetChunkPath(chunkId);
            return File.Exists(chunkPath);
        }

        private (String chunkId, String itemId) GetFilePosition(String fileId)
        {
            String chunkId = null;
            String itemId = null;
            var result = fileId.Split(this.Hyphens);
            if (result.Length == 2)
            {
                chunkId = result[0];
                itemId = result[1];
            }
            return (chunkId, itemId);
        }

        public String CreateChunkId()
        {
            return DateTime.Now.Ticks.ToString();
        }

        public String CreateChunkItemId(String fileName)
        {
            String ext = Path.GetExtension(fileName);
            return DateTime.Now.Ticks.ToString() + ext;
        }

        public String CreateFileId(String chunkId, String fileName)
        {
            var chunkItemId = this.CreateChunkItemId(fileName);
            return this.BuildFileId(chunkId, chunkItemId);
        }
        public String BuildFileId(String chunkId, String chunkItemId)
        {
            return chunkId + this.Hyphens + chunkItemId;
        }


        public Boolean IsValidFileId(String fileId)
        {
            if (fileId.IsNullOrWhiteSpace())
            {
                return false;
            }
            var position = this.GetFilePosition(fileId);
            if (position.chunkId.IsNullOrWhiteSpace())
            {
                return false;
            }
            if (position.itemId.IsNullOrWhiteSpace())
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 获取当前已加载的可用的块，若无则返回空
        /// </summary>
        /// <returns></returns>
        public FileChunkInfo GetUsableChunk()
        {
            //首先从已加载的块中尝试获取
            var chunks = this.FileChunkCache.Values.Where(t => t.Length < this.Config.ChunkMaxSize * 1024 * 1024).OrderBy(t => t.Length);
            if (chunks.Any())
            {
                var chunk = chunks.First();
                this.RefreshStatus(chunk);
                return chunk;
            }
            return null;
        }
        private String GetChunkId(String chunkPath)
        {
            var chunkId = Path.GetFileNameWithoutExtension(chunkPath);
            return chunkId;
        }

        /// <summary>
        /// 使用指定的文件标识，向块中添加项
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="itemStream"></param>
        /// <returns></returns>
        public Boolean AddChunkItem(String fileId, Stream itemStream)
        {
            var position = this.GetFilePosition(fileId);
            var chunk = this.LoadChunk(position.chunkId);
            if (chunk == null)
            {
                return false;
            }
            return chunk.AddChunkItem(position.itemId, itemStream);
        }

        public Stream CreateChunkItem(String fileId)
        {
            Stream stream = null;
            var position = this.GetFilePosition(fileId);
            var chunk = this.LoadChunk(position.chunkId);
            if (chunk == null)
            {
                return stream;
            }
            stream = chunk.CreateChunkItem(position.itemId);
            return stream;
        }

        public Boolean DeleteFile(String fileId)
        {
            var position = this.GetFilePosition(fileId);
            var chunk = this.LoadChunk(position.chunkId);
            if (chunk == null)
            {
                return false;
            }
            return chunk.DeleteChunkItem(position.itemId);
        }

        public Task<Boolean> DeleteFileAsync(String fileId)
        {
            return Task.FromResult(this.DeleteFile(fileId));
        }
        /// <summary>
        /// 添加新的文件，若失败返回空
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public String AddFile(String fileName, Stream fileStream)
        {
            var chunk = this.GetUsableChunk();
            if (chunk == null)
            {
                lock (this.ChunkSyncObject)
                {
                    chunk = this.GetUsableChunk();
                    if (chunk == null)
                    {
                        var chunkId = this.CreateChunkId();
                        chunk = this.LoadChunk(chunkId);
                    }
                }
            }
            var itemId = this.CreateChunkItemId(fileName);
            if (chunk.AddChunkItem(itemId, fileStream))
            {
                return this.BuildFileId(chunk.ChunkId, itemId);
            }
            return null;
        }

        /// <summary>
        /// <see cref="AddFile(String, Stream)"/> 的异步版本
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="fileStream"></param>
        /// <returns></returns>
        public Task<String> AddFileAsync(String fileName, Stream fileStream)
        {
            return Task.FromResult(this.AddFile(fileName, fileStream));
        }
        /// <summary>
        /// 获取指定标识的文件的数据流，若无返回空
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public Stream GetFileStream(String fileId)
        {
            Stream stream = null;
            var position = this.GetFilePosition(fileId);
            var chunk = this.LoadChunk(position.chunkId);
            stream = chunk.GetChunkItem(position.itemId);
            return stream;
        }

        /// <summary>
        /// <see cref="GetFileStream(String)"/> 的异步版本
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public Task<Stream> GetFileStreamAsync(String fileId)
        {
            return Task.FromResult(this.GetFileStream(fileId));
        }

        /// <summary>
        /// 判断指定标识的文件是否存在
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public Boolean IsExistsFile(String fileId)
        {
            var position = this.GetFilePosition(fileId);
            //首先判断块存在与否
            if (!this.IsExistedChunk(position.chunkId))
            {
                return false;
            }

            var chunk = this.LoadChunk(position.chunkId);
            return chunk.IsExistsItem(position.itemId);
        }

        /// <summary>
        /// <see cref="IsExistsFile(string)"/> 的异步版本
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public Task<Boolean> IsExistsFileAsync(String fileId)
        {
            return Task.FromResult(this.IsExistsFile(fileId));
        }

        /// <summary>
        /// 通过此标识以避免重复释放
        /// </summary>
        private Boolean _isDisposing = false;

        public void Dispose()
        {
            var chunkCache = this.FileChunkCache;
            if (!this._isDisposing && chunkCache.Count > 0)
            {
                this._isDisposing = true;
                var caches = chunkCache.Values.ToList();
                foreach (var chunk in caches)
                {
                    chunk.Dispose();
                    this.RemoveChunk(chunk.ChunkId);
                }
            }
        }
    }
}
