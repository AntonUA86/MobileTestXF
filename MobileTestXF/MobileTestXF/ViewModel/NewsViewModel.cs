using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileTestXF.Model;
using MobileTestXF.Services;
using MobileTestXF.View;
using Xamarin.Forms;
using News = MobileTestXF.Model.News;

namespace MobileTestXF.ViewModel
{
    public class NewsViewModel : BindableObject
    {
        private readonly INewsService _newsService;



        private ObservableCollection<News> _observableCollectionNews = new ObservableCollection<News>();
        public ObservableCollection<News> ObservableCollectionNews
        {
            get => _observableCollectionNews ;
            set
            {
                
                _observableCollectionNews = value;
                OnPropertyChanged();
            }
        }
        

        public ICommand NavigationToDetailNews { get; }


        public ICommand SearchCommand { get; }
  
        
        public  ICommand  TestCommand { get; }
        private News _selectedNews;

        public News SelectedNews
        {
            get => _selectedNews;
            set
            {
                _selectedNews = value;
                OnPropertyChanged();
            }
        }

        private string _searchText;

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

     
        public NewsViewModel()
        {

   
            _newsService = new NewsService();
            

            ObservableCollectionNews =
                new ObservableCollection<News>(ParserNews.GetNews());

            NavigationToDetailNews = new Command(async  () => await GetListview());

            SearchCommand = new Command(Test);

        

        }
       

        async Task GetListview()
        {
            await Application.Current.MainPage.Navigation.PushAsync(
                new DetailNews()
                {
                    BindingContext = new DetailNewsViewModel(SelectedNews.Title, SelectedNews.Author,
                        SelectedNews.PublishedAt, SelectedNews.UrlToImage, SelectedNews.Content, SelectedNews.Url)
                });
        }

        public void Test()
        {
  
            ObservableCollectionNews.Clear();
            ObservableCollectionNews = new ObservableCollection<News>(ParserNews.GetNewsSearch(SearchText));
        }
   
        
        private void SearchCommandExecute()
        {
       
          var tempRecords = ParserNews.GetNewsSearch(SearchText);
          if (SearchText.Length >= 3)
          {
              ObservableCollectionNews.Clear();
              var responseNews = ObservableCollectionNews.Where(c => c.Title.ToLower().Contains(SearchText.ToLower())).ToList();
              foreach (var news in responseNews)
                  ObservableCollectionNews.Add(news);
          }


        }
     
    }
}