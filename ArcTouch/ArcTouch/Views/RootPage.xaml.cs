using System;
using Xamarin.Forms;

namespace ArcTouch.Views
{
    public partial class RootPage : MasterDetailPage
    {
        public RootPage()
        {
            try
            {
                InitializeComponent();
               // Master = new MenuPage();
                // Detail = new NavigationPage(new ListMoviePage());
            }
            catch(Exception ex)
            {

            }
        }
    }
}