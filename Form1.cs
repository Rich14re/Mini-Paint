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

        List<Point> mouse_points = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            BackToFrontInPaint();
            DoubleBuffered = true; //убирает мерцание при отрисовке
        }
        /// <summary>
        /// все элементы интерфейса поверх холста
        /// </summary>
        private void BackToFrontInPaint()
        {
            panel1.BringToFront();
            pictureBox1.BringToFront();
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
            else
            {
                mouse_points.Clear(); //очистка холста после повторного нажатия на холст(требуется переработка)
            }
        }

        /// <summary>
        /// событие отрисовки(требуется переработка рисования и привязка к кнопке)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (mouse_points.Count > 1)
            {
                Pen pen = new Pen(Color.Black, 20); //изменить на свойства
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round;

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                e.Graphics.DrawLines(pen, mouse_points.ToArray());
            }
        }
    }
}
