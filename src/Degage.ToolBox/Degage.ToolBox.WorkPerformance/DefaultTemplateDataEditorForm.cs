using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkPerformance
{
    public partial class DefaultTemplateDataEditorForm : BaseForm, IDataEditor
    {
        public PerformanceTemplate PerformanceTemplate { get; private set; }
        private IList<DataItem> DataItems { get; set; }
        private Dictionary<String, DataEditorItem> DataEditorItemTable { get; set; }
        private Dictionary<String, TemplateSchemaItem> TemplateSchemaItemTable { get; set; }
        public DefaultTemplateDataEditorForm()
        {
            InitializeComponent();

            var editorItems = new List<DataEditorItem>
            {
                new DataEditorItem("Name",(t)=> this._tbName.Text=t.TextData,()=>new DataItem("Name",this._tbName.Text?.Trim())),
                new DataEditorItem("Department",(t)=> this._tbDepartment.Text=t.TextData,()=>new DataItem("Department",this._tbDepartment.Text?.Trim())),
                new DataEditorItem("Month",(t)=> this._tbMonth.Text=t.TextData,()=>new DataItem("Month",this._tbMonth.Text?.Trim())),
                new DataEditorItem("SelfAssessment",(t)=> this._tbSelfAssessment.Text=t.TextData,()=>new DataItem("SelfAssessment",this._tbSelfAssessment.Text?.Trim())),
                new DataEditorItem("CenterAuditOpinion",(t)=> this._tbCenterAuditOpinion.Text=t.TextData,()=>new DataItem("CenterAuditOpinion",this._tbCenterAuditOpinion.Text?.Trim())),
                new DataEditorItem("DirectSupervisorOpinion",(t)=> this._tbDirectSupervisorOpinion.Text=t.TextData,()=>new DataItem("DirectSupervisorOpinion",this._tbDirectSupervisorOpinion.Text?.Trim())),
                new DataEditorItem("ChargeSupervisorOpinion",(t)=> this._tbChargeSupervisorOpinion.Text=t.TextData,()=>new DataItem("ChargeSupervisorOpinion",this._tbChargeSupervisorOpinion.Text?.Trim())),
                   new DataEditorItem("GeneralManagerOpinion",(t)=> this._tbGeneralManagerOpinion.Text=t.TextData,()=>new DataItem("GeneralManagerOpinion",this._tbGeneralManagerOpinion.Text?.Trim())),
                new DataEditorItem("ManagerOpinion",(t)=> this._tbManagerOpinion.Text=t.TextData,()=>new DataItem("ManagerOpinion",this._tbManagerOpinion.Text?.Trim())),
                new DataEditorItem("BaseTask",(t)=> this._dvBaseTask.DataSource=t.TableData,()=>new DataItem("BaseTask",this._dvBaseTask.DataSource as DataTable)),
                new DataEditorItem("MonthAddTask",(t)=> this._dvNewTask.DataSource=t.TableData,()=>new DataItem("MonthAddTask",this._dvNewTask.DataSource as DataTable)),
                new DataEditorItem("NextMonthPlan",(t)=> this._dvNextTaskPlan.DataSource=t.TableData,()=>new DataItem("NextMonthPlan",this._dvNextTaskPlan.DataSource as DataTable))
            };
            this.DataEditorItemTable = editorItems.ToDictionary(t => t.SchemaName);
            this.Load += DefaultTemplateDataEditorForm_Load;
        }

        private void DefaultTemplateDataEditorForm_Load(Object sender, EventArgs e)
        {
            if (this.DataItems == null)
            {
                var userInfo = Config<UserInfoConfig>.Current;
                this._tbName.Text = userInfo.Name;
                this._tbDepartment.Text = userInfo.Department;
                this._tbMonth.Text = DateTime.Now.ToString("yyyyMM");
            }

            if (this._dvBaseTask.DataSource == null)
            {
                if (this.TemplateSchemaItemTable.ContainsKey("BaseTask"))
                {
                    this._dvBaseTask.DataSource = MainForm.Current.TemplateManager.CreateDataTable(this.TemplateSchemaItemTable["BaseTask"]);
                }
            }

            if (this._dvNewTask.DataSource == null)
            {
                if (this.TemplateSchemaItemTable.ContainsKey("MonthAddTask"))
                {
                    this._dvNewTask.DataSource = MainForm.Current.TemplateManager.CreateDataTable(this.TemplateSchemaItemTable["MonthAddTask"]);
                }
            }

            if (this._dvNextTaskPlan.DataSource == null)
            {
                if (this.TemplateSchemaItemTable.ContainsKey("NextMonthPlan"))
                {
                    this._dvNextTaskPlan.DataSource = MainForm.Current.TemplateManager.CreateDataTable(this.TemplateSchemaItemTable["NextMonthPlan"]);
                }
            }
        }

        public IList<DataItem> GetDataItems()
        {
            var result = new List<DataItem>();
            foreach (var editorItem in this.DataEditorItemTable)
            {
                var dataItem = editorItem.Value.Getter.Invoke();
                result.Add(dataItem);
            }
            return result;
        }

        public void Init(PerformanceTemplate template)
        {
            this.PerformanceTemplate = template;
            this.TemplateSchemaItemTable = this.PerformanceTemplate.SchemaItems.ToDictionary(t => t.Name);
        }

        public void LoadDataItems(IList<DataItem> dataItems)
        {
            this.DataItems = dataItems;
            var dataItemTable = dataItems.ToDictionary(t => t.Name);
            var result = new List<DataItem>();
            foreach (var editorItem in this.DataEditorItemTable)
            {
                if (dataItemTable.ContainsKey(editorItem.Key))
                {
                    editorItem.Value.Loader(dataItemTable[editorItem.Key]);
                }
            }
        }
        private void _btnCancel_Click(Object sender, EventArgs e)
        {
            this.CancelClose();
        }

        private void _btnConfirm_Click(Object sender, EventArgs e)
        {
            this.ConfirmClose();
        }
    }
    public class DataEditorItem
    {
        public DataEditorItem(String name, Action<DataItem> loader, Func<DataItem> getter)
        {
            this.SchemaName = name;
            this.Loader = loader;
            this.Getter = getter;
        }
        public String SchemaName { get; private set; }
        public Action<DataItem> Loader { get; private set; }
        public Func<DataItem> Getter { get; private set; }
    }
}
