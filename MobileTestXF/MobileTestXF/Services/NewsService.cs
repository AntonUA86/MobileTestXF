using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MobileTestXF.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MobileTestXF.Services
{
    public  class NewsService : INewsService
    {
        public async Task<IEnumerable<News>> GetAllNewsAsync()
        {
            string url = "https://newsapi.org/v2/everything?q=microsoft&from=2021-04-26&sortBy=publishedAt&apiKey=7bf0c6a6007c439491f6f4f84a6f02fc";

            using (var client = new HttpClient())
            {
                var listNews = new List<News>();
                var response = await client.GetAsync(url);
                var results = JObject.Parse(await
                    response.Content.ReadAsStringAsync())["articles"];
                var feed = JsonConvert.DeserializeObject<IEnumerable<News>>(results.ToString());
                listNews.AddRange(feed.ToArray());
                return listNews;
            }
        }

        public async  Task<IEnumerable<News>> GetNewsBySearchAsync(string request)
        {
            var url =
                $"https://newsapi.org/v2/everything?q={request}&from=2021-04-13&sortBy=popularity&apiKey=7bf0c6a6007c439491f6f4f84a6f02fc";

            using (var client = new HttpClient())
            {
                var listNews = new List<News>();
                var response = await client.GetAsync(url);
                var results = JObject.Parse(await
                    response.Content.ReadAsStringAsync())["articles"];
                var feed = JsonConvert.DeserializeObject<IEnumerable<News>>(results.ToString());
                listNews.AddRange(feed.ToArray());
                return listNews;
            }
        }
    }
}








