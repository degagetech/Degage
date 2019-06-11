using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
namespace Degage.FileSystem
{
    /// <summary>
    /// 提供一组与承载文件块环境交互的功能函数
    /// </summary>
    public interface IFileChunkEnvironment
    {
        /// <summary>
        /// 从此环境中读取包含指定块的存储项的数据流，此数据流只读
        /// </summary>
        Stream ReadChunkStorageItemStream(FileChunkItemInfo item);
        /// <summary>
        /// 从此环境中加载包含指定块的数据流
        /// </summary>
        /// <returns>若无返回 NULL</returns>
        Stream LoadChunkDataStream(String chunkId);
        /// <summary>
        /// 从此环境中通过指定的块标识获取文件块的元数据信息
        /// </summary>
        /// <param name="chunkId">文件块标识</param>
        /// <returns>若无返回 NULL</returns>
        FileChunkMetadataInfo GetMetadataInfo(String chunkId);
        /// <summary>
        /// 从此环境中通过指定的块标识加载块存储项信息集合
        /// </summary>
        /// <param name="chunkId">块标识</param>
        /// <returns>若无，0则返回一个元素个数为零的数组</returns>
        FileChunkItemInfo[] LoadItemInfos(String chunkId);

        /// <summary>
        /// 将指定的文件块的元数据信息添加或更新到此环境中
        /// </summary>
        /// <param name="info"><see cref="FileChunkMetadataInfo"/> 的实例</param>
        /// <returns>保存失败则返回 False，成功返回 True</returns>
        Boolean AddOrUpateMetadataInfo(FileChunkMetadataInfo info);
        /// <summary>
        /// 将指定的文件块的存储项信息添加或更新到此环境中
        /// </summary>
        /// <param name="info"><see cref="FileChunkItemInfo"/> 的实例</param>
        /// <returns>保存失败则返回 False，成功返回 True</returns>
        Boolean AddOrUpdateItemInfo(FileChunkItemInfo info);

    }
}
