using System.Windows;

namespace Lesson07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var obdelnik = new Obdelnik();
            obdelnik.Vyska = 60;
            obdelnik.Sirka = 120;
            obdelnik.LevyHorniRoh = new Point(30, 30);
            obdelnik.Vykresli(mainCanvas);

            var usecka = new Usecka();
            usecka.Bod1 = new Point(30,200);
            usecka.Bod2 = new Point(300,200);
            usecka.Vykresli(mainCanvas);

            var usecka2 = new Usecka();
            usecka2.Bod1 = new Point(30, 150);
            usecka2.Bod2 = new Point(290, 150);
            usecka2.Vykresli(mainCanvas);

            var ctverec = new Ctverec();
            ctverec.Delka = 100;
            //nepouzivat:
            //ctverec.Sirka = 80;
            //ctverec.Vyska = 60;
            ctverec.LevyHorniRoh = new Point(280, 30);
            ctverec.Vykresli(mainCanvas);

            var kruh = new Kruh();
            kruh.Bod1 = new Point(120, 170); // stred
            kruh.Bod2 = new Point(140, 140);
            kruh.Vykresli(mainCanvas);

            var trojuhelnik = new Trojuhelnik();
            trojuhelnik.Bod1 = new Point(30, 300);
            trojuhelnik.Bod2 = new Point(300, 300);
            trojuhelnik.Bod3 = new Point(200, 100);
            trojuhelnik.Vykresli(mainCanvas);

            var sipka = new Sipka();
            sipka.Bod1 = new Point(30, 250);
            sipka.Bod2 = new Point(500, 250);
            sipka.Vykresli(mainCanvas);
        }
    }
}
