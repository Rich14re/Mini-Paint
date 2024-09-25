using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPaint
{
    public partial class FigurePicker : Form
    {
        public string SelectedShape { get; set; }

        public FigurePicker()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ListBox cbx = Figures;
            if (cbx.SelectedItem != null)
            {
                SelectedShape = cbx.SelectedItem.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void FigurePicker_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }
    }
}
