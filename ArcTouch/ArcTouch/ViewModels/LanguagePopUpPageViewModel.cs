using Prism.Navigation;

namespace ArcTouch.ViewModels
{
	public class LanguagePopUpPageViewModel : ViewModelBase
    {
        INavigationService _navigationService { get; }
        public LanguagePopUpPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            OnNavigateCommandExecuted();
        }

        private async void OnNavigateCommandExecuted()
        {
            await _navigationService.NavigateAsync("LanguagePopUpPage");
        }
    }
}
