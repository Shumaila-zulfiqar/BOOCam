using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using bookbee.Converters;
using bookbee.Models;
using bookbee.ViewModels;
using bookbee.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Rg.Plugins.Popup.Services;

namespace bookbee.Views
{
    //  [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        // private const string V = "100";

        // public List<MenuItem> Images { get; set; }

        // public string Aspect { get; }
        //  public string Margin { get; }

    

        public class AppFunctions
        {
            public string text { get; set; }
            public string image { get; set; }


        }

        public List<AppFunctions> fun = new List<AppFunctions>()
        {
            new AppFunctions {image="camera.png",
            text="Capture Book Cover"},
            new AppFunctions {image="img.png",
            text="Upload From Gallery"},
            new AppFunctions {image="lib.png",
            text="REcommendations"}

        };


        public Home()
        {

            BindingContext = new ComputerVisionViewModel();
            InitializeComponent();

            
               /*  Images = new List<MenuItem>();
                  //  var slide1 = new MenuItem() { Title = "HEllllllaaaaaa", ImageUrl= ""};
                  var slide1 = new MenuItem() { Title = "Explore New Books", ImageUrl = "https://c1.wallpaperflare.com/preview/589/21/277/book-education-pages-read.jpg" };
                  var slide2 = new MenuItem() { Title = "Make Your Personal Library", ImageUrl = "https://images.pexels.com/photos/1005324/literature-book-open-pages-1005324.jpeg" };
                  var slide3 = new MenuItem() { Title = "Find Your Favourite Books", ImageUrl = "https://images.pexels.com/photos/810050/pexels-photo-810050.jpeg" };
                  var slide4 = new MenuItem() { Title = "Find Your Favourite Authors", ImageUrl = "https://images.pexels.com/photos/415078/pexels-photo-415078.jpeg" };
                  Images.Add(slide1);
                  Images.Add(slide2);
                  Images.Add(slide3);
                  Images.Add(slide4);
              


                  MainCarousalView.ItemsSource = Images;
                  Device.StartTimer(TimeSpan.FromSeconds(7), (Func<bool>)(() =>
                  {
                      MainCarousalView.Position = (MainCarousalView.Position + 1) % Images.Count;
                      return true;
                  }));*/

                  //  BackgroundImage = "help.jpg"; Aspect = "AspectFit"; HeightRequest = 'V' ; Margin = "50 50 50 50";

   

            var images = new List<string>()
               {"https://www.creativindie.com/wp-content/uploads/2012/07/stock-image-site-pinterest-graphic.jpg",
               // "https://i.huffpost.com/gen/1039678/original.jpg",
                "https://i.pinimg.com/originals/b9/0d/56/b90d56623e94c6f8293ac7ae1f401b4d.png",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ7eX9GxX1Nztj_qqLJ7UdE0GB-WtAwk9IWIv8Yq2va7qEcBnju&s",
                "https://i.pinimg.com/originals/f7/6a/61/f76a61440698a93d40f1947be5b8ab52.png",
                "https://nice-assets.s3-accelerate.amazonaws.com/smart_templates/e639b9513adc63d37ee4f577433b787b/assets/wn5u193mcjesm2ycxacaltq8jdu68kmu.jpg",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTmOl1n5jeC001ysWli5G5M4PVl48VUZJsMY6bKAypZlh2RSr4v&s",
                "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQlyxax3oKQMOBTosXUA4s9yniAVkcQ4LPOMCe_GDODjFovoY5h&s",
                "https://nataliemerheb.com/wp-content/uploads/2019/02/Focal-Point-04-790x1024.jpg",


             };

       
             
           // MainCarousalView.ItemsSource = images;
            RecommendationCarousalView.ItemsSource = images;
            CarousalView.ItemsSource = images;
            //functions.ItemsSource = fun;


        }
          


        /*
        private async void camera_Clicked(object sender, EventArgs e)
          {
            await CrossMedia.Current.Initialize();

            MediaFile photo;
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", "No camera available.", "OK");
                return;
            }



            photo = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        DefaultCamera = CameraDevice.Front,
                        SaveToAlbum = true,
                        PhotoSize = PhotoSize.MaxWidthHeight,
                        MaxWidthHeight = 300


                    }
                    );
            if (photo == null)
                return;


            string path = photo?.Path;
            Stream stream = photo?.GetStream();
            ImageSource img = ImageSource.FromStream(() =>
            {
                var s = photo.GetStream();
                photo.Dispose();
                return s;
               
            });

            


            await Navigation.PushAsync(new upload());

             /* path.Text = file.AlbumPath;

              img.Source = ImageSource.FromStream(() =>
              {
                  var stream = file.GetStream();
                  file.Dispose();
                  return stream;
              });


          }
    
          private async void upload_Clicked(object sender, EventArgs e)
          {
            await CrossMedia.Current.Initialize();
            MediaFile photo;
            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("ALERT", "pick photo not supported", "OK");
                return;
            }
            photo = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions { PhotoSize = PhotoSize.MaxWidthHeight, MaxWidthHeight = 300 });

            if (photo == null)
                return;



            string path= photo?.Path;
            Stream stream= photo?.GetStream();
            ImageSource img = ImageSource.FromStream(() =>
            {
                var s = photo.GetStream();
                photo.Dispose();
                return s;
            });



            await Navigation.PushAsync(new upload());




              /*path.Text = "photo path" + file.Path;

              img.Source = ImageSource.FromStream(() =>
              {
                  var stream = file.GetStream();
                  file.Dispose();
                  return stream;
              });
          }
          */
      
       

        private async void search_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Search());
        }



        private async void camera_btn_Clicked(object sender, EventArgs e)
        {
            //  await PopupNavigation.Instance.PushAsync(new CameraAndGallery());

            await Navigation.PushAsync(new OcrPage());
        }





        /*   private void snapPointsTypeEnumPicker_SelectedIndexChanged_1(object sender, EventArgs e)
           {
               ItemsLayout itemsLayout = (ItemsLayout)CarousalView.ItemsLayout;
               itemsLayout.SnapPointsType = (SnapPointsType)(sender as EnumPicker).SelectedItem;
             }

           private void snapPointsAlignmentEnumPicker_SelectedIndexChanged_1(object sender, EventArgs e)
           {
               ItemsLayout itemsLayout = (ItemsLayout)CarousalView.ItemsLayout;
               itemsLayout.SnapPointsAlignment = (SnapPointsAlignment)(sender as EnumPicker).SelectedItem;
           }*/
    }
}