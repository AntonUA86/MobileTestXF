using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace MobileTestXF.ViewModel
{
    public class DetailNewsViewModel : BindableObject
    {
        private ICommand GoToUrl { get; }

        public DetailNewsViewModel(string title, string author, string publishedAt, string urlToImage,string content, string url)
        {
            Title = title;
            Content = content;
            Author = author;
            PublishedAt = publishedAt;
            UrlToImage = urlToImage;
            Url = url;
            GoToUrl = new Command(OnWeb);
        }

        private void OnWeb()
        {
            Device.OpenUri(new Uri(Url));
        }

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _content;

        public string Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }

        private string _author;

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                OnPropertyChanged();
            }
        }

        private string _publishedAt;

        public string PublishedAt
        {
            get => _publishedAt;
            set
            {
                _publishedAt = value;
                OnPropertyChanged();
            }
        }

        private string _urlToImage;

        public string UrlToImage
        {
            get => _urlToImage;
            set
            {
                _urlToImage = value;
                OnPropertyChanged();
            }
        }
        private string _url;

        public string Url
        {
            get => _url;
            set
            {
                _url = value;
                OnPropertyChanged();
            }
        }
    }
}