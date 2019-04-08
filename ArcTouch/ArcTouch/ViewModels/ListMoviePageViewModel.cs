using Prism.Navigation;

namespace ArcTouch.ViewModels
{
	public class ListMoviePageViewModel : ViewModelBase
    {
        INavigationService _navigationService { get; }
        public ListMoviePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this._navigationService = navigationService;
        }
    }
}
