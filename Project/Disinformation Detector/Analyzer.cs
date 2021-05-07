using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Disinformation_Detector
{
    class Analyzer
    {
        List<IScoring> ScoringTypes = new List<IScoring>()
        {
            new AuthorScoring { Weight = 0.4 },
            new ContentScoring { Weight = 1 },
            new SourceScoring { Weight = 0.8 },
            new URLScoring { Weight = 0.8 }
        };
        public double EvaluateScore(Article article) //iteration through scoring types
        {
            double totalScore = 0;
            foreach (IScoring scoring in ScoringTypes)
            {
                double score = scoring.GetScore(article);
                totalScore += score / ScoringTypes.Count;
            }
            return totalScore;
        }
    }
}
