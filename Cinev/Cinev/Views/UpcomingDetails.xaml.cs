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
        public class IconFont
        {
            public string Heart { get; set; }
           public string HeartOutline { get; set; }

            public IconFont(string s,string s2)
            {
                Heart = s;
                HeartOutline = s2;
            }

            

        }
      
        public static  string HeartOutline = "\uf2d5";
        public static  string Heart = "\uf2d1";
        public UpcomingDetails(Upcoming upcoming){
            BindingContext = new IconFont("\uf2d1", "\uf2d5");


            InitializeComponent();
           

            using (var webClient = new WebClient())

            {
                string s = "https://api.themoviedb.org/3/movie/429617?api_key=f4b8e415cb9ab402e5c1d72176cab35b";
                string mid = Convert.ToString(upcoming.Id);
                string jsonString = webClient.DownloadString("https://api.themoviedb.org/3/movie/" + mid + "?api_key=f4b8e415cb9ab402e5c1d72176cab35b");


                var r = MUpcomingDetails.FromJson(jsonString);

                Title.Text = r.Title;

                MovieImage.Source = new UriImageSource()
                {

                    Uri = new Uri(r.FullBackPath)

                };
                OverView.Text = r.Overview;
                string concat="";
                foreach (Genre g in r.Genres) {
                    concat += g.Name + " | ";
                }
                string sub = concat.Substring(0, concat.Length - 2);
                Genres.Text=sub;



            }

      

        }

       public static bool full = false;

        void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            
            var label = (Label)sender;
           
            if (full)
            {
                label.Text = HeartOutline;
                full = false;
            }
            else
            {
                label.Text = Heart;
                full = true;
            }
        }
    }
}