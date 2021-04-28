using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Lesson07
{
    public class Kruh : Usecka
    {
        public override void Vykresli(Canvas canvas)
        {
            var polomer = Delka;
            var kruh = new Ellipse
            {
                Width = 2*polomer, Height = 2*polomer, Stroke = Brushes.Black, StrokeThickness = 2
            };
            canvas.Children.Add(kruh);
            Canvas.SetLeft(kruh, Bod1.X - polomer);
            Canvas.SetTop(kruh, Bod1.Y - polomer);

            var line = new Line
            {
                X1 = Bod1.X,
                Y1 = Bod1.Y,
                X2 = Bod2.X,
                Y2 = Bod2.Y,
                Stroke = Brushes.DodgerBlue,
                StrokeThickness = 2
            };
            canvas.Children.Add(line);
        }
    }
}
