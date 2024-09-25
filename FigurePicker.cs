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

        private void DrawFigure(string shape)
        {
            Figure figure = null;
            Point[] coordinates = new Point[] { new Point(50, 50), new Point(200, 200) };

            switch (shape)
            {
                case "Rectangle":
                    figure = new Rectangle(Color.Red, 2, "Rectangle", coordinates);
                    break;
                case "Circle":
                    figure = new Circle(Color.Blue, 2, "Circle", coordinates);
                    break;
                case "Line":
                    figure = new Line(Color.Green, 2, "Line", coordinates);
                    break;
            }

            if (figure != null)
            {
                //using (Graphics graphics = pictureBox.CreateGraphics())
                //{
                //    figure.Draw(graphics);
                //}
            }
        }
    }
}
