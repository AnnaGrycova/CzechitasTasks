using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lesson07
{
    public class Usecka
    {
        public Point Bod1 { get; set; }
        public Point Bod2 { get; set; }
        public double Delka => Math.Sqrt(Math.Pow(Bod1.Y - Bod2.Y, 2) + Math.Pow(Bod1.X - Bod2.X, 2));

        public virtual void Vykresli(Canvas canvas)
        {
            var line = new Line
            {
                X1 = Bod1.X,
                Y1 = Bod1.Y,
                X2 = Bod2.X,
                Y2 = Bod2.Y,
                Stroke = Brushes.Black,
                StrokeThickness = 2
            };
            canvas.Children.Add(line);
        }
    }
}
