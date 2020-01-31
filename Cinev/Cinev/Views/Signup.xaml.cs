
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinev.Helper;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinev.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Signup : ContentPage
    {
        public Signup()
        {
            InitializeComponent();
        }

        private void SignupButton(object sender, EventArgs e)
        {
            UserHelper userhelp = new UserHelper();
            var email = EmailInput.Text;
            var password = PasswordInput.Text;
            var name = fullInput.Text;
            if (string.IsNullOrWhiteSpace(email) || (string.IsNullOrWhiteSpace(password)|| string.IsNullOrWhiteSpace(name)))
            {
                await DisplayAlert("Alert", "Fill all the fields", "OK");
            }
            _ = userhelp.AddUser(email, password, name);


        }
    }
}