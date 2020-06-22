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
    public partial class Contact : ContentPage
    {
        public Contact()
        {
            InitializeComponent();


            BackgroundImageSource = "book.jpg"; Aspect = "AspectFit";

        }

        public string Aspect { get; private set; }

        private void Back_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
        }

        private void LogBtn_Clicked(object sender, EventArgs e)
        {

        }

        private void LogBtn_Clicked_1(object sender, EventArgs e)
        {

        }

        private void SubmitBtn_Clicked(object sender, EventArgs e)
        {

        }
    }
}