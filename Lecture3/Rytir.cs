using System;
using System.Collections.Generic;
using System.Text;

namespace Lekce3
{
    public class Rytir
    {
        private Random nahodnaCisla;

        public string Jmeno;
        public int Sila;
        public int Zivot;

        public Rytir(string jmeno)
        {
            nahodnaCisla = new Random(jmeno.GetHashCode());

            Jmeno = jmeno;
            Sila = nahodnaCisla.Next(7, 15);
            Zivot = nahodnaCisla.Next(80, 120);
        }

        public Rytir(int sila, int zivot)
        {
            Sila = sila;
            Zivot = zivot;
        }

        public override string ToString()
        {
            //ternarni operatory "?", ":"
            //Napr.:
            //var rand = new Random();
            //var condition = rand.NextDouble() > 0.5;
            //int? x = condition ? 12 : null;
            //IEnumerable<int> xs = x is null ? new List<int>() { 0, 1 } : new int[] { 2, 3 };
            //u int je otaznik, protoze se nevi, jestli se tam ulozi cislo nebo null
            //kdyby tam otaznik nebyl, tak to vyhodi error v pripade ukladani null
            return String.IsNullOrEmpty(Jmeno)
                ? string.Format("rytir -- zivot:{0} sila:{1}", Zivot, Sila)
                : string.Format("rytir {0} -- zivot:{1} sila:{2}", Jmeno, Zivot, Sila);
        }

        public bool JeNazivu()
        {
            return Zivot > 0;
        }

        public int BojujNaTurnaji(Rytir rytir)
        {
            return this.Sila - rytir.Sila + nahodnaCisla.Next(6);
        }

        public void Zautoc(Rytir rytir)
        {
            rytir.Zivot -= Sila;
        }

        public void Zautoc(Drak drak)
        {
            drak.Zivot -= Sila;
        }
    }
}
