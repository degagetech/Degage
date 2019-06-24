using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;

namespace Degage.DataModel.Schema.Toolbox
{
    public class ConfigManager
    {
        /// <summary>
        /// 表示当前配置系统是否处于UI设计的状态
        /// </summary>
        public static Boolean IsUIDesign { get; set; }

        static Encoding _DefaultEncodeing;
        static ConfigManager()
        {
            _DefaultEncodeing = UTF8Encoding.UTF8;
        }
        public static void LoadConfigToObject(Object obj, Type type, String filePath, Boolean isEncrypted = false)
        {
            Object target = null;

            var text = File.ReadAllText(filePath, _DefaultEncodeing);
            if (isEncrypted)
            {
                text = DefaultStringEncryptor.Decrypt(text);
            }
            target = SerializeAssistor.Deserialize(text, type);

            var propertyInfos = TypeInfoProvider.GetProperties(type);

            foreach (var prop in propertyInfos)
            {
                ConfigLoadPropertyAnalysis(target, prop);
            }
            CopyConfigObject(target, obj, type);
        }
        private static void CopyConfigObject(Object source, Object dest, Type type)
        {
            var propertyInfos = TypeInfoProvider.GetProperties(type);

            foreach (var prop in propertyInfos)
            {
                Object value = TypeInfoProvider.GetValue(prop, source);
                TypeInfoProvider.SetValue(prop, dest, value);
            }
        }
        private static void ConfigLoadPropertyAnalysis(Object target, PropertyInfo prop)
        {
      
            var configTag = TypeInfoProvider.GetConfigTag(prop);
            if (configTag != null)
            {
                Object value = TypeInfoProvider.GetValue(prop, target);
                if (configTag.IsEncrypted && value != null && prop.PropertyType == typeof(String))
                {
                    String strValue = value as String;
                    strValue = DefaultStringEncryptor.Decrypt(strValue);
                    TypeInfoProvider.SetValue(prop, target, strValue);
                    return;
                }
                if (prop.PropertyType.IsSubclassOf(typeof(ConfigBase)))
                {
                    Type type = prop.PropertyType;
                    var propertyInfos = TypeInfoProvider.GetProperties(type);
                    foreach (var cprop in propertyInfos)
                    {
                        ConfigLoadPropertyAnalysis(value, cprop);
                    }
                }
            }
        }
        private static void ConfigSavePropertyAnalysis(Object target, PropertyInfo prop)
        {
            var configTag = TypeInfoProvider.GetConfigTag(prop);
            if (configTag != null)
            {
                Object value = TypeInfoProvider.GetValue(prop, target);
                if (configTag.IsEncrypted && value != null && prop.PropertyType == typeof(String))
                {
                    String strValue = value as String;
                    strValue = DefaultStringEncryptor.Encrypt(strValue);
                    TypeInfoProvider.SetValue(prop, target, strValue);
                    return;
                }
                if (prop.PropertyType.IsSubclassOf(typeof(ConfigBase)))
                {
                    Object valueCopy = TypeInfoProvider.CreateInstance(prop.PropertyType);
                    CopyConfigObject(value, valueCopy, prop.PropertyType);
                    TypeInfoProvider.SetValue(prop, target, valueCopy);
                    Type type = prop.PropertyType;
                    var propertyInfos = TypeInfoProvider.GetProperties(type);
                    foreach (var cprop in propertyInfos)
                    {
                        ConfigSavePropertyAnalysis(valueCopy, cprop);
                    }
                }
            }
        }
        /// <summary>
        /// 从指定路径加载配置对象
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="isEncrypted">表示文件是否被加密</param>
        /// <returns></returns>
        public static Object LoadConfig(Type type, String filePath, Boolean isEncrypted = false)
        {
            Object target = TypeInfoProvider.CreateInstance(type);
            LoadConfigToObject(target, type, filePath, isEncrypted);
            return target;
        }
        public static T LoadConfig<T>(String filePath, Boolean isEncrypted = false) where T : ConfigBase
        {
            Type type = typeof(T);
            Object target = TypeInfoProvider.CreateInstance(typeof(T));
            LoadConfigToObject(target, type, filePath, isEncrypted);
            return target as T;
        }
        /// <summary>
        /// 将配置对象保存到指定路径
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="savePath">保存路径  </param>
        /// <param name="isEncrypt">表示是否需要加密</param>
        public static void SaveConfig(Object obj, Type type, String savePath, Boolean isEncrypt = false)
        {

            Object target = obj;
            Object cloneTarget = Activator.CreateInstance(type);
            CopyConfigObject(target, cloneTarget, type);

            var propertyInfos = TypeInfoProvider.GetProperties(type);

            foreach (var prop in propertyInfos)
            {
                ConfigSavePropertyAnalysis(cloneTarget, prop);

            }

            var text = SerializeAssistor.Serialize(cloneTarget, type);
            if (isEncrypt)
            {
                text = DefaultStringEncryptor.Decrypt(text);
            }
            File.WriteAllText(savePath, text, _DefaultEncodeing);

        }

        public static void SaveConfig<T>(Object obj, String savePath, Boolean isEncrypt = false) where T:class
        {
            SaveConfig(obj,typeof(T),savePath, isEncrypt);
        }
    }

}
