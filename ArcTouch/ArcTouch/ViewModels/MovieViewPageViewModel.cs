using ArcTouch.Data;
using ArcTouch.Data.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArcTouch.ViewModels
{
	public class MovieViewPageViewModel : ViewModelBase, INavigationAware, IDestructible
    {
        private string _id;
        public string ID
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _gen;
        public string Gen
        {
            get { return _gen; }
            set { SetProperty(ref _gen, value); }
        }

        private string _date;
        public string Date
        {
            get { return _date; }
            set { SetProperty(ref _date, value); }
        }

        private string _img;
        public string Img
        {
            get { return _img; }
            set { SetProperty(ref _img, value); }
        }

        private string _body;
        public string Body
        {
            get { return _body; }
            set { SetProperty(ref _body, value); }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }


        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;
        public MovieViewPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
            : base(navigationService)
        {
            
            this._navigationService = navigationService;
            this._eventAggregator = eventAggregator;

        }

        private async Task InitializeAsync()
        {
            var movies = RestService.For<IRestApi>(EndPoints.BaseUrl);
            var moviesList = await movies.DetailMovies(this.ID, Helpers.Settings.Language);

            this.Body = moviesList.overview;
            this.Img = "https://image.tmdb.org/t/p/w300/" + moviesList.backdrop_path;
        }

        public void Destroy()
        {
          
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
           
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
            if (parameters.ContainsKey("id"))
                this.ID = parameters["id"].ToString();

            if (parameters.ContainsKey("gen"))
                this.Gen = parameters["gen"].ToString();

            if (parameters.ContainsKey("date"))
                this.Date = parameters["date"].ToString();

            if (parameters.ContainsKey("title"))
                this.Name = parameters["title"].ToString();

            InitializeAsync();
        }
    }
}
