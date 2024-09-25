using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPaint
{
    public class RectangleFigure : Drawing
    {
        public RectangleFigure(Point startPoint, Point endPoint, Color color, ushort width)
        : base(new List<Point> { startPoint, endPoint }, color, width)
        {
        }

        public void Draw(Graphics g)
        {
            if (Points.Count >= 2)
            {
                Point p1 = Points[0]; // Первая точка (верхний левый угол)
                Point p2 = Points[1]; // Вторая точка (нижний правый угол)

                //размеры прямоугольника
                int x = Math.Min(p1.X, p2.X);
                int y = Math.Min(p1.Y, p2.Y);
                int width = Math.Abs(p1.X - p2.X);
                int height = Math.Abs(p1.Y - p2.Y);

                using (Pen pen = new Pen(Color, Width))
                {
                    g.DrawRectangle(pen, x, y, width, height);
                }
            }
        }
    }
}
