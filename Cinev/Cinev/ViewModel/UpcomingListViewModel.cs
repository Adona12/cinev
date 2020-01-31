using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;

namespace Cinev.ViewModel
{

   
    class UpcomingListViewModel
    {
        public ObservableCollection<Upcoming> upcomings { get; set; }
        public UpcomingListViewModel()
        {
            upcomings = new ObservableCollection<Upcoming>();

            using (var webClient = new WebClient())
            {
                string jsonString = webClient.DownloadString("https://api.themoviedb.org/3/movie/upcoming?api_key=f4b8e415cb9ab402e5c1d72176cab35b");
                Console.WriteLine(jsonString);

                var r = Upcoming.FromJson(jsonString);
                foreach (Upcoming up in r.Results) {

                    upcomings.Add(up);
                
                }



            }




        }

    }
}
