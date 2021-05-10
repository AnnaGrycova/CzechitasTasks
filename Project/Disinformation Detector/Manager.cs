using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Disinformation_Detector
{
    class Manager
    {
        public Analyzer analyzer = new Analyzer();
        //public FileStorage Storage

        Dictionary<string, Article> Articles = new Dictionary<string, Article>(); //key URL
        Dictionary<string, Author> Authors = new Dictionary<string, Author>(); //key name
        Dictionary<string, Web> WebPages = new Dictionary<string, Web>(); //key domain 

        public Manager()
        {
            readFromCsv(WebPages);
        }
        public Article ReadFromConsole()
        {
            Article article = UserInputReader.readInput();
            Articles.Add(article.Title, article);
            if (article.Author != null)
            {
                Authors.Add(article.Author.FirstName, article.Author);
            }
            if (article.URL != null)
            {
                if (WebPages.ContainsKey(article.Domain))
                {
                    article.Web = WebPages[article.Domain];
                }
            }
            return article;
        }
        public double EvaluateScore(Article article)
        {
            return analyzer.EvaluateScore(article);
        }

        public void readFromCsv(Dictionary<string, Web> dictionaryOfQuestionableWeb)
        {
            var outPutDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string fileName = "WebPagesData.csv";

            using (TextFieldParser csvParser = new TextFieldParser(Path.Combine(outPutDirectory, fileName)))
            {
                csvParser.CommentTokens = new string[] { "#" };
                csvParser.SetDelimiters(new string[] { "," });
                csvParser.HasFieldsEnclosedInQuotes = false;

                while (!csvParser.EndOfData)
                {
                    string[] fields = csvParser.ReadFields();
                    Web web = new Web(fields[0], 10 - Double.Parse(fields[1], CultureInfo.InvariantCulture));
                    WebPages.Add(web.Domain, web);
                }
            }
        }
    }
}
