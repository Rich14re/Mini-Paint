using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPaint
{
    public class Circle : Drawing
    {
        public Circle(Point startPoint, Point endPoint, Color color, ushort width)
        : base(new List<Point> { startPoint, endPoint }, color, width)
        {
        }

        public void Draw(Graphics g)
        {
            if (Points.Count >= 2)
            {
                Point p1 = Points[0];
                Point p2 = Points[1];

                // Вычисляем радиус окружности на основе расстояния между точками
                int radius = (int)Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2)) / 2;

                // Находим координаты верхнего левого угла для рисования окружности
                int x = Math.Min(p1.X, p2.X);
                int y = Math.Min(p1.Y, p2.Y);

                // Создаем перо для отрисовки
                using (Pen pen = new Pen(Color, Width))
                {
                    // Рисуем окружность с вычисленными параметрами
                    g.DrawEllipse(pen, x, y, radius * 2, radius * 2);
                }
            }
        }
    }
}
