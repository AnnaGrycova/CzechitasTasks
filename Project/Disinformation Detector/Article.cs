using System;
using System.Collections.Generic;
using System.Text;

namespace Disinformation_Detector
{
    class Article
    {
        public string? Title { get; set; }
        public string Body { get; set; } //optional in case URL is inserted and article will be downloaded
        public DateTime? PublishedOn { get; set; }
        public Author? Author { get; set; }
        public Uri? URL { get; set; }
        public Web? Web { get; set; }
        public string? Domain
        {
            get
            {
                if (URL is null)
                {
                    return null;
                }
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
            if (!String.IsNullOrEmpty(url))
            {
                URL = new Uri(url);
            }            
        }
       
    }
}
