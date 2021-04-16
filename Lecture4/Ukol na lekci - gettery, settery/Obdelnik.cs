using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Obdelnik
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

        //private set - nechci, at k tomu lze pristoupit z programu, chci mit tu promennou readonly
        //ale chci k ni pristoupit z classy a moci ji nastavit
        public int Sirka { get; private set; }
        public int Vyska { get; private set; }
        private int obsah;
        public int Obsah {
            get
            {
                return obsah = Vyska * Sirka;
            }
            private set
            {
                obsah = value;
            }
           }
        private int obvod;
        public int Obvod
        {
            get
            {
                return obvod = 2 * (Vyska + Sirka);
            }
            private set
            {
                obvod = value;
            }
        }

        public void VypisInformace()
        {
            Console.WriteLine($"Sirka: {Sirka} cm, Vyska: {Vyska} cm");
        }

        public void Zvetsi(int vyska, int sirka)
        {
            Vyska += vyska;
            Sirka += sirka;
        }

        public Obdelnik(int vyska, int sirka)
        {
            Vyska = this.Vyska = vyska == 0 ? 1 : vyska;
            Sirka = this.Sirka = sirka == 0 ? 1 : sirka;
        }

        
    }
}
