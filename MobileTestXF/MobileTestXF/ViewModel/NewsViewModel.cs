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
        private NewsService _newsService = new NewsService();


        private ObservableCollection<News> _observableCollectionNews;
        public ObservableCollection<News> ObservableCollectionNews
        {
            get => _observableCollectionNews ;
            set
            {
                
                _observableCollectionNews = value;
                OnPropertyChanged();
            }
        }

        #region Command 
        public ICommand NavigationToDetailNews { get; }


        public ICommand SearchCommand { get; }
  
        
        public  ICommand  GetDataCommand { get; }
        #endregion

        #region Properties

        #region SelectedNews
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
        #endregion
        #region SearchText
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

        #endregion
        

        #endregion



     
        public NewsViewModel()
        {
            ObservableCollectionNews =
                new ObservableCollection<News>();
            
            NavigationToDetailNews = new Command(async  () => await GetListview());

            SearchCommand = new Command(async () => await LoadDataSearchResult());

            GetDataCommand = new Command(async () => await LoadData());
            GetDataCommand.Execute(null);
   

        }

        private async Task LoadDataSearchResult()
        {
            var result = await _newsService.GetNewsBySearchAsync(SearchText);
            ObservableCollectionNews.Clear();    
            foreach (var news in result)
                ObservableCollectionNews.Add(news);
        } 
        

        private async Task LoadData()
        {
           var result = await _newsService.GetAllNewsAsync();
     
           foreach (var news in result)
               ObservableCollectionNews.Add(news);
          
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
        
    }
}