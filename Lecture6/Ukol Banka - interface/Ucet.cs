using System;
using System.Collections.Generic;
using System.Text;

namespace Ukol_Banka___interface
{
    class Ucet : IUcet
    {
        public string Vlastnik { get; private set; }
        public double Zustatek { get; set; }

        public Ucet(string vlastnik, double pocatecniZustatek)
        {
            Vlastnik = vlastnik;
            Zustatek = pocatecniZustatek;
        }

        public override string ToString()
        {
            return $"{Vlastnik}: {Zustatek}";
        }
    }
}
