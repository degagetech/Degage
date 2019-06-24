using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Degage.Extension;
namespace Degage.EMS.VersionControl
{
    /// <summary>
    /// 提供将对象 Json 序列化与反序列化的能力
    /// </summary>
    public  static partial class JsonSerializer
    {
        public static void LoadWriterSetting(this Newtonsoft.Json.JsonWriter writer)
        {
            writer.Formatting = Formatting.None;
        }
        public static Newtonsoft.Json.JsonSerializer CreateSerializer()
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
             serializer.NullValueHandling = JsonSerializer.NullValueHandling;
            serializer.DateFormatString = TimeAssistor.SystemTimeStringFormat;
            return serializer;
        }
        public static JsonSerializerSettings _Settings = null;

        public static NullValueHandling NullValueHandling { get; private set; } = NullValueHandling.Ignore;
        public static String DateFormatString { get; private set; } = TimeAssistor.SystemTimeStringFormat;

        static JsonSerializer()
        {

            _Settings = new JsonSerializerSettings();
         //   _Settings.NullValueHandling = JsonSerializer.NullValueHandling;
            _Settings.DateFormatString = JsonSerializer.DateFormatString;
        }
        /// <summary>
        /// 将Json字符串反序列化为对象，注意当字符串为空时，总是返回 default(T)
        /// </summary>
        /// <returns></returns>
        public static T Deserialize<T>(String str, Boolean useSetting = true)
        {
            if (str.IsNullOrEmpty())
            {
                return default(T);
            }
            if (useSetting)
                return JsonConvert.DeserializeObject<T>(str, _Settings);
            else
                return JsonConvert.DeserializeObject<T>(str);
        }
        public static Object Deserialize(String str, Type type, Boolean useSetting = true)
        {
            if (str.IsNullOrEmpty())
            {
                return null;
            }
            if (useSetting)
                return JsonConvert.DeserializeObject(str, type, _Settings);
            else
                return JsonConvert.DeserializeObject(str, type);
        }
        /// <summary>
        /// 将指定对象Json序列化成字符串，当对象为空时返回空引用
        /// </summary>
        public static String Serialize(Object obj, Boolean useSetting = true)
        {
            String result = null;
            if (obj == null)
            {
                return result;
            }
            if (useSetting)
                result = JsonConvert.SerializeObject(obj, _Settings);
            else
                result = JsonConvert.SerializeObject(obj);
            return result;
        }
        public static String Serialize(Object obj, Type type)
        {
            String result = null;
            if (obj == null)
            {
                return result;
            }
            result = JsonConvert.SerializeObject(obj, type, _Settings);
            return result;
        }
    }
}
