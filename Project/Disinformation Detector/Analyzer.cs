using System;
using System.Collections.Generic;
using System.Text;

namespace Disinformation_Detector
{
    class Analyzer
    {
        List<IScoring> ScoringTypes = new List<IScoring>();
        public float EvaluateScore(Article article) //iteration through scoring types
        {
            return 0;
        }
    }
}
