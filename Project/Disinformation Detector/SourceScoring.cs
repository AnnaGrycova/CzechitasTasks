using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Disinformation_Detector
{
    class SourceScoring : IScoring
    {
        public double Weight { get; set; }
        List<string> domainBlacklist = new List<string>()
        {
            "facebook", "instagram", "twitter", "youtube",
        };        
        public double GetScore(Article article)
        {
            List<string> domainBlacklistCopy = new List<string>(domainBlacklist);
            domainBlacklistCopy.Add(article.Domain);
            double score = 0;
            string body = article.Body;
            foreach (string domain in domainBlacklistCopy)
            {
                body = Regex.Replace(body, @"https?:\/\/([a-z]+\.|)" + domain, "");
            }
            int occurences = body
                                 .Split(new[] { "http://", "https://", "isbn" }, StringSplitOptions.None)
                                 .Count() - 1;

            if (occurences == 0)
            {
                score += 0.1;
            }
            return 0;
        }
    }
}
