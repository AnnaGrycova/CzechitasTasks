namespace Disinformation_Detector
{
    class URLScoring : IScoring
    {
        public double Weight { get; set; }

        public double GetScore(Article article)
        {
            double score = 0;
            if (!(article.Web is null))
            {
                if (article.Web.Credibility <= 2)
                {
                    score += 1;
                }
                else if (2 < article.Web.Credibility && article.Web.Credibility <= 4)
                {
                    score += 0.7;
                }
                else if (4 < article.Web.Credibility && article.Web.Credibility <= 7)
                {
                    score += 0.4;
                }
            }
            return score;
        }
    }
}
