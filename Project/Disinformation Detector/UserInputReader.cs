using System;
using System.Collections.Generic;
using System.Text;

namespace Disinformation_Detector
{
    static class UserInputReader
    {
        public static Article readInput()
        {
            string authorFirstName = UserInputReader.Read("Insert an author's first name:");
            string authorLastName = UserInputReader.Read("Insert an author's last name:");
            string title = UserInputReader.Read("Insert a title:");
            string url = UserInputReader.Read("Insert a URL:", UserInputValidator.IsUrl);
            string body = UserInputReader.Read("Insert a body of article:", UserInputValidator.IsNotNullOrEmpty);
            string publishedOnInput = UserInputReader.Read("Insert a date article was published (DD.MM.YYYY):", UserInputValidator.IsEmptyOrDateTime);
            DateTime? publishedOn = null;
            if (String.IsNullOrEmpty(publishedOnInput))
            {
                publishedOn = DateTime.Parse(publishedOnInput);
            }
            Author author = new Author(authorFirstName, authorLastName);
            Article article = new Article(title, body, publishedOn, author, url);
            return article;
        }

        public static string Read(string message)
        {
            Console.WriteLine(message);            
            return Console.ReadLine();
        }

        public static string Read(string message, Func<string, bool> isValid)
        {
            Console.WriteLine(message);
            string input;
            bool inputIsValid;
            do
            {
                input = Console.ReadLine();
                inputIsValid = isValid(input);
                if (!inputIsValid)
                {
                    Console.WriteLine("Input is not valid. Please, try it again.");
                }

            } while (!inputIsValid);            
            return input;
        }
    }
}
