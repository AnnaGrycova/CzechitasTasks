using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojeBankovniTridy
{
	public partial class Banka
	{
		// slovnik pro vzhledani uctu podle vlastnika
		Dictionary<string, Ucet> slovnikUctu = new Dictionary<string, Ucet>();

		// metoda vraci nove vytvoreny ucet, aby vlastnik mohl snadno kontrolovat stav
		public IUcet ZalozUcet(string vlastnik, double pocatecniVklad)
		{
			Ucet novyUcet = new Ucet(vlastnik, pocatecniVklad);
			slovnikUctu.Add(novyUcet.Vlastnik, novyUcet);

			return novyUcet;
		}

		// vraci bud existujici ucet nebo null
		public IUcet NajdiUcet(string vlastnik)
		{
			Ucet nalezenyUcet;
			slovnikUctu.TryGetValue(vlastnik, out nalezenyUcet);
			return nalezenyUcet;
		}

		// ulozi penize, pokud ucet existuje, a pokud je vklad zaporny, tak se nic neulozi, odolne proti neznamemu hackerovi
		public void UlozPenize(string vlastnik, double vklad)
		{
			Ucet nalezenyUcet;
			if (slovnikUctu.TryGetValue(vlastnik, out nalezenyUcet))
			{
				Console.WriteLine("Vklad na ucet: " + vlastnik + ", castka: " + vklad);
				nalezenyUcet.Zustatek += Math.Max(0, vklad); // osetreni, kdyby byl vklad zaporny	
			}
		}

		public void ZobrazInformaceOUctech()
		{
			string nadpis = "Informace o uctech";
			Console.WriteLine(nadpis);
			Console.WriteLine(new string('=', nadpis.Length));

			foreach (Ucet ucet in slovnikUctu.Values)
			{
				Console.WriteLine(ucet);
			}
		}
	}
}
