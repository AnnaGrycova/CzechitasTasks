using System;

namespace Lekce_6___ukol_z_hodiny__dedicnost__abstrakce
{
    class Program
    {
        // Vytvořte abstraktní třídu PohadkovaBytost a v ní abstraktní metodu NapisJakTravisVolnyCas
        // Vytvorte tridy Princezna, Rytir, Carodenice, ktere dedi PohadkovouBytost
        // Naimplementujte metodu NapisJakTravisVolnyCas - vypsanemu textu na konzoli se meze nekladou
        // Vytvorte instance od kazde tridy a vypiste informace o trávení volného času.
        static void Main(string[] args)
        {
            Princezna princezna = new Princezna();
            PohadkovaBytost rytir = new Rytir();
            PohadkovaBytost carodejnice = new Carodejnice();

            princezna.NapisJakTravisVolnyCas();
            rytir.NapisJakTravisVolnyCas();
            carodejnice.NapisJakTravisVolnyCas();
        
        }
    }
}
