using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MojeBankovniTridy;
using Newtonsoft;

namespace Lekce_7___Banka
{
    class Program
    {
        static void Main(string[] args)
        {
			Banka mojeBanka = new Banka();
			mojeBanka.ZalozUcet("Adam", 10);
			mojeBanka.ZalozUcet("Eva", 20);

			mojeBanka.ZobrazInformaceOUctech();

			Console.WriteLine();
			mojeBanka.UlozPenize("Eva", 50.05);

			Console.WriteLine();
			mojeBanka.ZobrazInformaceOUctech();

			// mojeBanka obsahuje ucty vsech lidi na svete
			// hackera pokousejiciho se hackovat Adama se nepovedlo dohledat
			// mojeBanka ma nastesti nejlepsi zabezpeceni a hacker svuj umysl zvladl jen okomentovat
			IUcet hackovanyUcet = mojeBanka.NajdiUcet("Adam");
			// hackovanyUcet.Zustatek = 0; // nejde, jde jen cist hodnota

			// (hackovanyUcet as Ucet).Zustatek = 0;
			// mojeBanka.ZobrazInformaceOUctech();

			Console.ReadLine();
		}
	}
}
