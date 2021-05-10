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

            score += GetBodyScore(article);
            score += GetTitleScore(article);
            if (score > 1)
            {
                score = 1;
            }
            return score;
        }
        public double GetBodyScore(Article article)
        {
            double score = 0;
            score += CountUpperCaseWords(article.Body, 5);
            score += CountConsequentiveExclamationMarks(article.Body);
            score += CountExclamationMarks(article.Body, 15);
            score += CountManipulativePhrases(article.Body, 3);

            return score;
        }

        public double GetTitleScore(Article article)
        {
            double score = 0;
            score += CountUpperCaseWords(article.Body, 1);
            score += CountConsequentiveExclamationMarks(article.Body);
            score += CountExclamationMarks(article.Body, 2);
            score += CountManipulativePhrases(article.Body, 1);

            return score;
        }

        private double CountManipulativePhrases(string content, double threshold)
        {
            double score = 0;
            int count = ListOfPhrases.Count(s => content.ToLower().Contains(s));
            if (0 < count && count < threshold)
            {
                score += 0.1;
            }
            else if (count >= threshold)
            {
                score += 0.2;
            }
            return score;
        }

        private static double CountExclamationMarks(string content, double threshold)
        {
            double score = 0;
            int countOfExclamationMarks = content.Count(f => f == '!');
            if (countOfExclamationMarks > threshold)
            {
                score += 0.4;
            }

            return score;
        }

        private static double CountConsequentiveExclamationMarks(string content)
        {
            double score = 0;
            Match m = Regex.Match(content, @"!{2,}", RegexOptions.IgnoreCase);
            bool moreThanOneExclamationMark = m.Success;
            if (moreThanOneExclamationMark)
            {
                score += 0.4;
            }

            return score;
        }

        private static double CountUpperCaseWords(string content, double threshold)
        {
            double score = 0;
            int countOfUpWords = content.Split(' ')
            .Where(x => String.Equals(x, x.ToUpper(),
            StringComparison.Ordinal)).Count();
            if (countOfUpWords > threshold)
            {
                score += 0.2;
            }
            else if (countOfUpWords > threshold*2)
            {
                score += 0.4;
            }

            return score;
        }
    }
}
