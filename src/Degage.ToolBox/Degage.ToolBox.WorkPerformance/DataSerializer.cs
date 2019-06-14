using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;
namespace WorkPerformance
{
    public static class DataSerializer
    {
        /// <summary>
        /// 将对象序列化到文件中
        /// 而不是先现有文件追加
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="obj">被序列化的对象</param>
        /// <param name="file">文件路径</param>
        public static void Serialize<T>(T obj, String file) where T : class
        {
            using (FileStream stream = new FileStream(
                  file,
                  FileMode.Truncate, FileAccess.Write, FileShare.Read,
                  8096,
                  FileOptions.WriteThrough))
            {
                TextWriter writer = new StreamWriter(stream, Encoding.Default);
                var objStr = JsonConvert.SerializeObject(obj);
                writer.Write(objStr);
                writer.Flush();
            }
        }
        /// <summary>
        /// 从含有类结构信息的文件中反序列化出实例
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="file">文件路径</param>
        /// <returns>实例</returns>
        public static T Deserialize<T>(String file) where T : class
        {
            T obj = null;
            using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                TextReader reader = new StreamReader(stream, Encoding.Default);
                String objStr = reader.ReadToEnd();
                obj= JsonConvert.DeserializeObject<T>(objStr);
            }
            return obj;
        }
    }
}
