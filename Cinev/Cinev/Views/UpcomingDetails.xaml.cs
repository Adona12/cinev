using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Cinev.Models;

namespace Cinev.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpcomingDetails : ContentPage
    {
        public UpcomingDetails(Upcoming upcoming)
        {


            InitializeComponent();

            using (var webClient = new WebClient())

            {
                string s = "https://api.themoviedb.org/3/movie/429617?api_key=f4b8e415cb9ab402e5c1d72176cab35b";
                string mid = Convert.ToString(upcoming.Id);
                string jsonString = webClient.DownloadString("https://api.themoviedb.org/3/movie/" + mid + "?api_key=f4b8e415cb9ab402e5c1d72176cab35b");


                var r = MUpcomingDetails.FromJson(jsonString);

                Title.Text = upcoming.Title;

                MovieImage.Source = new UriImageSource()
                {

                    Uri = new Uri(upcoming.FullBackPath)

                };
                OverView.Text = upcoming.Overview;



            }

      

        }

    

        private void AddToWish_Clicked(object sender, EventArgs e)
        {

        }
    }
}