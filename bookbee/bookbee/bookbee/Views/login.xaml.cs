using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bookbee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();
            BackgroundImageSource = "B4.jpg"; Aspect = "AspectFit";
        }
        public string Aspect { get; private set; }
        private void Signup_Clicked(object sender, EventArgs e)
        {
            popup.IsVisible = true;
        }


        private void Log_Clicked(object sender, EventArgs e)
        {
            popup.IsVisible = false;
        }

        private void Submit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }

    }
}


