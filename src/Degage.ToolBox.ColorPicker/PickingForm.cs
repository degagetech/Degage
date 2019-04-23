using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Degage.ToolBox.ColorPicker.Properties;
namespace Degage.ToolBox.ColorPicker
{
    public partial class PickingForm : Form
    {
        public Point? SelectedPoint { get; private set; }
        public PickingForm()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.Load += PickingForm_Load;
        }

        private void PickingForm_Load(Object sender, EventArgs e)
        {
            this.Cursor = new Cursor(Resources.Cursor.Handle);
            this.Click += PickingForm_Click;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Escape:
                    {
                        this.SelectedPoint = null;
                        this.Close();
                    }
                    break;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void PickingForm_Click(Object sender, EventArgs e)
        {
            this.SelectedPoint = Form.MousePosition;
            this.Close();
        }
    }
}
