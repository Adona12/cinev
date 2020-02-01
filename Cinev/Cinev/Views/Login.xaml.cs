using Cinev.Helper;
using Cinev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinev.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        async private void LogInButton(object sender, EventArgs e)
        {
            UserHelper userhelp = new UserHelper();
            var email = EmailInput.Text;
            var password = PasswordInput.Text;
           if (string.IsNullOrWhiteSpace(email) || (string.IsNullOrWhiteSpace(password)))
            {
                await DisplayAlert("Alert", "Fill all the fields", "OK");
            }
            else
            {

                Users user = await userhelp.GetUser(email);
                if (user==null||user.Password!=password|| user.Email!=email)
                {
                    await DisplayAlert("Alert", "Autheentication failed", "OK");
                    EmailInput.Text = "";
                    PasswordInput.Text = "";
                }
                else
                {
                    await DisplayAlert("Alert", "passed", "OK");
                }

            }

        }
    }
}