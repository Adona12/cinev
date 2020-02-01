using Cinev.Model;
using Cinev.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinev.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Schedules : ContentPage
    {
        public Schedules()
        {
            InitializeComponent();
        }

        public ObservableCollection<SearchResult> GetSearchResults(string query) {

            ObservableCollection<SearchResult> ud = new ObservableCollection<SearchResult>();
            using (var webClient = new WebClient())

            {

                //string mid = "https://api.themoviedb.org/3/search/movie?api_key=f4b8e415cb9ab402e5c1d72176cab35b&query=jumanji&page=1&include_adult=false";
                string jsonString = webClient.DownloadString("https://api.themoviedb.org/3/search/movie?api_key=f4b8e415cb9ab402e5c1d72176cab35b&query=" + query + "&page=1&include_adult=false");
                var r = SearchResult.FromJson(jsonString);
                foreach (SearchResult up in r.Results)
                {

                    ud.Add(up);

                }


               





            };
            return ud;
        
        }


         void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            SearchBar searchBar = (SearchBar)sender;
            if (searchBar.Text != " " && searchBar.Text != "" && searchBar.Text != null)
            {
                searchResults.ItemsSource = GetSearchResults(searchBar.Text);
            }
            else {

                searchResults.ItemsSource=new ObservableCollection<SearchResult>();
            }

                

        }

    

        private async void searchResults_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var details = e.Item as SearchResult;
            await Navigation.PushAsync(new UpcomingDetails((int)details.Id));

        }
    }
}