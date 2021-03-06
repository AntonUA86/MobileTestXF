using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using MobileTestXF.View;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MobileTestXF.Model
{
    public class ParserNews
    {
        public static List<News> GetNews()
        {
            var listNews = new List<News>();
            var url =
                "https://newsapi.org/v2/everything?q=BBC&from=2021-04-13&sortBy=popularity&apiKey=713404e7bc6e4e7aaccdd71b86faefb2";

            using (WebClient client = new WebClient())
            {
                var response = client.OpenRead(url);
                using (var reader = new StreamReader(response))
                {
                    var data = JObject.Parse(reader.ReadLine())["articles"];
                    var feed = JsonConvert.DeserializeObject<IEnumerable<News>>(data.ToString());
                    listNews.AddRange(feed.ToArray());
                    return listNews;
                }
            }

            return listNews;
        }
       
        public static List<News> GetNewsSearch(string text)
        {
          
            var listNews = new List<News>();
            var url =
                $"https://newsapi.org/v2/everything?q={text}&from=2021-04-13&sortBy=popularity&apiKey=713404e7bc6e4e7aaccdd71b86faefb2";

            using (WebClient client = new WebClient())
            {
                var response = client.OpenRead(url);
                using (var reader = new StreamReader(response))
                {
                    var data = JObject.Parse(reader.ReadLine())["articles"];
                    foreach (var info in data)
                    {
                        listNews.Add(new News
                        {
                            Title = info["title"].Value<string>(),
                            Author = info["author"].Value<string>(),
                            PublishedAt = info["publishedAt"].Value<string>(),
                            UrlToImage = info["urlToImage"].Value<string>(),
                            Content = info["content"].Value<string>()
                        });
                    }
                }
            }

            return listNews;
        }
    }
}