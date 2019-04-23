using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Degage.ToolBox.Pdf
{
    public partial class ImageControl : UserControl
    {
        public Image DisplayImage { get; private set; }
        public ImageControl()
        {
            InitializeComponent();
        }

        public void ShowImage(String imageFileName)
        {
            Bitmap bitmap = new Bitmap(imageFileName);
            this._pbImage.Image = bitmap;
            this.DisplayImage = bitmap;
            this._lblFileName.Text =Path.GetFileName(imageFileName);
        }


    }
}
