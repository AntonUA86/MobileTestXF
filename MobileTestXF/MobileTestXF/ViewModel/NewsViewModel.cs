using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileTestXF.Services;
using MobileTestXF.View;
using Prism.Navigation;
using Xamarin.Forms;
using News = MobileTestXF.Model.News;

namespace MobileTestXF.ViewModel
{
    public class NewsViewModel : BindableObject
    {
        private readonly INewsService _newsService;
        private readonly INavigationService _navigationService;

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

        public NewsViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            ObservableCollectionNews = new ObservableCollection<News>();

            NavigationToDetailNews = new Command(async  () => await GetListview());

            SearchCommand = new Command(async () => await LoadDataSearchResult());

            GetDataCommand = new Command(LoadData);
            GetDataCommand.Execute(null);

        }

        private async Task LoadDataSearchResult()
        {
            var result = await _newsService.GetNewsBySearchAsync(SearchText);
            ObservableCollectionNews.Clear();
            foreach (var news in result)
                ObservableCollectionNews.Add(news);
        }

        private void LoadData()
        {
           var result =  Enumerable.Range(1, 20).Select(i => new News
           {
               Title = "Vasy",
               Content = "Hello Vasy"
           });

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