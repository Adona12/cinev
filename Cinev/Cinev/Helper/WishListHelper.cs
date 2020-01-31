using Cinev.Model;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinev.Helper
{
    public class WishListHelper
    {

        FirebaseClient firebase = Connection.getConnection();

        public async Task AddWishList(WishListUser wish)
        {

            await firebase
              .Child("WishLists").PostAsync(wish);
        }
        public async Task<List<WishListUser>> GetAllWish(int userID)
        {

            return (await firebase
            .Child("WishLists")
          .OnceAsync<WishListUser>()).Select(item => new WishListUser()
          {
              UserID = item.Object.UserID,
              MovieID = item.Object.MovieID
            

          }).Where(a => a.UserID == userID).ToList();
        }
        public async Task<List<WishListUser>> CheckMovieExists(int userID,int movieId)
        {

            return (await firebase
            .Child("WishLists")
          .OnceAsync<WishListUser>()).Select(item => new WishListUser()
          {
              UserID = item.Object.UserID,
              MovieID = item.Object.MovieID


          }).Where(a => a.UserID == userID&&a.MovieID==movieId).ToList();
        }


        public async Task DeleteWishList(int userID, int movieID)
        {
            var toDeleteWish = (await firebase
              .Child("WishLists")
              .OnceAsync<WishListUser>()).Where(a => a.Object.UserID == userID && a.Object.MovieID == movieID).FirstOrDefault();
            await firebase.Child("WishLists").Child(toDeleteWish.Key).DeleteAsync();

        }
    }

}
