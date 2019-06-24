using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Degage.DataModel.Schema.Toolbox
{
   // [TypeConverterAttribute(typeof(SerializableExpandableObjectConverter))]
    public abstract class ConfigBase
    {

        public ConfigBase()
        {
            
        }

        /// <summary>
        /// 从磁盘文件中加载配置信息到此实例
        /// </summary>
        public void Load(String filePath, Boolean isEncrypted = false)
        {
            Type type = this.GetType();
            ConfigManager.LoadConfigToObject(this, type, filePath, isEncrypted);
        }
        public async Task LoadAsync(String filePath, Boolean isEncrypted = false)
        {
            await Task.Run(() =>
           {
               this.Load(filePath, isEncrypted);
           });
        }
        /// <summary>
        /// 保存此实例包含的配置信息到磁盘文件
        /// </summary>
        public void Save(String savePath, Boolean isEncrypt = false)
        {
            Type type = this.GetType();
            ConfigManager.SaveConfig(this, type, savePath, isEncrypt);
        }
        public async Task SaveAsync(String savePath, Boolean isEncrypt = false)
        {
            await Task.Run(() =>
            {
                this.Save(savePath, isEncrypt);
            });
        }

    }
    public class SerializableExpandableObjectConverter : ExpandableObjectConverter
    {
        public override Boolean CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(String)) return false;
            return base.CanConvertTo(context, destinationType);
        }
        public override Boolean CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(String)) return false;
            return base.CanConvertFrom(context, sourceType);
        }
    }
}
