using System;

namespace dedicnost___ukol_z_hodiny
{
	public class Program
	{
		static void Main(string[] args)
		{
			Morce morce = new Morce("Premek");
			Demagorgon demagorgon = new Demagorgon("Franta");

			morce.Aportuj();
			demagorgon.Aportuj();

			morce.NakrmSe();
			demagorgon.NakrmSe();

			morce.UdelejTrik();
			demagorgon.UdelejTrik();
		}
	}
}
