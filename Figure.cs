using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPaint
{
    public abstract class Figure
    {
        public Color Color { get; set; }
        public float LineWidth { get; set; }
        public string Name { get; set; }
        public Point[] Coordinates { get; set; }

        public Figure(Color color, float lineWidth, string name, Point[] coordinates)
        {
            Color = color;
            LineWidth = lineWidth;
            Name = name;
            Coordinates = coordinates;
        }

        public abstract void Draw(Graphics graphics);
    }

    public class Rectangle : Figure
    {
        public Rectangle(Color color, float lineWidth, string name, Point[] coordinates)
            : base(color, lineWidth, name, coordinates)
        {
        }

        public override void Draw(Graphics graphics)
        {
            using (Pen pen = new Pen(Color, LineWidth))
            {
                graphics.DrawRectangle(pen, Coordinates[0].X, Coordinates[0].Y,
                                            Coordinates[1].X - Coordinates[0].X,
                                            Coordinates[1].Y - Coordinates[0].Y);
            }
        }
    }

    public class Circle : Figure
    {
        public Circle(Color color, float lineWidth, string name, Point[] coordinates)
            : base(color, lineWidth, name, coordinates)
        {
        }

        public override void Draw(Graphics graphics)
        {
            using (Pen pen = new Pen(Color, LineWidth))
            {
                int radius = (int)Math.Sqrt(Math.Pow(Coordinates[1].X - Coordinates[0].X, 2) +
                                            Math.Pow(Coordinates[1].Y - Coordinates[0].Y, 2));
                graphics.DrawEllipse(pen, Coordinates[0].X, Coordinates[0].Y, radius * 2, radius * 2);
            }
        }
    }

    public class Line : Figure
    {
        public Line(Color color, float lineWidth, string name, Point[] coordinates)
            : base(color, lineWidth, name, coordinates)
        {
        }

        public override void Draw(Graphics graphics)
        {
            using (Pen pen = new Pen(Color, LineWidth))
            {
                graphics.DrawLine(pen, Coordinates[0], Coordinates[1]);
            }
        }
    }
}
