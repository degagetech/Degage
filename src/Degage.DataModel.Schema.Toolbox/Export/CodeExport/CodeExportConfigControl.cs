using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace Degage.DataModel.Schema.Toolbox
{
    public partial class CodeExportConfigControl : BaseExportConfigControl
    {
        public List<TypeMapConfig> TypeMapConfigs { get; private set; }

        public List<CodeTemplateConfig> CodeTemplateConfigs { get; private set; }

        public override ExportConfig ExportConfig
        {
            get
            {
                return this._exportConfig;
            }
        }

        private CodeExportConfig _exportConfig;
        private CodeSchemaExporter _schemaExporter;
        private ContentSymbolManager _symbolManager;
        private Dictionary<String, IContentSymbol> _symbolTable = new Dictionary<String, IContentSymbol>();
        public override ISchemaExporter SchemaExporter
        {
            get
            {
                return _schemaExporter;
            }
        }
        public CodeExportConfigControl()
        {
            InitializeComponent();
            this._schemaExporter = new CodeSchemaExporter();
            _exportConfig = new CodeExportConfig();
            _symbolManager = new ContentSymbolManager();
            _exportConfig.SymbolModifier = new PascalSymbolModifier();
            this.Load += CodeExportConfigControl_Load;
        }

        /// <summary>
        /// 继承自 <see cref="BaseExportConfigControl.ImportConfigInfo(String)"/>
        /// </summary>
        /// <param name="configString"></param>
        public override void ImportConfigInfo(String configString)
        {
            try
            {
                _exportConfig = JsonSerializer.Deserialize<CodeExportConfig>(configString);
            }
            catch
            {
            }

        }
        /// <summary>
        /// 继承自 <see cref="BaseExportConfigControl.ExportConfigInfo"/>
        /// </summary>
        /// <returns></returns>
        public override String ExportConfigInfo()
        {
            String info = JsonSerializer.Serialize(this._exportConfig);
            return info;
        }
        /// <summary>
        /// 继承自 <see cref="BaseExportConfigControl.IsValidExportConfig(out String)"/>
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public override Boolean IsValidExportConfig(out String errorMessage)
        {
            errorMessage = null;
            if (this._cbCodeTemplate.SelectedValue == null)
            {
                errorMessage = "尚未选择代码模板！";
                return false;
            }
            if (this._cbTypeMapConfig.SelectedValue == null)
            {
                errorMessage = "尚未选择类型映射配置！";
                return false;
            }
            if (String.IsNullOrEmpty(this._tbNamespace.Text))
            {
                errorMessage = "尚未填写命名空间！";
                return false;
            }
            return true;
        }

        private async void CodeExportConfigControl_Load(Object sender, EventArgs e)
        {
            this._cbCodeTemplate.DisplayMember = nameof(CodeTemplateConfig.Name);
            this._cbTypeMapConfig.DisplayMember = nameof(TypeMapConfig.Name);
            this._exportConfig.CodeNameSpace = this._tbNamespace.Text;
            if (!this.DesignMode)
            {
                await LoadConfigInfosAsync();
                await LoadCodeContentSymbolAsync();
            }
        }
        private async Task LoadCodeContentSymbolAsync()
        {
            var result = await Task.Run(() => _symbolManager.LoadIContentSymbols());
            if (result.Count > 0)
            {
                Dictionary<String, IContentSymbol> symbolTable = new Dictionary<String, IContentSymbol>();
                this._symbolTable = symbolTable;
                _exportConfig.ContentSymbolTable = this._symbolTable;
                foreach (var item in result)
                {
                    symbolTable[item.Symbol] = item;
                }
                this._flpContentSymbol.SuspendLayout();
                foreach (var pair in symbolTable)
                {
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Margin = new Padding(5, 3, 0, 0);
                    label.Text = $"${pair.Key}$";
                    this._toolTip.SetToolTip(label, pair.Value.Description);
                    this._flpContentSymbol.Controls.Add(label);
                }
                this._flpContentSymbol.ResumeLayout();
            }
        }
        private async Task LoadConfigInfosAsync()
        {
            //获取类型映射配置
            var typeMapDirectory = this._schemaExporter.TypeMapConfigDirectory;
            var typeMapConfigs = await Task.Run(() =>
                {
                    List<TypeMapConfig> mapConfigs = new List<TypeMapConfig>();
                    String[] typeMapConfigJsonFiles = Directory.GetFiles(typeMapDirectory, "*" + this._schemaExporter.TypeMapConfigJsonFileExt);
                    String[] typeMapConfigXmlFiles = Directory.GetFiles(typeMapDirectory, "*" + this._schemaExporter.TypeMapConfigXmlFileExt);
                    if (typeMapConfigJsonFiles.Length > 0)
                    {
                        foreach (var jsonFile in typeMapConfigJsonFiles)
                        {
                            String fileStr = File.ReadAllText(jsonFile);
                            try
                            {
                                var config = JsonSerializer.Deserialize<TypeMapConfig>(fileStr);
                                config.FromFilePath = jsonFile;
                                mapConfigs.Add(config);
                            }
                            catch
                            {
                            }
                        }
                    }
                    if (typeMapConfigXmlFiles.Length > 0)
                    {
                        foreach (var xmlFile in typeMapConfigXmlFiles)
                        {
                            try
                            {
                                var config = XmlSerializer.DeSerialize<TypeMapConfig>(xmlFile, CodeExportConfig.XmlNameSpace);
                                config.FromFilePath = xmlFile;
                                mapConfigs.Add(config);
                            }
                            catch { }
                        }

                    }
                    return mapConfigs;
                });

            this.TypeMapConfigs = typeMapConfigs;

            //获取代码模板配置
            var codeTemplateDirectory = this._schemaExporter.CodeTemplateConfigDirectory;
            var codeTemplateConfigs = await Task.Run(() =>
            {
                List<CodeTemplateConfig> configs = new List<CodeTemplateConfig>();
                String[] codeTemplateConfigJsonFiles = Directory.GetFiles(codeTemplateDirectory, "*" + this._schemaExporter.CodeTemplateConfigJsonFileExt);
                String[] codeTemplateConfigXmlFiles = Directory.GetFiles(codeTemplateDirectory, "*" + this._schemaExporter.CodeTemplateConfigXmlFileExt);
                if (codeTemplateConfigJsonFiles.Length > 0)
                {
                    foreach (var jsonFile in codeTemplateConfigJsonFiles)
                    {
                        String fileStr = File.ReadAllText(jsonFile);
                        try
                        {
                            var config = JsonSerializer.Deserialize<CodeTemplateConfig>(fileStr);
                            config.FromFilePath = jsonFile;
                            configs.Add(config);
                        }
                        catch
                        {
                        }
                    }
                }
                if (codeTemplateConfigXmlFiles.Length > 0)
                {
                    foreach (var xmlFile in codeTemplateConfigXmlFiles)
                    {
                        try
                        {
                            var config = XmlSerializer.DeSerialize<CodeTemplateConfig>(xmlFile, CodeExportConfig.XmlNameSpace);
                            config.FromFilePath = xmlFile;
                            configs.Add(config);
                        }
                        catch { }
                    }
                }
                return configs;
            });

            this.CodeTemplateConfigs = codeTemplateConfigs;

            this._cbTypeMapConfig.DataSource = typeMapConfigs;
            this._cbCodeTemplate.DataSource = codeTemplateConfigs;

        }

        private void _cbTypeMapConfig_SelectedIndexChanged(Object sender, EventArgs e)
        {
            var mapConfig = this._cbTypeMapConfig.SelectedValue as TypeMapConfig;
            this._exportConfig.TypeMapConfig = mapConfig;
        }

        private void _cbCodeTemplate_SelectedIndexChanged(Object sender, EventArgs e)
        {
            var templateConfig = this._cbCodeTemplate.SelectedValue as CodeTemplateConfig;
            this._exportConfig.CodeTemplateConfig = templateConfig;
        }

        private void _tbNamespace_TextChanged(Object sender, EventArgs e)
        {
            this._exportConfig.CodeNameSpace = this._tbNamespace.Text;
        }
    }
}
