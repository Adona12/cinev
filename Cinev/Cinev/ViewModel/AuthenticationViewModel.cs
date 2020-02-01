
using Cinev.Helper;
using Cinev.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Cinev.ViewModel
{
    public class AuthenticationViewModel
    {
        static string LoggedinUser = "";
        public static async Task<bool> checkUser(string email,string password)
        {
            UserHelper userhelp = new UserHelper();
            Users user = await userhelp.GetUser(email);
            if (user == null || user.Password != password || user.Email != email)
            {
             
               return true;
            }
            else
            {
                LoggedinUser = email;
                return false;
            }
        }
        public static async Task<bool> checkUserSignup(string email, string password)
        {
            UserHelper userhelp = new UserHelper();
            Users user = await userhelp.GetUser(email);
            if (user == null || user.Password != password || user.Email != email)
            {

                return true;
            }
            else
            {
                LoggedinUser = email;
                return false;
            }
        }
    }
}
