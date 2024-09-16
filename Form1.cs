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
    public partial class Form1 : Form
    {
        private bool isDrawing = false;
        private Point lastPoint;
        private Bitmap canvas;
        private Graphics graphics;

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// открытие файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox4_Click(object sender, EventArgs e)
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
        private void pictureBox8_Click(object sender, EventArgs e)
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
    }
}
