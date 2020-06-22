using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using bookbee.Views;

namespace bookbee
{
    public partial class App : Xamarin.Forms.Application
    {
        public static string DatabaseLocation = string.Empty;
        public App()
        {
            InitializeComponent();
            Device.SetFlags(new[] {
                "CarouselView_Experimental",
                "IndicatorView_Experimental"
            });
            
           MainPage = new NavigationPage(new MainPage());
        }

        public App(string dbloc)
        {
            InitializeComponent();
            Device.SetFlags(new[] {
                "CarouselView_Experimental",
                "IndicatorView_Experimental"
            });

            MainPage = new NavigationPage(new MainPage());


            DatabaseLocation = dbloc;
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
