using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace bookbee.Views

{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    // [DesignTimeVisible(true)]
    public partial class MainPage : MasterDetailPage
    {
        public List<MenuItem> menuList { get; set; }
        public MainPage()
        {
            InitializeComponent(); ;
            Detail = new NavigationPage(new Home())
            {
                BarBackgroundColor = Color.FromHex("#990033"),
               
                
            };

            // IsPresented = false;


            menuList = new List<MenuItem>();

           
            var page1 = new MenuItem() { Title = "My Account", Icon = "ic_action_account_circle.png", TargetType = typeof(MyAccount)};
            var page2 = new MenuItem() { Title = "Home", Icon = "ic_action_home.png", TargetType = typeof(Home) };
            var page3 = new MenuItem() { Title = "My Library", Icon = "lib.png", TargetType = typeof(MyBooks) };
            var page4 = new MenuItem() { Title = "Contact Us", Icon = "ic_action_contact_phone.png", TargetType = typeof(Contact) };
            var page5 = new MenuItem() { Title = "About Us", Icon = "ic_action_info.png", TargetType = typeof(About) };
            var page6 = new MenuItem() { Title = "Help", Icon = "ic_action_help.png", TargetType = typeof(Help) };
            var page7 = new MenuItem() { Title = "History", Icon = "ic_action_access_time.png", TargetType = typeof(History) };
            var page8 = new MenuItem() { Title = "Logout", Icon = "ic_action_power_settings_new.png", TargetType = typeof(Welcome) };


            menuList.Add(page1);
            menuList.Add(page2);
            menuList.Add(page3);
            menuList.Add(page4);
            menuList.Add(page5);
            menuList.Add(page6);
            menuList.Add(page7);
            menuList.Add(page8);
            navigationDrawerList.ItemsSource = menuList;
        }
        
        private void about(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MyBooks());


        }
  


        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            var item = (MenuItem)e.SelectedItem;
            Type page = item.TargetType;

           Detail = new NavigationPage((Page)Activator.CreateInstance(page))
            {

                BarBackgroundColor = Color.FromHex("#990033")
            };
            IsPresented = false;
        }

        private async void searchBtn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SearchBook());

        }
    }
}
