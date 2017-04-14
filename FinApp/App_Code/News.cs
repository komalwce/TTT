using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for News
/// </summary>
public class News
{
        public string status { get; set; }
        public string source { get; set; }
        public string sortBy { get; set; }
        public Article[] articles { get; set; } 
}
public class Article
{
    public string author { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public string url { get; set; }
    public string urlToImage { get; set; }
    public DateTime publishedAt { get; set; }
}
