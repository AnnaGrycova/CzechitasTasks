using System;
using System.Collections.Generic;
using System.Text;

namespace dedicnost___ukol_z_hodiny
{
	public abstract class DomaciMazlicek	
	{
		public string Jmeno { get; protected set; }

        public DomaciMazlicek()
        {

        }

		public virtual void NakrmSe()
		{
			Console.WriteLine(Jmeno + ": nakrmen");
		}

		public virtual void UdelejTrik()
		{
			Console.WriteLine($"Priprava na trik...");
		}

		public abstract void Aportuj();


        public override string ToString()
        {
			return Jmeno;
        }

    }
}
