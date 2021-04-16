using System;

namespace ConsoleApp1
{
    class Program
    {
   /* Vytvorte tridu Obdelnik, ktera bude mit vlastnosti Sirka a Vyska jako properties.
   Nastavte properties tak, aby je nebylo mozne zmenit po vytvoreni instance.
   Obdelniku vytvorte funkci Vypis informace, ktery vypise vysku a sirku.
   Vytvorte property Obsah, ktera umozni ziskat obsah obdelniku.
   Vytvorte property Obvod, ktera umozni ziskat obvod obdelniku.
   Vytvorte funkci Zvetsi, ktera zvetsi obdelnik o sirku a vysku.
   Zajistete, aby nebylo mozne vytvorit obdelnik o obsahu 0.
   Napiste program, ktery vytvori obdelnik, vypise jeho velikosti, obsah a obvod.
*/
        static void Main(string[] args)
        {
            Obdelnik obdelnik = new Obdelnik(4, 2);
            obdelnik.VypisInformace();
            Console.WriteLine(obdelnik.Obsah);
            Console.WriteLine(obdelnik.Obvod);

            obdelnik.Zvetsi(1, 1);
            obdelnik.VypisInformace();
            Console.WriteLine(obdelnik.Obsah);
            Console.WriteLine(obdelnik.Obvod);
        }
    }
}
