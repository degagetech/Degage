using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.ComponentModel;

using System.Drawing.Design;
namespace Degage.DataModel.Schema.Toolbox
{
    public class TypeInstanceWrapper : CustomTypeDescriptor
    {
        public Object Instance
        {
            get
            {
                return _instance;
            }
        }
        private Type _instanceType;
        private Object _instance;
        public TypeInstanceWrapper(Object instance) : base(TypeDescriptor.GetProvider(instance).GetTypeDescriptor(instance))
        {
            _instanceType = instance.GetType();
            _instance = instance;
        }
        public override PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {


            var propDescArray = base.GetProperties(new Attribute[] { new ConfigTagAttribute() });


            List<PropertyDescriptor> descList = new List<PropertyDescriptor>();
            foreach (PropertyDescriptor propdesc in propDescArray)
            {

                var existsAttributes = propdesc.Attributes.Cast<Attribute>();
                ConfigTagAttribute configTag = existsAttributes.Where(t => t.GetType() == typeof(ConfigTagAttribute)).First() as ConfigTagAttribute;
                BrowsableAttribute browsableAttribute = null;
                DisplayNameAttribute displayAttribute = null;
                DescriptionAttribute descriptionAttribute = null;
                CategoryAttribute categoryAttribute = null;

                String displayName = configTag.Name;
                if (String.IsNullOrEmpty(displayName)) displayName = propdesc.DisplayName;

                displayAttribute = new DisplayNameAttribute(displayName);

                browsableAttribute = new BrowsableAttribute(configTag.IsFindable);

                String description = configTag.Description;
                if (configTag.IsEncrypted && !String.IsNullOrEmpty(description))
                {
                    description = $"(🔑)" + description;
                }
                descriptionAttribute = new DescriptionAttribute(description);

                categoryAttribute = new CategoryAttribute(configTag.Category);

                var constAttributes = new List<Attribute>(new Attribute[] {
                                 browsableAttribute,
                                 categoryAttribute,
                                displayAttribute,
                                descriptionAttribute,
                                });
                if (ConfigManager.IsUIDesign)
                {
                    EditorAttribute editor = this.GetEditorAttribute(configTag.UIEditor);
                    if (editor != null)
                    {
                        constAttributes.Add(editor);
                    }
                }
                var prop = TypeDescriptor.CreateProperty(_instanceType, propdesc.Name, propdesc.PropertyType, constAttributes.ToArray());
                descList.Add(prop);
            }
            var descCollection = new PropertyDescriptorCollection(descList.ToArray());

            return descCollection;
        }

        public EditorAttribute GetEditorAttribute(String uiEditorString)
        {
            EditorAttribute editor = null;
            if (!String.IsNullOrEmpty(uiEditorString))
            {
               // editor = new EditorAttribute(uiEditorString, "System.Drawing.Design.UITypeEditor,System.Drawing");
                editor = new EditorAttribute(uiEditorString, typeof(UITypeEditor));
            }
            return editor;
        }
        public override PropertyDescriptorCollection GetProperties()
        {
            return this.GetProperties(null);
        }
    }
}
