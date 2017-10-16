using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrailMakers.UI;
using Xamarin.Forms;

namespace TrailMakers
{
    public partial class App : Application
    {
        public static Size ScreenSize { get; set; }

        public App()
        {
            InitializeComponent();

            //MainPage = new NavigationPage(new MainPage());
            MainPage = new NavigationPage(new TabbedMainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
