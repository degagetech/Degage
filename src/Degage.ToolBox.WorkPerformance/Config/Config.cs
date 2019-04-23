using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WorkPerformance
{
    public abstract class Config
    {
        /// <summary>
        /// 将配置中的各项属性设置为默认值
        /// </summary>
        public virtual void Default()
        {
        }
        /// <summary>
        /// 当配置从介质中加载后
        /// </summary>
        public virtual void OnLoaded()
        {
        }
        /// <summary>
        /// 配置文件保存到介质后
        /// </summary>
        public virtual void OnSaved()
        {
        }
        /// <summary>
        /// 配置文件保存到介质前
        /// </summary>
        public virtual void OnSaveing()
        {

        }
    }
    public static class Config<T> where T : Config, new()
    {
        /// <summary>
        /// 获取配置的实例
        /// </summary>
        public static T Current
        {
            get
            {
                return _Current;
            }
            private set
            {
                lock (_Sync)
                {
                    _Current = value;
                }
            }
        }
        private static T _Current;
        private static Object _Sync = new Object();

        /// <summary>
        /// 将指定类型的配置信息从文件加载到 <see cref="Config{T}.Current"/> 属性中
        /// </summary>
        public async static Task LoadAsync()
        {
            Type type = typeof(T);
            String configName = $"{type.Name}.config";
            T config = null;
            String path = configName;
            if (File.Exists(path))
            {
                await Task.Run(() =>
                 {
                     try
                     {
                         config = DataSerializer.Deserialize<T>(path);
                     }
                     catch
                     {
                         config = null;
                     }

                 });
            }
            if (config == null)
            {
                config = new T();
                config.Default();
            }
            config.OnLoaded();
            Config<T>.Current = config;
        }
        /// <summary>
        /// 将 <see cref="Config{T}.Current"/> 属性的值保存到本地介质中
        /// </summary>
        public static async Task SaveAsync()
        {
            Type type = typeof(T);
            String configName = $"{type.Name}.config";
            String configPath = configName;
            var config = Config<T>.Current;
            await Task.Run(() =>
             {
                 config.OnSaveing();
                 if (!File.Exists(configPath))
                 {
                     File.Create(configPath).Dispose();
                 }
                 DataSerializer.Serialize(Current, configPath);
                 config.OnSaved();
             });
        }


    }
}
