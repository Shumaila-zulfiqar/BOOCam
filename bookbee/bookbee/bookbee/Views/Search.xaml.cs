using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bookbee.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bookbee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Search : ContentPage
    {
        public Search()
        {
            InitializeComponent();
        }

        private async void searchbar_SearchButtonPressed(object sender, EventArgs e)
        {
            var keyword = searchbar.Text;

            SearchHistory s = new SearchHistory()

            {
                BookTitle = keyword
            };


            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))

            {
                conn.CreateTable<SearchHistory>();
                int rows = conn.Insert(s);
               
                if (rows > 0)
                {
                    await DisplayAlert(null, "book added", "ok");
                    await Navigation.PushAsync(new Search());
                }
                else
                {
                    await DisplayAlert(null, "book cannot be added", "ok");
                }
            }

        }
    }
}