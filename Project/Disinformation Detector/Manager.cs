using System;
using System.Collections.Generic;
using System.Text;

namespace Disinformation_Detector
{
    class Manager
    {
        public Analyzer analyzer = new Analyzer();
        //public FileStorage Storage

        Dictionary<string, Article> Articles = new Dictionary<string, Article>(); //key URL
        Dictionary<string, Author> Authors = new Dictionary<string, Author>(); //key name
        Dictionary<string, Web> WebPages = new Dictionary<string, Web>(); //key domain       
        
        public Article ReadFromConsole()
        {
            Article article = UserInputReader.readInput();
            Articles.Add(article.Title, article);
            if (article.Author != null)
            {
                Authors.Add(article.Author.FirstName, article.Author);
            }
            if (article.Web != null)
            {
                WebPages.Add(article.Web.Domain, article.Web);
            }
            return article;
        }
        public double EvaluateScore(Article article)
        {
            return analyzer.EvaluateScore(article);
        }
    }
}
