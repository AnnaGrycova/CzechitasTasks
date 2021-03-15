using System;

namespace Ukol1___Hvezdicky
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isNumber = false;
            int stars = 0;
            while (!isNumber)
            {
                Console.WriteLine("Zadej pocet hvezdicek.");
                string input = Console.ReadLine();
                isNumber = int.TryParse(input, out stars);
                if (!isNumber)
                {
                    Console.WriteLine($"{input} neni cislo.");
                }
            }
            
            for (int i = 0; i < stars; i++)
            {
                Console.Write("*");
            }
        }
    }
}
