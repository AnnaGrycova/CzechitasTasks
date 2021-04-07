using System;
using System.Collections.Generic;
using System.Text;

namespace dedicnost___ukol_z_hodiny
{
	// podedit z obecneho domaciho mazlicka
	public class Morce : DomaciMazlicek
	{
        // vytvorte konstruktor, ktery vytvori pejska, ulozi jeho jmeno
		public Morce(string jmeno)
		{
			Jmeno = jmeno;
		}

		// presunout do bazove tridy

		public override void Aportuj()
        {
			Console.WriteLine($"{this} je moc line morce na to, aby aportovalo.");
        }

		public override void UdelejTrik()
		{
			base.UdelejTrik();
			Console.WriteLine($"Morce {this} se svalilo na bok a usnulo.");
		}


	}
}
