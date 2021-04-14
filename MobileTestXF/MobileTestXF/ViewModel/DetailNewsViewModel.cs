using MobileTestXF.Model;
using Xamarin.Forms;

namespace MobileTestXF.ViewModel
{
    public class DetailNewsViewModel : BindableObject
    {
        public DetailNewsViewModel(string title, string author, string publishedAt, string urlToImage,string content)
        {
            Title = title;
            Content = content;
            Author = author;
            PublishedAt = publishedAt;
            UrlToImage = urlToImage;
        }


        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                if (title != value)
                {
                    title = value;
                    OnPropertyChanged();
                }
            }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set
            {
                if (content != value)
                {
                    content = value;
                    OnPropertyChanged();
                }
            }
        }

        private string author;

        public string Author
        {
            get { return author; }
            set
            {
                if (author != value)
                {
                    author = value;
                    OnPropertyChanged();
                }
            }
        }

        private string publishedAt;

        public string PublishedAt
        {
            get { return publishedAt; }
            set
            {
                if (publishedAt != value)
                {
                    publishedAt = value;
                    OnPropertyChanged();
                }
            }
        }

        private string urlToImage;

        public string UrlToImage
        {
            get { return urlToImage; }
            set
            {
                if (urlToImage != value)
                {
                    urlToImage = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}