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

    
    public partial class EditPopup
    {
        User user = new User();
        public EditPopup()
        {
            InitializeComponent();
            

        }

        private async void editNamebtn_Clicked(object sender, EventArgs e)
        {
            user.FirstName =  fnameEn.Text;
            user.LastName = lnameEn.Text;
          
            await Navigation.PushAsync(new MyAccount());
            await PopupNavigation.Instance.PopAsync();



        }
    }
}