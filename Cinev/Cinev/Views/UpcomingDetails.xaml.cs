using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinev.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpcomingDetails : ContentPage
    {
        public UpcomingDetails(Upcoming upcoming)
        {
            InitializeComponent();
            Title.Text = upcoming.Title;

            MovieImage.Source = new UriImageSource()
            {

                Uri = new Uri(upcoming.FullBackPath)

            };
            OverView.Text = upcoming.Overview;




        }

        private void AddToWish_Clicked(object sender, EventArgs e)
        {

        }
    }
}