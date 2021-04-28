using System;
using System.Collections.Generic;
using System.Text;

namespace Ukol_Banka___interface
{
    class Banka
    {
        //pouzivam rozhrani IUcet a ne Ucet, muzu tak pracovat s ruznymi tridami, ktere 
        //implementuji rozhrani IUcet (Napr. Ucet, UcetAirbank, UcetFioBank), polymorfismus
        private Dictionary<string, Ucet> slovnikUctu = new Dictionary<string, Ucet>();
        //v praxi by mozna bylo lepsi predat v parametrech IUcet, je to obecnejsi a lepe testovatelne
        //viz:
        //public void ZalozUcet(Ucet ucet)
        //{
        //    slovnikUctu.Add(ucet.Vlastnik, ucet);
        //}
        public IUcet ZalozUcet(double pocatecniZustatek, string jmenoVlastnika)
        {
            Ucet ucet = new Ucet(jmenoVlastnika, pocatecniZustatek);
            slovnikUctu.Add(jmenoVlastnika, ucet);
            return ucet;
        }

        public IUcet NajdiUcet(string jmenoVlastnika)
        {
            return slovnikUctu[jmenoVlastnika];
        }
        
        public void UlozPenize(string jmenoVlastnika, double obnos)
        {
            Ucet ucet = slovnikUctu[jmenoVlastnika] as Ucet;
            ucet.Zustatek += obnos;
        }
        //join proiteruje slovnikUctu.Values a spoji kazdy prvek a zavola na jednotlivych prvcich ToString()
        public override string ToString()
        {
            return String.Join("\n", slovnikUctu.Values);
        }
    }
}
