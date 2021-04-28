using System.Windows;
using System.Windows.Controls;

namespace Lesson07
{
    public class Sipka : Usecka
    {
        public override void Vykresli(Canvas canvas)
        {
            // vykresleni cary, usecky
            base.Vykresli(canvas);

            // vyjresleni trojuhelniku, zakonceni sipky
            var trojuhelnik = new Trojuhelnik
            {
                Bod1 = Bod2,
                Bod2 = new Point(Bod2.X - 10, Bod2.Y + 10),
                Bod3 = new Point(Bod2.X - 10, Bod2.Y - 10)
            };
            trojuhelnik.Vykresli(canvas);
        }
    }
}
