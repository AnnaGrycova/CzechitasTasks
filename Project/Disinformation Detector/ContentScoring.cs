using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Disinformation_Detector
{
    class ContentScoring : IScoring
    {
        public double Weight { get; set; }
        List<string> ListOfPhrases = new List<string>()
            {
                "odhaleni",
                "lez",
                "pravda",
                "konecne pravda",
                "exkluzivne",
                "sdilejte",
                "smazou",
                "zatajuji",
                "dukazy",
                "lzi",
                "skryta pravda",
                "protivlastenecke sily",
                "slunickari",
                "vitaci",
                "novy svetovy rad",
                "soros",
                "iluminati",
                "chemtrails",
                "homosexualni lobby",
                "spiknuti",
                "zeme je placata",
                "placata",
                "rousky jsou zdravi skodlive",
                "podvod",
                "covid je podvod",
            };
        public double GetScore(Article article)
        {
            double score = 0;
            int countOfUpWords = article.Body.Split(' ')
            .Where(x => String.Equals(x, x.ToUpper(),
            StringComparison.Ordinal)).Count();
            if (countOfUpWords > 5)
            {
                score += 0.2;
            }
            else if (countOfUpWords > 10)
            {
                score += 0.4;
            }
           
            Match m = Regex.Match(article.Body, @"!{2,}", RegexOptions.IgnoreCase);
            bool moreThanOneExclamationMark = m.Success;
            if (moreThanOneExclamationMark)
            {
                score += 0.5;
            }

            int countOfExclamationMarks = article.Body.Count(f => f == '!');
            if (countOfExclamationMarks > 15)
            {
                score += 0.3;
            }            

            int count = ListOfPhrases.Count(s => article.Body.ToLower().Contains(s));
            if (0 < count  && count < 3)
            {
                score += 0.1;
            }
            else if (count >= 3)
            {
                score += 0.2;
            }
            if (score > 1)
            {
                score = 1;
            }
            return score;
        }
    }
}
