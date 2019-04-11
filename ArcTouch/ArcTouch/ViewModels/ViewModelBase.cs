using Prism.Mvvm;
using Prism.Navigation;

namespace ArcTouch.ViewModels
{
    public class ViewModelBase : BindableBase
    {
        protected INavigationService NavigationService { get; private set; }

        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _language;
        public string Language
        {
            get { return _language; }
            set { SetProperty(ref _language, value); }
        }

        public ViewModelBase(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
