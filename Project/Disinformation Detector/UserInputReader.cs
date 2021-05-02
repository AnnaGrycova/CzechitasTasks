using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;

namespace Disinformation_Detector
{
    static class UserInputReader
    {
        public static Article readInput()
        {
            string authorFirstName = UserInputReader.ReadOptional("Insert an author's first name:");
            string authorLastName = UserInputReader.ReadOptional("Insert an author's last name:");
            string title = UserInputReader.ReadOptional("Insert a title:");
            string url = UserInputReader.ReadOptional("Insert a URL:", UserInputValidator.IsUrl);
            string domain;
            if (!String.IsNullOrEmpty(url))
            {
                Uri myUri = new Uri(url);
                domain = myUri.Host;
                Web web = new Web(domain);
            }
            string body = UserInputReader.ReadMandatory("Insert a body of article:", UserInputValidator.IsNotNullOrEmpty);
            string publishedOnInput = UserInputReader.ReadOptional("Insert a date article was published (DD.MM.YYYY or MM.YYYY):", UserInputValidator.IsEmptyOrDateTime);
            DateTime? publishedOn = null;
            if (!String.IsNullOrEmpty(publishedOnInput))
            {
                publishedOn = DateTime.Parse(publishedOnInput);
            }
            Author author = new Author(authorFirstName, authorLastName);
            Article article = new Article(title, body, publishedOn, author, url);
            return article;
        }

        public static string ReadOptional(string message)
        {
            string input;
            do
            {
                input = UserInputReader.ReadInput(message);
            } while (String.IsNullOrEmpty(input) && !UserInputReader.UserAllowsEmpty());
            return input;
        }
        private static bool UserAllowsEmpty()
        {
            Console.WriteLine("Do you want to leave this field blank? [yes]/no");
            string answer = Console.ReadLine();
            return answer.ToLower() == "yes" || answer.ToLower() == "y" || String.IsNullOrEmpty(answer);
        }
        private static string ReadInput(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static string ReadMandatory(string message, Func<string, bool> isValid)
        {
            string input;
            bool inputIsValid;
            do {
                input = UserInputReader.ReadInput(message);
                inputIsValid = isValid(input);
                if (!inputIsValid)
                {
                    Console.WriteLine("Input is not valid. Please, try it again.");
                }
            } while (!inputIsValid);            
            return input;
        }

        public static string ReadOptional (string message, Func<string, bool> isValid)
        {
            bool inputIsValid;
            string input;
            do
            {
            input = UserInputReader.ReadOptional(message);
            if (String.IsNullOrEmpty(input))
                {
                    break;
                }
                inputIsValid = isValid(input);
                if (!inputIsValid)
                {
                    Console.WriteLine("Input is not valid. Please, try it again.");
                }
            } while(!inputIsValid);
            return input;
        }

        static string RemoveDiacritics(this string text)
        {
            //if (string.IsNullOrWhiteSpace(text))
            //    return text;
            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }
    }
}
