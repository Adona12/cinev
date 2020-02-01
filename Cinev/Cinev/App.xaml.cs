using Cinev.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Cinev
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();


            // MainPage = new MainPage();
            //  MainPage = new NavigationPage(new UpcomingList());
         MainPage = new NavigationPage(new Signup());


           //MainPage = new TabbedPage1();
          //  MainPage  =new Signup();
          //  MainPage = new Login();
           //   MainPage = new TabbedPage1();


            //   MainPage = new TabbedPage1();
            //      MainPage = new Signup();
            //  MainPage = new Login();
            // MainPage = new TabbedPage1();


        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
