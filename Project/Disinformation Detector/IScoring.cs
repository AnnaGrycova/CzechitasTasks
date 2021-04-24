using System;
using System.Collections.Generic;
using System.Text;

namespace Disinformation_Detector
{
    interface IScoring
    {
        const int Weight = 1;
        float GetScore(Article article);
    }
}
