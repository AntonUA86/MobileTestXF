using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileTestXF.Model;
using Xamarin.Forms;




namespace MobileTestXF.ViewModel
{
    public class DetailNewsViewModel : BindableObject
    {
        public ICommand GoToURL { get; }
        public DetailNewsViewModel(string title, string author, string publishedAt, string urlToImage,string content, string url)
        {
            Title = title;
            Content = content;
            Author = author;
            PublishedAt = publishedAt;
            UrlToImage = urlToImage;
            Url = url;
            GoToURL = new Command(OnWeb);
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
                if (_title == value) return;
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
                if (_content == value) return;
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
                if (_author == value) return;
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
                if (_publishedAt == value) return;
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
                if (_urlToImage == value) return;
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
                if (_url == value) return;
                _url = value;
                OnPropertyChanged();
            }
        }
    }
}