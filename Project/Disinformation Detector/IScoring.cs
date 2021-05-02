﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Disinformation_Detector
{
    interface IScoring
    {
        const int Weight = 1;
        double GetScore(Article article);
    }
}
