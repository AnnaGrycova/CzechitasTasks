using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lesson07
{
    public class Trojuhelnik
    {
        public Point Bod1 { get; set; }
        public Point Bod2 { get; set; }
        public Point Bod3 { get; set; }

        public void Vykresli(Canvas canvas)
        {
            var rectangle = new Polygon
            {
                Points = new PointCollection(new [] {Bod1, Bod2, Bod3}),
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            canvas.Children.Add(rectangle);
        }
    }
}
