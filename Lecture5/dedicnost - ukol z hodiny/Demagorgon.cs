using System;
using System.Collections.Generic;
using System.Text;

namespace dedicnost___ukol_z_hodiny
{
    class Demagorgon : DomaciMazlicek
    {
        public Demagorgon(string jmeno)
        {
            Jmeno = jmeno;
        }
        public override void NakrmSe()
        {
            Console.WriteLine($"{this} ti prave sezral babicku.");
        }

        public override void Aportuj()
        {
            Console.WriteLine($"{this} ti ukousl nohu.");
        }

        public override void UdelejTrik()
        {
            Console.WriteLine($"{this} ti ukousl hlavu.");
        }
    }
}
