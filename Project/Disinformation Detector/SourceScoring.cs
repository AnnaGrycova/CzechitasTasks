using System;
using System.Collections.Generic;
using System.Text;

namespace Disinformation_Detector
{
    class SourceScoring : IScoring
    {
        public double Weight { get; set; }
        public double GetScore(Article article)
        {
            return 0;
        }
    }
}
