using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disinformation_Detector
{
    class Analyzer
    {
        List<IScoring> ScoringTypes = new List<IScoring>() //TODO: use weights of variables
        {
            new AuthorScoring { Weight = 0.4 },
            new ContentScoring { Weight = 1 },
            new SourceScoring { Weight = 0.8 },
            new URLScoring { Weight = 0.8 }
        };
        public void EvaluateScore(Article article) //iteration through scoring types
        {
            double totalScore = 0;
            foreach (IScoring scoring in ScoringTypes)
            {
                double score = scoring.GetScore(article);
                totalScore += score / ScoringTypes.Count;
            }

            if (totalScore == 0)
            {
                Console.WriteLine($"Disinformation score: {totalScore}. This is is probably not a disinformation.");
            }
            if (totalScore > 0.1 && totalScore <= 0.3)
            {
                Console.Write($"Disinformation score: {totalScore}. There is a low chance that this is a disinformation.");
            }
            if (totalScore > 0.3 && totalScore <= 0.8)
            {
                Console.Write($"Disinformation score: {totalScore}. There is a higher chance that this is a disinformation.");
            }
            if (totalScore > 0.8)
            {
                Console.Write($"Disinformation score: {totalScore}. This is most probably a disinformation.");
            }            
        }
    }
}
