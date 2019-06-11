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
        /// 表示此存储项所属的文件块
        /// </summary>
        public String ChunkId { get;  set; }
        /// <summary>
        /// 文件块项所表示的文件的 FileId
        /// </summary>
        public String FileId { get;  set; }
        /// <summary>
        /// 文件块项存储的起始点，表示与块起始点的偏移量，单位：字节
        /// </summary>
        public UInt32 StartPoint { get;  set; }

        /// <summary>
        /// 文件块项的原始大小
        /// </summary>
        public UInt32 Size { get;  set; }

        /// <summary>
        ///文件块项压缩后的大小
        /// </summary>
        public UInt32 CompressedSize { get;  set; }
        /// <summary>
        /// 文件块项当前的状态
        /// </summary>
        public FileChunkItemState State { get;  set; }
        /// <summary>
        /// 文件块项数据存放时是否被压缩过，此标识会影响到数据的读取
        /// </summary>
        public Boolean IsCompressed { get;  set; }
    }
  

}
