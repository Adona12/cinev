
using Cinev.Helper;
using Cinev.Models;
using Cinev.ViewModel;
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
    public partial class WishList : ContentPage
    {
        public WishList()
        {
            InitializeComponent();
            BindingContext = new WishListViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = new WishListViewModel();

        }
        public async void OnDelete(object sender, EventArgs e)
        {
            WishListHelper wishHelper = new WishListHelper();
            var mi = ((MenuItem)sender);
          int x = (int)((MUpcomingDetails)mi.CommandParameter).Id;
            bool answer = await DisplayAlert("Question?", "Are you sure you want to remove this item", "Yes", "No");
            if (answer) {
                await wishHelper.DeleteWishList(AuthenticationViewModel.LoggedinUser, x);
                await DisplayAlert("Message", "The item has been deleted", "OK");
                BindingContext = new WishListViewModel();

            }



        }



    }
}