using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using bookbee.Models;
using bookbee.Models.Image;
using bookbee.Models.Ocr;
using bookbee.Services;
//using ComputerVisionApplication.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;
using bookbee.Views;
using System.Threading.Tasks;

namespace bookbee.ViewModels
{

  
    public class ComputerVisionViewModel : INotifyPropertyChanged , INavigation
    {

    


        private ImageResult _imageResult;
        private OcrResult _imageResultOcr;

        private string _imageUrl; //= "https://pbs.twimg.com/media/CivvCZ_UgAIB80Z.jpg";
        /// <summary>
        /// Get a subscription key from:
        /// https://www.microsoft.com/cognitive-services/en-us/subscriptions
        /// The following API Key may stop working at anytime, so get your own!
        /// </summary>
        private const string ComputerVisionApiKey = "32a11080b93f412dac1e23b0ef6da546";
        private readonly ComputerVisionService _computerVisionService = new ComputerVisionService(ComputerVisionApiKey);


        public Stream _imageStream;
        private string _errorMessage;
        private bool _isBusy;

        public ImageResult ImageResult
        {
            get { return _imageResult; }
            set
            {
                _imageResult = value;
                OnPropertyChanged();
            }
        }



        public string ImageUrl
        {
            get { return _imageUrl; }
            set
            {
                _imageUrl = value;
                OnPropertyChanged();
            }
        }

        public OcrResult OcrResult
        {
            get { return _imageResultOcr; }
            set
            {
                _imageResultOcr = value;
                OnPropertyChanged();
            }
        }


        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

       
       


         public Command TakePhotoCommand
           {
               get
               {
                   return new Command(async () =>
                   {
                       // Don't forget to install nuget package Xam.Plugin.Media 
                       // on all Solution projects
                       await CrossMedia.Current.Initialize();

                       MediaFile mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions { PhotoSize = PhotoSize.MaxWidthHeight, MaxWidthHeight = 300 });

                       _imageStream = mediaFile?.GetStream();

                       ImageUrl = mediaFile?.Path;

                       IsBusy = true;

                       try
                       {
                           ImageResult = null;
                           ErrorMessage = string.Empty;

                           OcrResult = await _computerVisionService.ExtractTextFromImageStreamAsync(_imageStream);

                           
                         ///  await PushAsync(new upload());
                       }
                       catch (Exception exception)
                       {
                           ErrorMessage = exception.Message;
                       }

                       IsBusy = false;

                   });


               }

           }

       public Command PickPhotoCommand
           {
               get
               {
                   return new Command(async () =>
                   {
                       // Don't forget to install nuget package Xam.Plugin.Media 
                       // on all Solution projects
                       await CrossMedia.Current.Initialize();

                       var mediaFile = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions { PhotoSize = PhotoSize.MaxWidthHeight, MaxWidthHeight = 300 });

                       _imageStream = mediaFile?.GetStream();

                       ImageUrl = mediaFile?.Path;

                       IsBusy = true;

                       try
                       {
                           ImageResult = null;
                           ErrorMessage = string.Empty;

                           OcrResult = await _computerVisionService.ExtractTextFromImageStreamAsync(_imageStream);

                          
                          

                       }
                       catch (Exception exception)
                       {
                           ErrorMessage = exception.Message;
                       }

                       IsBusy = false;


                   });


               }
           }

        public IReadOnlyList<Page> ModalStack => throw new NotImplementedException();

        public IReadOnlyList<Page> NavigationStack => throw new NotImplementedException();



        /*
 

        public Command ExtractTextFromImageStreamCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;

                    try
                    {
                        ImageResult = null;
                        ErrorMessage = string.Empty;

                        OcrResult = await _computerVisionService.ExtractTextFromImageStreamAsync(_imageStream);
                    }
                    catch (Exception exception)
                    {
                        ErrorMessage = exception.Message;
                    }

                    IsBusy = false;
                });
            }
        }
        
    */
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void InsertPageBefore(Page page, Page before)
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopModalAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Page> PopModalAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public Task PopToRootAsync()
        {
            throw new NotImplementedException();
        }

        public Task PopToRootAsync(bool animated)
        {
            throw new NotImplementedException();
        }

        public Task PushAsync(Page page)
        {
            throw new NotImplementedException();
        }

        public Task PushAsync(Page page, bool animated)
        {
            throw new NotImplementedException();
        }

        public Task PushModalAsync(Page page)
        {
            throw new NotImplementedException();
        }

        public Task PushModalAsync(Page page, bool animated)
        {
            throw new NotImplementedException();
        }

        public void RemovePage(Page page)
        {
            throw new NotImplementedException();
        }
    }
}
