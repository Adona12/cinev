using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cinev.Helper
{
   public class Connection
    {

        private static FirebaseClient firebase = new FirebaseClient("https://movie-schedule-38065.firebaseio.com/");
        private Connection() { }
     
        public static FirebaseClient getConnection()
        {
            return firebase;
        }
    }
}
