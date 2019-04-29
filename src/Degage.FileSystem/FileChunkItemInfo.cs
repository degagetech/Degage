using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Degage.FileSystem
{
    /// <summary>
    ///表示文件块中的一个存储项
    /// </summary>
    public class FileChunkItemInfo
    {
        /// <summary>
        /// 文件块项所表示的文件的 FileId
        /// </summary>
        public String FileId { get; internal set; }
        /// <summary>
        /// 文件块项存储的起始点，表示与块起始点的偏移量，单位：字节
        /// </summary>
        public UInt32 StartPoint { get; internal set; }

        /// <summary>
        /// 文件块项的原始大小
        /// </summary>
        public UInt32 Size { get; internal set; }

        /// <summary>
        ///文件块项压缩后的大小
        /// </summary>
        public UInt32 CompressedSize { get; internal set; }
        /// <summary>
        /// 文件块项当前的状态
        /// </summary>
        public FileChunkItemState State { get; internal set; }
        /// <summary>
        /// 文件块项数据存放时是否被压缩过，此标识会影响到数据的读取
        /// </summary>
        public Boolean IsCompressed { get; internal set; }
    }
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
