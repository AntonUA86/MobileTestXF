using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MobileTestXF.Model;
using MobileTestXF.View;
using Xamarin.Forms;
using News = MobileTestXF.Model.News;

namespace MobileTestXF.ViewModel
{
    public class NewsViewModel : BindableObject
    {
        public ObservableCollection<News> ObservableCollectionNews { get; set; } 
        
        public ICommand NavigationToDetailNews { get; }
        
        public ICommand SearchCommand { get; }

       
        
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

        private string _text;

        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged();
            }
        }
        

        public NewsViewModel()
            
        {
     
            ObservableCollectionNews = new ObservableCollection<News>(ParserNews.GetNews());
            
            NavigationToDetailNews = new Command(async  () => await GetListview());

            SearchCommand = new Command(SearchCommandExecute);

        }


        async Task GetListview()
        {
            await Application.Current.MainPage.Navigation.PushAsync(
                new DetailNews()
                {
                    BindingContext = new DetailNewsViewModel(SelectedNews.Title, SelectedNews.Author,
                        SelectedNews.PublishedAt, SelectedNews.UrlToImage, SelectedNews.Content)
                });
        }
        
        private void SearchCommandExecute()
        {
            var tempRecords = ObservableCollectionNews.Where(c=>c.Author.Contains(Text));
            ObservableCollectionNews = new ObservableCollection<News>(tempRecords);
            
        }
  
        
      
      
      
   
        
        
    }
}