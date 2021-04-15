using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MobileTestXF.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MobileTestXF.Services
{
    public class NewsService : INewsService
    {
        public async Task<IEnumerable<News>> GetAllNewsAsync()
        {
            
            var  listNews = new List<News>();
            var url = "https://newsapi.org/v2/everything?q=Apple&from=2021-04-13&sortBy=popularity&apiKey=713404e7bc6e4e7aaccdd71b86faefb2";
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                var results = JObject.Parse(await
                    response.Content.ReadAsStringAsync())["articles"];
                var feed = JsonConvert.DeserializeObject<IEnumerable<News>>(results.ToString());
                listNews.AddRange(feed.ToArray());
            }
            return listNews;
        }

        public Task<IEnumerable<News>> GetNewsBySearchAsync(string request)
        {
            throw new System.NotImplementedException();
        }
    }
}