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

namespace ArcTouch.ViewModels
{
	public class MenuPageViewModel : ViewModelBase
    {
        public DelegateCommand<string> ItemTappedCommand { get; set; }
        public ObservableCollection<Category> Itens { get; set; }

        private readonly INavigationService _navigationService;
        private readonly IEventAggregator _eventAggregator;

        public MenuPageViewModel(INavigationService navigationService, IEventAggregator eventAggregator)
            : base(navigationService)
        {
            this.Itens = new ObservableCollection<Category>();
            this._navigationService = navigationService;
            this._eventAggregator = eventAggregator;

            eventAggregator.GetEvent<LanguageChoosed>().Subscribe(async item =>
            {
                var movies = RestService.For<IRestApi>(EndPoints.BaseUrl);
                var Categories = await movies.Categories(item);
                

                foreach (var category in Categories.genres)
                {
                    this.Itens.Add(category);
                    App.Categories.Add(category);
                }
            });

            this.ItemTappedCommand = new DelegateCommand<string>((codeCategory) =>
            {
                this._eventAggregator.GetEvent<CategoryChoosed>().Publish(codeCategory);
            });
        }
	}
}
