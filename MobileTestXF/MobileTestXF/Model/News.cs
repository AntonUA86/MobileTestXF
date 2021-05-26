using Newtonsoft.Json;

namespace MobileTestXF.Model
{
    public class News
    {
        [JsonProperty("url")]
        public  string Url { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("publishedAt")]
        public string PublishedAt { get; set; }

        [JsonProperty("urlToImage")]
        public string UrlToImage { get; set; }

        [JsonProperty("content")]
        public  string Content { get; set; }

    }
}