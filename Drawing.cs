using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniPaint
{
    /// <summary>
    /// Класс сохраняющий последний нарисованный рисунок(его свойства),
    /// чтобы при изменении цвета при перерисовке холста он не изменял цвет всех рисунков на холсте
    /// </summary>
    internal class Drawing
    {
        public List<Point> Points { get; set; } //положение рисунка на холсте
        public ushort Width { get; set; }
        public Color Color { get; set; }//цвет текущего рисунка

        public Drawing(List<Point> points, Color color, ushort width)
        {
            Points = points;
            Color = color;
            Width = width;
        }
    }
}
