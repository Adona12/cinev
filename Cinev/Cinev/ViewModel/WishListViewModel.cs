using Cinev.Helper;
using Cinev.Model;
using Cinev.Models;
using Cinev.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;

namespace Cinev.ViewModel
{
    class WishListViewModel
    {

      
        public ObservableCollection <MUpcomingDetails> details { get; set; }

        public WishListViewModel()
        {
           
            details =new ObservableCollection<MUpcomingDetails>();
            retriveWish();



        }

        public  async void retriveWish() {
            WishListHelper wishHelper = new WishListHelper();
            List<WishListUser> data = await wishHelper.GetAllWish(1);
            foreach (WishListUser wlu in data) {
                using (var webClient = new WebClient())

                {
                    Console.WriteLine(wlu.MovieID);
                    string mid = Convert.ToString(wlu.MovieID);
                    string jsonString = webClient.DownloadString("https://api.themoviedb.org/3/movie/" + mid + "?api_key=f4b8e415cb9ab402e5c1d72176cab35b");
                     var r = MUpcomingDetails.FromJson(jsonString);
                    details.Add(r);


            
                 

                    }; }


              
            
            }



        }
    }

