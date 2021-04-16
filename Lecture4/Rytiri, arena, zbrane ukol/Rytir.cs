using System;
using System.Collections.Generic;
using System.Text;

namespace Rytiri__arena__zbrane_ukol
{
	class Rytir
	{
		public Zbran Zbran { get; private set; } = Zbran.Mec;

		private string jmeno;
		public string Jmeno
		{
			get
			{
				return jmeno;
			}
			private set
			{
				jmeno = value;
			}
		}
		public int Zdravi { get; private set; }
		public int Sila { get; private set; }
		public int Brneni { get; private set; }
		public bool JeZivy
		{
			get
			{
				return Zdravi > 0;
			}
		}

		public Rytir(string jmeno, int sila, int zdravi = 100, int brneni = 100)
		{
			this.Jmeno = jmeno;
			this.Sila = sila <= 10 ? 10 : sila;
			//if (sila <= 10)
			//{
			//    Sila = 10;
			//}
			//else
			//{
			//    Sila = sila;
			//}

			Zdravi = zdravi;
			Brneni = brneni;
		}

		public void UtocNa(Rytir obet)
		{
			int silaUtoku = this.DejSiluUtoku();
			int poskozeni = obet.DejPoskozeniUtokem(silaUtoku);
			obet.Zdravi -= poskozeni;
		}

		private int DejSiluUtoku()
		{
			return this.Sila;
		}

		private int DejPoskozeniUtokem(int silaUtoku)
		{
			return silaUtoku;
		}
	}
}
