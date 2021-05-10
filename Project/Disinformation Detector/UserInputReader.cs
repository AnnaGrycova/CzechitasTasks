using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Globalization;
using System.IO;
using HtmlAgilityPack;
using System.Web;

namespace Disinformation_Detector
{
    static class UserInputReader
    {
        public static Article readInput()
        {
            string authorFirstName = UserInputReader.ReadOptional("Insert an author's first name (Insert 'not mentioned' if author is not mentioned):");
            string authorLastName = UserInputReader.ReadOptional("Insert an author's last name (Insert 'not mentioned' if author is not mentioned):");
            string url = UserInputReader.ReadMandatory("Insert a URL:", UserInputValidator.IsUrl);
            string title = UserInputReader.ReadOptional("Insert a title:");
            string body;
            using (var wc = new System.Net.WebClient())
                body = wc.DownloadString(url);
            body = SanitizeHtml(body);
            body = RemoveDiacritics(body);
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
            string answer;
            bool answerIsValid;
            do
            {
                answer = Console.ReadLine();
                answerIsValid = answer.ToLower() == "yes" || answer.ToLower() == "no" || String.IsNullOrEmpty(answer);
                if (!answerIsValid)
                {
                    Console.WriteLine("Answer is not valid");
                    Console.WriteLine("Do you want to leave this field blank? [yes]/no");
                }
            } while (!answerIsValid);
            return answer.ToLower() == "yes" || String.IsNullOrEmpty(answer);
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

        static string RemoveDiacritics(string text)
        {
            //if (string.IsNullOrWhiteSpace(text))
            //    return text;
            text = text.Normalize(NormalizationForm.FormD);
            var chars = text.Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark).ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC);
        }

        static string SanitizeHtml(string data)
        {
            //https://stackoverflow.com/a/12836974
            if (string.IsNullOrEmpty(data)) return string.Empty;

            var document = new HtmlDocument();
            document.LoadHtml(data);

            var acceptableTags = new String[] { "a" };

            var nodes = new Queue<HtmlNode>(document.DocumentNode.SelectNodes("./*|./text()"));
            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                var parentNode = node.ParentNode;

                if (!acceptableTags.Contains(node.Name) && node.Name != "#text")
                {
                    var childNodes = node.SelectNodes("./*|./text()");
                    if (childNodes != null)
                    {
                        foreach (var child in childNodes)
                        {
                            nodes.Enqueue(child);
                            parentNode.InsertBefore(child, node);
                        }
                    }
                    parentNode.RemoveChild(node);
                }
            }
            return document.DocumentNode.InnerHtml;
        }
    }
}
