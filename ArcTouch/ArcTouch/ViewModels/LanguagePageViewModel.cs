

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using ArcTouch.Data;
using ArcTouch.Data.Interfaces;
using ArcTouch.Model;
using Prism.Commands;
using Prism.Navigation;
using Refit;
using ArcTouch.Helpers;
using System.Collections.Generic;

namespace ArcTouch.ViewModels
{
    public class LanguagePageViewModel : ViewModelBase, INavigationAware, IDestructible
    {
        public ObservableCollection<Language> Itens { get; set; }
        public List<Language> ItensTemp { get; set; }
        public DelegateCommand SearchCommand { get; set; }
        public DelegateCommand<string> ItemTappedCommand { get; set; }
        INavigationService _navigationService { get; }

        private string _search;
        public string SearchField
        {
            get { return _search; }
            set { SetProperty(ref _search, value); }
        }
        public LanguagePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this.Itens = new ObservableCollection<Language>();
            this.ItensTemp = new List<Language>();
            this.SearchCommand = new DelegateCommand(Search);
            this.ItemTappedCommand = new DelegateCommand<string>((codeLanguage) =>
            {
                Helpers.Settings.Language = codeLanguage;
                navigationService.GoBackAsync();
            });
            InitializeAsync();
        }

        private async Task InitializeAsync()
        {
            var movies = RestService.For<IRestApi>(EndPoints.BaseUrl);
            var itens = await movies.GetLanguages();
            foreach (var item in itens)
            {
                this.Itens.Add(item);
            }
        }

        private void Search()
        {
            ItensTemp = Itens.ToList();
            Itens.Clear();
            foreach (var item in ItensTemp.Where(x => x.english_name.StartsWith(char.ToUpper(SearchField[0]) + SearchField.Substring(1))))
            {
                Itens.Add(item);
            }
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

        }
    }
}
