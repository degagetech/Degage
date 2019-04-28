using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace Degage.DataModel.Schema.Toolbox
{
    public static class SerializeAssistor
    {
        static JsonSerializerSettings _Settings;
        static SerializeAssistor()
        {
            _Settings = new JsonSerializerSettings();
            _Settings.NullValueHandling = NullValueHandling.Ignore;
            _Settings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
        }
        /// <summary>
        /// 将指定对象序列化为字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static String Serialize(Object obj,Type type)
        {
     
            return JsonConvert.SerializeObject(obj, type, _Settings);
        }
        public static Object Deserialize(String str,Type type) 
        {
            return JsonConvert.DeserializeObject(str, type, _Settings);
        }

    }
}
