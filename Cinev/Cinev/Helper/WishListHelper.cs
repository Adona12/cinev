using Firebase.Database;
using Firebase.Database.Query;
using MovieSchedule.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSchedule.Helper
{
    public class WishListHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://movie-schedule-38065.firebaseio.com/");



        public async Task AddPerson(WishList wish)
        {

            await firebase
              .Child("WishLists").PostAsync(wish);
        }
        public async Task<List<WishList>> GetAllWish(int userID)
        {

            return (await firebase
            .Child("WishLists")
          .OnceAsync<WishList>()).Select(item => new WishList()
          {
              UserID = item.Object.UserID,
              MovieID = item.Object.MovieID
            

          }).Where(a => a.UserID == userID).ToList();
        }
  
        public async Task DeleteWishList(int userID, int movieID)
        {
            var toDeleteWish = (await firebase
              .Child("WishLists")
              .OnceAsync<WishList>()).Where(a => a.Object.UserID == userID && a.Object.MovieID== movieID).FirstOrDefault();
            await firebase.Child("Persons").Child(toDeleteWish.Key).DeleteAsync();

        }
    }

}
