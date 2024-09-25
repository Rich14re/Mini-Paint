﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MiniPaint
{
    public partial class Form1 : Form
    {
        public delegate void ActionDelegate();
        private ActionDelegate action;

        private bool isModified = false;
        private bool isLastik = false;
        private bool isSaving = false;
        private bool isDrawing = false;
        private bool isFigureDrawing = false;

        private ushort brush_width = 1; //дефолтное значение ширины кисти 10

        private Point lastPoint;
        private Bitmap canvas;
        private Graphics graphics;
        private ColorDialog colorDialog1;
        private Color brushColor = Color.Black;
        private Color currentBrushColor = Color.Black;

        private List<Drawing> draws = new List<Drawing>();
        private List<Point> mouse_points = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            BackToFrontInPaint();
            DoubleBuffered = true; // убирает мерцание при отрисовке
            colorDialog1 = new ColorDialog();
            canvas = new Bitmap(Canvas.Width, Canvas.Height);
            Canvas.Image = canvas;
            graphics = Graphics.FromImage(canvas);
            graphics.Clear(SystemColors.Control);
            this.Resize += Form1_Resize;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // Обновляем размеры холста
            canvas = new Bitmap(Canvas.Width, Canvas.Height);
            Canvas.Image = canvas;
            graphics = Graphics.FromImage(canvas);
            graphics.Clear(SystemColors.Control);

            // Перерисовываем все рисунки
            foreach (var drawing in draws)
            {
                using (Pen pen = new Pen(drawing.Color, drawing.Width))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    if (drawing.Points.Count > 1)
                    {
                        graphics.DrawLines(pen, drawing.Points.ToArray());
                    }
                }
            }

            Canvas.Refresh(); // Обновляем холст
        }

        //сохранение рисунков в JSON файл
        private void SaveDrawingsToJson(string filePath)
        {
            string json = JsonConvert.SerializeObject(draws, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }

        //загрузка рисунков из JSON файла
        private void LoadDrawingsFromJson(string filePath)
        {
            string json = File.ReadAllText(filePath);
            draws = JsonConvert.DeserializeObject<List<Drawing>>(json);

            //перерисовываем все рисунки после загрузки
            graphics.Clear(SystemColors.Control); // очищаем холст перед перерисовкой
            foreach (var drawing in draws)
            {
                using (Pen pen = new Pen(drawing.Color, drawing.Width))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    if (drawing.Points.Count > 1)
                    {
                        graphics.DrawLines(pen, drawing.Points.ToArray());
                    }
                }
            }
            Canvas.Refresh(); // обновляем холст
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

        private void CheckNull(object sender, EventArgs e)
        {
            if (isModified && !isSaving)
            {
                if (MessageBox.Show(this, "Вы хотите сохранить текущее изображение?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    SaveFile_button(sender, EventArgs.Empty); // вызываем сохранение файла
            }
        }

        /// <summary>
        /// открытие файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFile_button(object sender, EventArgs e)
        {
            action = () => OpenFile(sender, e); // создаем метод без параметров, который вызывает метод с параметрами
            action();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            CheckNull(sender, e);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files|*.json|Image Files|*.png;*.jpg;*.jpeg;*.bmp;*.gif";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                // Загружаем как JSON или как изображение
                if (Path.GetExtension(filePath).ToLower() == ".json")
                {
                    LoadDrawingsFromJson(filePath); // загружаем рисунки из JSON
                }
                else
                {
                    ClearCanvas();
                    Image loadedImage = Image.FromFile(filePath);
                    graphics.DrawImage(loadedImage, new Rectangle(0, 0, Canvas.Width, Canvas.Height));  // масштабируем изображение под размер Canvas
                    Canvas.Invalidate();
                    isModified = false;
                }
            }
        }

        /// <summary>
        /// сохранение файла
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFile_button(object sender, EventArgs e)
        {
            action = () => Save(sender, e); // создаем метод без параметров, который вызывает метод с параметрами
            action();
        }

        private void Save(object sender, EventArgs e)
        {
            isSaving = false;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files|*.json|PNG Files|*.png|JPEG Files|*.jpg|BMP Files|*.bmp|GIF Files|*.gif";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                if (Path.GetExtension(filePath).ToLower() == ".json") // сохраняем как JSON
                {
                    SaveDrawingsToJson(filePath);
                    isSaving = true;
                }
            }
        }


        /// <summary>
        /// событие движение мыши(считывание нажатия левой кнопки мыши)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            action = () => CanvasMouseMove(sender, e); // создаем метод без параметров, который вызывает метод с параметрами
            action();
        }

        private void CanvasMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouse_points.Add(e.Location);
                Canvas.Refresh();
            }
        }

        /// <summary>
        /// событие отрисовки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            action = () => CanvasPaint(sender, e); // создаем метод без параметров, который вызывает метод с параметрами
            action();
        }

        private void CanvasPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // используем e.Graphics для рисования непосредственно на Canvas

            Pen commonPen = new Pen(Color.Black, 1) // создаем ручку с общими настройками
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round,
                LineJoin = LineJoin.Round
            };

            foreach (var drawing in draws) // перерисовываем все рисунки из списка
            {
                commonPen.Color = drawing.Color;
                commonPen.Width = drawing.Width;

                if (drawing.Points.Count > 1)
                {
                    g.DrawLines(commonPen, drawing.Points.ToArray());
                }
            }

            if (mouse_points.Count > 1) // рисуем текущие точки мыши (во время рисования)
            {
                commonPen.Color = brushColor;
                commonPen.Width = brush_width;

                g.DrawLines(commonPen, mouse_points.ToArray());
                isModified = true;
            }

            commonPen.Dispose();
        }

        /// <summary>
        /// событие отпускания ЛКМ. После отпускания добавляет в список рисунков текущий нарисованный рисунок если он нарисован.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            action = () => CanvasMouseUp(sender, e); // создаем метод без параметров, который вызывает метод с параметрами
            action();
        }

        private void CanvasMouseUp(object sender, MouseEventArgs e)
        {
            if (mouse_points.Count > 0)
            {
                draws.Add(new Drawing(new List<Point>(mouse_points), brushColor, brush_width));
                mouse_points.Clear();
            }
        }

        ///отмена предыдущего действия(рисунка)
        private void RestoreLastAction(object sender, EventArgs e)
        {
            action = () => RestoreLast(sender, e); // создаем метод без параметров, который вызывает метод с параметрами
            action();
        }

        private void RestoreLast(object sender, EventArgs e)
        {
            if (draws.Count > 0)
            {
                draws.Remove(draws.Last());
                graphics.Clear(SystemColors.Control);
                //перерисовывание рисунков
                foreach (var drawing in draws)
                {
                    using (Pen pen = new Pen(drawing.Color, drawing.Width))
                    {
                        pen.StartCap = LineCap.Round;
                        pen.EndCap = LineCap.Round;
                        pen.LineJoin = LineJoin.Round;

                        if (drawing.Points.Count > 1)
                        {
                            graphics.DrawLines(pen, drawing.Points.ToArray());
                        }
                    }
                }
            }

            Canvas.Refresh(); //обновление холста
        }

        /// <summary>
        /// выбор цвета кисти
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Palette(object sender, EventArgs e)
        {
            action = () => Palet(sender, e); // создаем метод без параметров, который вызывает метод с параметрами
            action();
        }

        private void Palet(object sender, EventArgs e)
        {
            if (!isLastik)
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    brushColor = colorDialog1.Color;
                    currentBrushColor = brushColor; // сохраняем текущий цвет кисти
                }
        }

        /// <summary>
        /// обработка закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitMessage(object sender, FormClosingEventArgs e)
        {
            action = () => ExitMes(sender, e); // создаем метод без параметров, который вызывает метод с параметрами
            action();
        }

        private void ExitMes(object sender, FormClosingEventArgs e)
        {
            if (!isModified || isSaving) // если холст пустой - сразу закрыть
            {
                e.Cancel = false;
                return;
            }

            if (MessageBox.Show(this, "Вы хотите сохранить изображение перед выходом?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)  // указываем this, чтобы месседж был по центру формы
            {
                SaveFile_button(sender, EventArgs.Empty); // вызываем сохранение файла

                if (isSaving) // если успешно
                {
                    e.Cancel = false; // закрытие формы
                }
                else
                {
                    e.Cancel = true; // отменяем закрытие формы
                }
            }
            else
            {
                e.Cancel = false; // разрешаем закрытие формы, если пользователь выбрал "Нет"
            }
        }

        /// <summary>
        /// новый файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FileOpening(object sender, EventArgs e)
        {
            action = () => FileOpen(sender, e);
            action();
        }

        private void FileOpen(object sender, EventArgs e)
        {
            CheckNull(sender, e);
            graphics = Graphics.FromImage(canvas);
            ClearCanvas();
            Canvas.Invalidate();
        }

        private void ClearCanvas()
        {
            graphics.Clear(SystemColors.Control); // очищаем Canvas белым цветом
            draws.Clear(); // очищаем список рисунков
            isModified = false;
        }

        /// <summary>
        /// ластик
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Rubber(object sender, EventArgs e)
        {
            action = Rub;
            action();
        }

        private void Rub()
        {
            currentBrushColor = brushColor; // Сохраняем текущий цвет кисти
            isLastik = true;
            brushColor = SystemColors.Control;
        }

        /// <summary>
        /// кисточка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Brush_pb1_Click(object sender, EventArgs e)
        {
            action = Brush;
            action();
        }

        private void Brush()
        {
            isLastik = false;
            brushColor = currentBrushColor; // восстанавливаем текущий цвет кисти
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            action = () => track(sender, e);
            action();
        }

        private void track(object sender, EventArgs e)
        {
            TrackBar trackBar = sender as TrackBar;
            if (trackBar != null)
            {
                brush_width = (ushort)trackBar.Value;
            }
        }

        private void ChangeFigureButton(object sender, EventArgs e)
        {
            FigurePicker shapeForm = new FigurePicker();
            if (shapeForm.ShowDialog() == DialogResult.OK)
            {
                string selectedShape = shapeForm.SelectedShape;
                MessageBox.Show("Вы выбрали: " + selectedShape);
            }
        }
    }
}