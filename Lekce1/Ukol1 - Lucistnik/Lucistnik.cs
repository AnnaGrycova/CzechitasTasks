using System;
using System.Collections.Generic;
using System.Text;

namespace Ukol1___Lucistnik
{
    class Lucistnik
    {
        public int PocetSipu = 10;

        public void Vystrel()
        {
            if (MamSipy())
            {
                PocetSipu--;
                Console.WriteLine($"Pocet sipu: {PocetSipu + 1}. Vzdy se strefim primo doprostred!");
            }
            else
            {
                Console.WriteLine("Nemam sipy");
            }
        }

        public bool MamSipy()
        {
            return PocetSipu > 0;
        }
    }
}
