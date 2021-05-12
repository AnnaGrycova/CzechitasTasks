#nullable enable
using System;


namespace Disinformation_Detector
{
    class Article
    {
        public string? Title { get; set; }
        public string Body { get; set; }
        public DateTime? PublishedOn { get; set; }
        public Author? Author { get; set; }
        public Uri URL { get; set; }
        public Web? Web { get; set; }
        public string Domain
        {
            get
            {
                if (URL.Host.ToLower().StartsWith("www"))
                    {
                    return URL.Host.Substring(4);
                    }
                return URL.Host;
            }
        }
        

        public Article (string title, string body, DateTime? publishedOn, Author author, string url)
        {
            Title = title;
            Body = body;
            PublishedOn = publishedOn;
            Author = author;
            URL = new Uri(url);
        }
       
    }
}
