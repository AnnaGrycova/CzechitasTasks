using System;
using System.Collections.Generic;
using System.Text;

namespace Disinformation_Detector
{
    class Manager
    {
        public Analyzer Analyzer;
        //public FileStorage Storage;

        Dictionary<string, Article> Articles = new Dictionary<string, Article>(); //key URL
        Dictionary<string, Author> Authors = new Dictionary<string, Author>(); //key name
        Dictionary<string, Web> WebPages = new Dictionary<string, Web>(); //key domain       
        
        public float EvaluateScore(Article article)
        {
            return 0;
        }
    }
}
