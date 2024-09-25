using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPaint
{
    public class Line : Drawing
    {
        public Line(Point startPoint, Point endPoint, Color color, ushort width)
        : base(new List<Point> { startPoint, endPoint }, color, width)
        {
        }

        public void Draw(Graphics g)
        {
            if (Points.Count >= 2)
            {
                Point p1 = Points[0];
                Point p2 = Points[1];
                
                using (Pen pen = new Pen(Color, Width))
                {
                    g.DrawLine(pen, p1, p2);
                }
            }
        }
    }
}
