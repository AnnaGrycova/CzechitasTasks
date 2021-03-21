using System;
using System.Text;


namespace Lekce_2___stringy__chary
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Ahoj" + " Czechitas!";
            PraceSCharem(text);
            PraceSeStringy();
            PraceSeStringBuilderem();

            Console.ReadLine();
        }

        private static void PraceSeStringBuilderem()
        {
            string text1 = "Ahoj";
            string text2 = " Jardo";
            string text3 = text1 + text2;
            //             "Ahoj Jardo"

            Console.WriteLine(DateTime.Now);
            //string dlouhyText = "";
            //for (int i = 0; i < 100000; i++)
            //{
            //    dlouhyText += text1;
            //}

            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < 100000; i++)
            {
                stringBuilder.Append(text1);
            }
            string dlouhyText = stringBuilder.ToString();
            Console.WriteLine(DateTime.Now);
        }

        private static void PraceSeStringy()
        {
            // Rytíř č.1 - Bořivoj - počet bodů: 100
            int cisloRytire = 1;
            string jmeno = "Bořivoj";
            int pocetBodu = 100;

            Console.WriteLine("Rytíř č." + cisloRytire + " - " + jmeno + " - počet bodů: " + pocetBodu);
            string vyslednyText = string.Format("Rytíř č.{0} - {1} - počet bodů: {2}", cisloRytire, jmeno, pocetBodu);
            Console.WriteLine(vyslednyText);
            vyslednyText = $"Rytíř č.{cisloRytire} - {jmeno} - počet bodů: {pocetBodu}";
            Console.WriteLine(vyslednyText);

            // text na vic radku, nelze doplnovat promenne
            Console.WriteLine(@"Ahoj!
     Jmenuju se Jarda.
     Hrozne rad ucim C#!!!!!
");

            // uzivatel zadal nazev objednavky
            string vyber = "BuRger";
            string burgerText = "burger";

            // if (vyber.ToLower() == burgerText)
            // if (vyber.Equals(burgerText, StringComparison.OrdinalIgnoreCase))
            if (string.Compare(burgerText, vyber, StringComparison.OrdinalIgnoreCase) == 0)
            {
                Console.WriteLine("Je to Burger");
            }
            else
            {
                Console.WriteLine("Neni to Burger: " + string.Compare(burgerText, vyber));
            }

            string vyber2 = "ger";
            if (burgerText.Contains(vyber2))
            {
                Console.WriteLine("Obsahuje cast Burgeru");
            }

            Console.WriteLine($"{vyber2} v {burgerText} zacina na indexu: " + burgerText.IndexOf(vyber2));
            string jmenoSMezerama = ".#.Jarda    ";
            Console.WriteLine("S mezerama: " + jmenoSMezerama);
            Console.WriteLine("Bez mezer: " + jmenoSMezerama.Trim('.', ' ', '#'));

            Console.WriteLine("Objednavkovy automat");
            Console.WriteLine("====================");
            Console.WriteLine(burgerText.PadRight(20, '.') + "10Kč");

            bool jePlatnyText = string.IsNullOrEmpty(jmenoSMezerama); // Empty == ""
            Console.WriteLine($"Je {jmenoSMezerama} null or empty? {jePlatnyText}");
            string jmenoSameMezery = "      ";
            bool jePlatnyText2 = string.IsNullOrWhiteSpace(jmenoSameMezery);
            Console.WriteLine($"Je {jmenoSameMezery} null or whitespace? {jePlatnyText2}");

            string datumText = "10.3.2021";
            string[] rozdelenyDatumText = datumText.Split(new char[] { '.', '$' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < rozdelenyDatumText.Length; i++)
            {
                Console.WriteLine(rozdelenyDatumText[i]);
            }

            Console.WriteLine($"Datum: {datumText}");
            Console.WriteLine($"Datum po replace: {datumText.Replace('.', '/')}");

        }

        private static void PraceSCharem(string text)
        {
            int delkaTextu = text.Length;
            char posledniZnak = text[delkaTextu - 1];
            // char posledniZnak = text[text.Length - 1];
            // char posledniZnak = text[^1];

            Console.WriteLine(text);
            Console.WriteLine("Prvni znak: " + text[0]);

            char znak = text[0];
            Console.WriteLine("Pismeno " + znak + "=" + (int)znak);
            znak = 'č';
            Console.WriteLine("Pismeno " + znak + "=" + (int)znak);

            znak = char.ToUpper(znak);
            Console.WriteLine("Pismeno " + znak + "=" + (int)znak);
            bool jeCislo = char.IsDigit(znak);
            bool jeZnak = char.IsLetter(znak);
            bool jeZnakNeboCislo = char.IsLetterOrDigit(znak);
            Console.WriteLine("Pismeno " + znak + " je cislo? " + jeCislo);
            Console.WriteLine("Pismeno " + znak + " je znak? " + jeZnak);

            Console.Write("Stiskni klavesu: ");
            znak = Console.ReadKey().KeyChar;
            Console.WriteLine("Pismeno " + znak + "=" + (int)znak);

            // toto neni stejne jako pole
            // text[0] = 'D'; // toto je pouze pro cteni
        }
    }
}
