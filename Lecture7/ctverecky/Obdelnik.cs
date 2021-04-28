using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lesson07
{
    public class Obdelnik
    {
        protected double vyska;
        protected double sirka;

        public Point LevyHorniRoh { get; set; }

        public double Sirka
        {
            get { return sirka; }
            set { sirka = value; }
        }

        public double Vyska
        {
            get { return vyska; }
            set { vyska = value; }
        }

        public void Vykresli(Canvas canvas)
        {
            var rectangle = new Rectangle
            {
                Width = Sirka, Height = Vyska, Stroke = Brushes.Black, StrokeThickness = 2
            };
            canvas.Children.Add(rectangle);
            Canvas.SetLeft(rectangle, LevyHorniRoh.X);
            Canvas.SetTop(rectangle, LevyHorniRoh.Y);
        }
    }
}
