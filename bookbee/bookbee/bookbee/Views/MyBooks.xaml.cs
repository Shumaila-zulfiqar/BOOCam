using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bookbee.Controls;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace bookbee.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyBooks : ContentPage
    {

        public class Shelf
        {
            public string bookcoverurl { get; set; }
            public string bookdetail { get; set; }

            
        }

        public List<Shelf> Library = new List<Shelf>()
        {
            new Shelf{bookcoverurl="https://www.creativindie.com/wp-content/uploads/2012/07/stock-image-site-pinterest-graphic.jpg", 
            bookdetail="The Best"},
            new Shelf{bookcoverurl= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ7eX9GxX1Nztj_qqLJ7UdE0GB-WtAwk9IWIv8Yq2va7qEcBnju&s",
            bookdetail="The Wild Robot"},
            new Shelf{bookcoverurl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTmOl1n5jeC001ysWli5G5M4PVl48VUZJsMY6bKAypZlh2RSr4v&s",
            bookdetail="The Cat In The Hat"},
   
            new Shelf{bookcoverurl= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ7eX9GxX1Nztj_qqLJ7UdE0GB-WtAwk9IWIv8Yq2va7qEcBnju&s",
            bookdetail="The Wild Robot"},
            new Shelf{bookcoverurl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTmOl1n5jeC001ysWli5G5M4PVl48VUZJsMY6bKAypZlh2RSr4v&s",
            bookdetail="The Cat In The Hat"},

        };
        public MyBooks()
        {

            

            InitializeComponent();
            {

                var images = new List<string>()
               {"https://www.creativindie.com/wp-content/uploads/2012/07/stock-image-site-pinterest-graphic.jpg",
                //"https://i.huffpost.com/gen/1039678/original.jpg",
                "https://i.pinimg.com/originals/b9/0d/56/b90d56623e94c6f8293ac7ae1f401b4d.png",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ7eX9GxX1Nztj_qqLJ7UdE0GB-WtAwk9IWIv8Yq2va7qEcBnju&s",
                "https://i.pinimg.com/originals/f7/6a/61/f76a61440698a93d40f1947be5b8ab52.png",
                "https://nice-assets.s3-accelerate.amazonaws.com/smart_templates/e639b9513adc63d37ee4f577433b787b/assets/wn5u193mcjesm2ycxacaltq8jdu68kmu.jpg",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTmOl1n5jeC001ysWli5G5M4PVl48VUZJsMY6bKAypZlh2RSr4v&s",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQlyxax3oKQMOBTosXUA4s9yniAVkcQ4LPOMCe_GDODjFovoY5h&s",
                "https://nataliemerheb.com/wp-content/uploads/2019/02/Focal-Point-04-790x1024.jpg",


             };
                //  MainCarousalView.ItemsSource = images;

                //carouselView.ItemsSource = images;
                ShelfcarouselView.ItemsSource = images;
                BookList.ItemsSource = Library;


            }
           
        }

        private async void camera_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OcrPage());
        }



        /*  private void snapPointsTypeEnumPicker_SelectedIndexChanged(object sender, EventArgs e)
          {
              ItemsLayout itemsLayout = (ItemsLayout)carouselView.ItemsLayout;
              itemsLayout.SnapPointsType = (SnapPointsType)(sender as EnumPicker).SelectedItem;
          }

          private void snapPointsAlignmentEnumPicker_SelectedIndexChanged(object sender, EventArgs e)
          {

              ItemsLayout itemsLayout = (ItemsLayout)carouselView.ItemsLayout;
              itemsLayout.SnapPointsAlignment = (SnapPointsAlignment)(sender as EnumPicker).SelectedItem;

          }*/
    }
}
