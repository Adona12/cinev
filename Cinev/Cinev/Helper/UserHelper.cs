using Cinev.Helper;
using Cinev.Models;
using Firebase.Database;
using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Cinev.Helper
{
   public class UserHelper
    {
        FirebaseClient firebase = Connection.getConnection();

        //Read All
        public  async Task<List<Users>> GetAllUser()
        {
            try

            {
                var userlist = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Select(item =>
                new Users
                {
                    Email = item.Object.Email,
                    Password = item.Object.Password
                }).ToList();
                return userlist;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Read 
        public  async Task<Users> GetUser(string email)
        {
            try
            {
                var allUsers = await GetAllUser();
                await firebase
                .Child("Users")
                .OnceAsync<Users>();
                return allUsers.Where(a => a.Email == email).FirstOrDefault();
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }
        public async Task<Users> GetUser(string email,string password)
        {
            try
            {
                var allUsers = await GetAllUser();
                await firebase
                .Child("Users")
                .OnceAsync<Users>();
                return allUsers.Where(a => a.Email == email && a.Password==password).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return null;
            }
        }

        //Inser a user
        public async Task<bool> AddUser(string email,string password,string fullName)
        {
            try
            {


                await firebase
                .Child("Users")
                .PostAsync(new Users() { FullName=fullName,Email = email, Password = password });
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Update 
        public  async Task<bool> UpdateUser(string email,string password)
        {
            try
            {


                var toUpdateUser = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase
                .Child("Users")
                .Child(toUpdateUser.Key)
                .PutAsync(new Users() { Email = email, Password = password });
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

        //Delete User
        public  async Task<bool> DeleteUser(string email)
        {
            try
            {


                var toDeletePerson = (await firebase
                .Child("Users")
                .OnceAsync<Users>()).Where(a => a.Object.Email == email).FirstOrDefault();
                await firebase.Child("Users").Child(toDeletePerson.Key).DeleteAsync();
                return true;
            }
            catch(Exception e)
            {
                Debug.WriteLine($"Error:{e}");
                return false;
            }
        }

    }
}
