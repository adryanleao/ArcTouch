using Prism;
using Prism.Ioc;
using ArcTouch.ViewModels;
using ArcTouch.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using ArcTouch.Model;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ArcTouch
{
    public partial class App
    {
        public static List<Category> Categories = new List<Category>();
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) {
        }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var url = $"/RootPage/NavigationPage/ListMoviePage/";
            await NavigationService.NavigateAsync(url);
            
            
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<RootPage>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<ListMoviePage, ListMoviePageViewModel>();
            containerRegistry.RegisterForNavigation<LanguagePage, LanguagePageViewModel>();
            containerRegistry.RegisterForNavigation<MovieViewPage, MovieViewPageViewModel>();
        }
    }
}
