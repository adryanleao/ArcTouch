using Prism;
using Prism.Ioc;
using ArcTouch.ViewModels;
using ArcTouch.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Plugin.Popups;
using ArcTouch.Views.PopUp;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ArcTouch
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            
            string language = ArcTouch.Helpers.Settings.Language;
            var url = $"/RootPage/NavigationPage/ListMoviePage?lang={language}";
            await NavigationService.NavigateAsync(url);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterPopupNavigationService();
            containerRegistry.RegisterForNavigation<RootPage>();
            containerRegistry.RegisterForNavigation<MenuPage, MenuPageViewModel>();
            containerRegistry.RegisterForNavigation<ListMoviePage, ListMoviePageViewModel>();
            containerRegistry.RegisterForNavigation<LanguagePopUpPage, LanguagePopUpPageViewModel>();
        }
    }
}
