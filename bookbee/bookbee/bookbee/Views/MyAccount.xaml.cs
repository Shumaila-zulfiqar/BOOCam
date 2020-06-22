using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bookbee.Models;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bookbee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyAccount : ContentPage
    {
        User user = new User();
      

        public string fullname;

        public MyAccount()
        {
            InitializeComponent();
            fullname = user.FirstName + " " + user.LastName;
            fname.Text = fullname;         
            pass.Text = user.Password;
            email.Text = user.Email;
            username.Text = user.FirstName;
        }

   

        private async void NameEditBtn_Clicked(object sender, EventArgs e)
        {

            await PopupNavigation.Instance.PushAsync(new EditPopup());
          
            
        }

    
        private async void PasswordEditBtn_Clicked(object sender, EventArgs e)
        {

            await PopupNavigation.Instance.PushAsync(new EditPasswordPopup());


        }
    }
}