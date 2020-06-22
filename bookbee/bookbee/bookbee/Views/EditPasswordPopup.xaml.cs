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
    public partial class EditPasswordPopup 
    {
        User user = new User();
        public EditPasswordPopup()
        {
            InitializeComponent();
        }

      

        private async void updatePasswordbtn_Clicked(object sender, EventArgs e)
        {
            //user.Password = newpassEn.Text;
            //user.ConfirmPassword = newCpassEn.Text;
            await PopupNavigation.Instance.PopAsync();

        }
    }
}