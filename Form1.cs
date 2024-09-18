using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniPaint
{
    public partial class Form1 : Form
    {
        private bool isDrawing = false;
        private Point lastPoint;
        private Bitmap canvas;
        private Graphics graphics;
        private ColorDialog colorDialog1;
        private Color brushColor = Color.Black;

        private List<Drawing> draws = new List<Drawing>();
        private List<Point> mouse_points = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            BackToFrontInPaint();
            DoubleBuffered = true; //убирает мерцание при отрисовке
            colorDialog = new ColorDialog();
        }
        /// <summary>
        /// все элементы интерфейса поверх холста
        /// </summary>
        private void BackToFrontInPaint()
        {
            panel1.BringToFront();
            Brush_pb1.BringToFront();
            pictureBox2.BringToFront();
            pictureBox3.BringToFront();
            pictureBox4.BringToFront();
            pictureBox5.BringToFront();
            pictureBox6.BringToFront();
            pictureBox7.BringToFront();
            pictureBox8.BringToFront();
            pictureBox9.BringToFront();
        }

        /// <summary>
        /// открытие файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile_button(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif"; // устанавливаем фильтр для файлов изображений

            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); // директория, открываемая по клику

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                Canvas.Image = Image.FromFile(filePath); // помещаем картинку на холст
            }
        }
        /// <summary>
        /// сохранение файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFile_button(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "PNG Files|*.png|JPEG Files|*.jpg|BMP Files|*.bmp|GIF Files|*.gif"; // устанавливаем фильтр для файлов изображений
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); // устанавливаем начальную директорию 

            if (saveFileDialog.ShowDialog() == DialogResult.OK) // выбор места сохранения
            {
                string filePath = saveFileDialog.FileName;

                canvas.Save(filePath);
            }
        }

        /// <summary>
        /// событие движение мыши(считывание нажатия левой кнопки мыши)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            //обработка нажатия левой кнопки мыши по полю холста
            if (e.Button == MouseButtons.Left)
            {
                mouse_points.Add(e.Location);
                this.Refresh();
            }
        }


        /// <summary>
        /// событие отрисовки(требуется переработка рисования и привязка к кнопке)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var drawing in draws)
            {
                using (Pen pen = new Pen(drawing.Color, 20)) // Use color from Drawing
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    if (drawing.Points.Count > 1)
                    {
                        e.Graphics.DrawLines(pen, drawing.Points.ToArray());
                    }
                }
            }

            if (mouse_points.Count > 1)
            {
                using (Pen pen = new Pen(brushColor, 20)) // Current color
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    e.Graphics.DrawLines(pen, mouse_points.ToArray());
                }
            }
        }

        /// <summary>
        /// событие отпускания ЛКМ. После отпускания добавляет в список рисунков текущий нарисованный рисунок если он нарисован.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouse_points.Count > 0)
            {
                draws.Add(new Drawing(new List<Point>(mouse_points), brushColor));
                mouse_points.Clear();
            }
        }

        //отмена предыдущего действия(рисунка)
        private void RestoreLastAction(object sender, EventArgs e)
        {
            if (draws.Count > 0)
            {
                draws.Remove(draws.Last());
            }

            this.Refresh(); //обновление холста
        }


        /// <summary>
        /// выбор цвета кисти
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Palette(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                brushColor = colorDialog.Color;
            }
        }
    }
}
