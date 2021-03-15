using System;

namespace Ukol1_Soucet_cisel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert the first number.");
            int firstNumber = NumberValidation();
            Console.WriteLine("Insert the second number.");
            int secondNumber = NumberValidation();
            Console.WriteLine($"{firstNumber} + {secondNumber} = {firstNumber + secondNumber}");         
        }

        private static int NumberValidation()
        {
            bool isNumber;
            int number;
            do
            {
                isNumber = int.TryParse(Console.ReadLine(), out number);
                if (!isNumber)
                {
                    Console.WriteLine("Input is not a number.");
                }
            }
            while (!isNumber);
            return number;
        }
    }
}
