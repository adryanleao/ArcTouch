using ArcTouch.Data;
using ArcTouch.Data.Interfaces;
using ArcTouch.Event;
using ArcTouch.Model;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;
using Refit;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ArcTouch.ViewModels
{
    public class ListMoviePageViewModel : ViewModelBase, INavigationAware, IDestructible
    {
        public DelegateCommand<string> ItemTappedCommand { get; set; }
        public ObservableCollection<Movie> MoviesList { get; set; }
        // public DelegateCommand MoviesList { get; set; }
        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        public ListMoviePageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
            : base(navigationService)
        {
            this.MoviesList = new ObservableCollection<Movie>();
            this._navigationService = navigationService;
            this._eventAggregator = eventAggregator;

            eventAggregator.GetEvent<CategoryChoosed>().Subscribe(async item =>
            {
                var movies = RestService.For<IRestApi>(EndPoints.BaseUrl);
                var moviesList = await movies.MoviesList(item, Helpers.Settings.Language);

                foreach (var movie in moviesList.results)
                {
                    Movie mv = new Movie();

                    mv.id = movie.id;
                    mv.genre_ids = movie.genre_ids;
                    mv.poster_path = "https://image.tmdb.org/t/p/w200" + movie.poster_path;
                    mv.release_date = movie.release_date;
                    mv.title = movie.title;
                    foreach (var j in mv.genre_ids)
                    {
                        mv.genres += App.Categories.Where(w => w.id == j).FirstOrDefault().name + "-";
                    }

                    mv.genres = mv.genres.Remove(mv.genres.Length - 1);

                    MoviesList.Add(mv);
                }
            });

            this.ItemTappedCommand = new DelegateCommand<string>((codeMovie) =>
            {
                var movie = MoviesList.Where(mv => mv.id == Convert.ToUInt32(codeMovie)).FirstOrDefault();
                NavigationService.NavigateAsync($"MovieViewPage?id={movie.id}&gen={movie.genres}&date={movie.release_date}&title={movie.title}", useModalNavigation: true);
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            this.Language = Helpers.Settings.Language;
            if (string.IsNullOrEmpty(this.Language))
            {
                NavigationService.NavigateAsync($"MovieViewPage/", useModalNavigation: true);
            }
            else
            {
                this._eventAggregator.GetEvent<LanguageChoosed>().Publish(this.Language);
            }
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("lang"))
                this.Language = parameters["lang"].ToString();
        }

        public void Destroy()
        {

        }
    }
}
