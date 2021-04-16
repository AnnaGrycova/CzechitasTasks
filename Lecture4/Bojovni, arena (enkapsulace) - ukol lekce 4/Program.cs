using System;
using System.Collections.Generic;

namespace Bojovni__arena__enkapsulace____ukol_lekce_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Zbran, int> stats = new Dictionary<Zbran, int> {
                {Zbran.Mec, 0},
                {Zbran.Palcat, 0},
                {Zbran.Kyj, 0},
                {Zbran.Prak, 0},
                {Zbran.Lzicka, 0}
            };

            //for (int i = 0; i < 1000; i++)
            //{
                Arena arena = new Arena();
                Bojovnik bojovnik1 = new Bojovnik("Tonislav", 10, Zbran.Lzicka);
                Bojovnik bojovnik2 = new Bojovnik("Nosislav", 10, Zbran.Kyj);
                arena.seznamBojovniku = new List<Bojovnik>()
                {
                    bojovnik1,
                    bojovnik2,
                    new Bojovnik("Pajoslav", 10, Zbran.Palcat),
                    new Bojovnik("Andulika", 10, Zbran.Mec),
                    new Bojovnik("Ohnislav", 10, Zbran.Prak)
                };

                arena.Boj();

                foreach (Bojovnik bojovnik in arena.seznamBojovniku)
                {
                    stats[bojovnik.VybranaZbran] += bojovnik.Zivot > 0 ? 1 : 0;
                }
            //}

            //foreach (Zbran zbran in stats.Keys)
            //{
            //    Console.WriteLine($"{zbran}: {stats[zbran]}");
            //}
        }
    }
}
