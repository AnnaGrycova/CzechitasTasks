using System;

namespace Ukol1___Lucistnik
{
    class Program
    {
        static void Main(string[] args)
        {
            Lucistnik lucistnik = new Lucistnik();
            while (lucistnik.MamSipy())
            {
                lucistnik.Vystrel();
            }
            lucistnik.Vystrel();
        }
    }
}
