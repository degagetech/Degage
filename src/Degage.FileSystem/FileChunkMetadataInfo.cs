using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.FileSystem
{
    /// <summary>
    /// 存储 <see cref="FileChunk"/> 的元数据信息
    /// </summary>
    public class FileChunkMetadataInfo
    {
        public FileChunkMetadataInfo() { }
        /// <summary>
        /// 此元信息所属文件块的标识
        /// </summary>
        public String ChunkId { get; set; }
        /// <summary>
        /// 文件块的大小，单位：字节
        /// </summary>
        public UInt32 ChunkSize { get; set; }

        /// <summary>
        /// 文件块最后写入的数据的结束点，值表示为距离文件开始点的偏移量，单位：字节
        /// </summary>
        public UInt32 EndPoint { get; set; }

        /// <summary>
        /// 表示块当前 <see cref="EndPoint"/> 之后的空间的大小，单位：字节
        /// </summary>
        public UInt32 RemainingSpaceSize { get; set; }

        /// <summary>
        /// 块中包含的项的计数
        /// </summary>
        public UInt32 ItemCount { get; set; }

        /// <summary>
        /// 块的压缩过的次数
        /// </summary>
        public UInt32 CompressedCount { get; set; }

        /// <summary>
        /// 此元数据的时间戳
        /// </summary>
        public Int64 Timestamp { get; set; }

    }
}
