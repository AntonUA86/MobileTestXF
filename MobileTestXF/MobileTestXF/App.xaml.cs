using MobileTestXF.View;
using MobileTestXF.ViewModel;
using Prism.Ioc;
using Prism.Plugin.Popups;

namespace MobileTestXF
{
    public partial class App
    {
        public App()
        {
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

           await NavigationService.NavigateAsync(nameof(NewsPage));
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NewsPage, NewsViewModel>();
        }
    }
}