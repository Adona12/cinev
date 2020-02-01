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
    public partial class UpcomingList : ContentPage
    {
        public UpcomingList()
        {
            InitializeComponent();
            BindingContext = new UpcomingListViewModel();
        }



        private async void umListview_ItemTapped(Object sender, ItemTappedEventArgs e) {
            var details = e.Item as Upcoming;
            await Navigation.PushAsync(new UpcomingDetails((int)details.Id));
        
        
        } 
        
        }
    }
