using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bookbee.Models;
using Rg.Plugins.Popup.Services;
//using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bookbee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class History : ContentPage
    {

        // SearchHistory s = new SearchHistory();

        public List<SearchHistory> searchHistory = new List<SearchHistory>()
        {
            new SearchHistory{BookCoverUrl="https://www.creativindie.com/wp-content/uploads/2012/07/stock-image-site-pinterest-graphic.jpg",
            BookTitle="The Best"},
            new SearchHistory{BookCoverUrl= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ7eX9GxX1Nztj_qqLJ7UdE0GB-WtAwk9IWIv8Yq2va7qEcBnju&s",
          BookTitle="The Wild Robot"},
            new SearchHistory{BookCoverUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTmOl1n5jeC001ysWli5G5M4PVl48VUZJsMY6bKAypZlh2RSr4v&s",
            BookTitle="The Cat In The Hat"},

            new SearchHistory{BookCoverUrl= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ7eX9GxX1Nztj_qqLJ7UdE0GB-WtAwk9IWIv8Yq2va7qEcBnju&s",
         BookTitle="The Wild Robot"},
            new SearchHistory{BookCoverUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTmOl1n5jeC001ysWli5G5M4PVl48VUZJsMY6bKAypZlh2RSr4v&s",
           BookTitle="The Cat In The Hat"},
        };

        public History()
        {
            InitializeComponent();
            HistoryList.ItemsSource = searchHistory;
          //  HistoryList.ItemSelected += HistoryList_ItemSelected;
        }

        private void HistoryList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
          //  s = (SearchHistory)e.SelectedItem;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
           var response =  await DisplayAlert("Alert", "Delete item ? ", "Yes","No");
            if(response)
            {
                await DisplayAlert("Alert", "Item Deleted", "Ok");
            }
        }

        private async void camera_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OcrPage());
        }

        /* protected override void OnAppearing()
         {
             base.OnAppearing();

             using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
             {
                 conn.CreateTable<SearchHistory>();
                 var searches = conn.Table<SearchHistory>().ToList();
                 HistoryList.ItemsSource = searches;
             }


         }*/

        /*  private async void ImageButton_Clicked(object sender, EventArgs e)
          {
              using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
              {
                  conn.CreateTable<SearchHistory>();

                  int deleted_rows = conn.Table<SearchHistory>().Delete(x => x.BookTitle == s.BookTitle);
                  if (deleted_rows > 0)
                  {
                      await DisplayAlert(null, "book deleted", "ok");
                      await Navigation.PushAsync(new History());

                  }
                  else
                  {
                      await DisplayAlert(null, "book cannot be deleted", "ok");
                  }

              }


          }*/
    }
}