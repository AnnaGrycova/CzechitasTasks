using System;
using System.Collections.Generic;
using System.Text;

namespace Disinformation_Detector
{
    class AuthorScoring : IScoring
    {
        public double Weight { get; set; }
        
        List<Author> ListOfQuestionableAuthors = new List<Author>()
        {
            new Author("Jan", "Hnizdil"),
            new Author("Michal", "Hasek"),
            new Author("Jana", "Peterkova"),
            new Author("Jana", "Peterka"),
            new Author("Jiri", "Cernohorsky"),
            new Author("Filip", "Vavra"),
            new Author("Robert", "Smuk"),
            new Author("Pavel", "Zitko"),
            new Author("Ondrej", "Neff"),
            new Author("Ondrej", "Hoppner"),
            new Author("not mentioned", "not mentioned"),
        };
        public double GetScore(Article article)
        {
            double score = 0;
            if (ListOfQuestionableAuthors.Contains(article.Author))
            {
                score += 1;
            }
            return score;            
        }
    }
}
