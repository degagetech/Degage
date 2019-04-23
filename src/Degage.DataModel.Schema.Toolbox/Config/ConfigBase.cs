using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
namespace Degage.DataModel.Schema.Toolbox
{
 [TypeConverterAttribute(typeof(SerializableExpandableObjectConverter))]
    public abstract class ConfigBase : ICustomTypeDescriptor
    {
        private TypeInstanceWrapper _typeInstanceWrapper;

        public ConfigBase()
        {
            _typeInstanceWrapper = new TypeInstanceWrapper(this);
        }

        public AttributeCollection GetAttributes()
        {
            return _typeInstanceWrapper.GetAttributes();
        }

        public String GetClassName()
        {
            return _typeInstanceWrapper.GetClassName();
        }

        public String GetComponentName()
        {
            return this._typeInstanceWrapper.GetComponentName();
        }

        public TypeConverter GetConverter()
        {
            return _typeInstanceWrapper.GetConverter();
        }

        public EventDescriptor GetDefaultEvent()
        {
            return _typeInstanceWrapper.GetDefaultEvent();
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return _typeInstanceWrapper.GetDefaultProperty();
        }

        public object GetEditor(Type editorBaseType)
        {
            return _typeInstanceWrapper.GetEditor(editorBaseType);
        }

        public EventDescriptorCollection GetEvents()
        {
            return _typeInstanceWrapper.GetEvents();
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return _typeInstanceWrapper.GetEvents(attributes);
        }

        public PropertyDescriptorCollection GetProperties()
        {
            return _typeInstanceWrapper.GetProperties();
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            return _typeInstanceWrapper.GetProperties(attributes);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return _typeInstanceWrapper.GetPropertyOwner(pd);
        }

        /// <summary>
        /// 从磁盘文件中加载配置信息到此实例
        /// </summary>
        public void Load(String filePath, Boolean isEncrypted = false)
        {
            Type type = this.GetType();
            ConfigManager.LoadConfigToObject(this, type, filePath, isEncrypted);
        }
        /// <summary>
        /// 保存此实例包含的配置信息到磁盘文件
        /// </summary>
        public void Save(String savePath, Boolean isEncrypt = false)
        {
            Type type = this.GetType();
            ConfigManager.SaveConfig(this, type, savePath, isEncrypt);
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
