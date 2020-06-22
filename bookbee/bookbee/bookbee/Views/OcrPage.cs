using System;
using System.Collections.Generic;
using System.Text;
using bookbee.Converters;
using bookbee.ViewModels;
using Xamarin.Forms;

namespace bookbee.Views
{
    public class OcrPage : ContentPage
    {
        public OcrPage()
        {

         

           BindingContext = new ComputerVisionViewModel();

            var takePhotoButton = new Button
            {
                TextColor = Color.FromHex("#990033"),
                ImageSource = "camera.png",
                Text = "  Capture",
                Margin = 9,
              
                CornerRadius = 5,
                BackgroundColor = Color.FromHex("#f2f2f2"),
              
            };
            takePhotoButton.SetBinding(Button.CommandProperty, "TakePhotoCommand");

            var pickPhotoButton = new Button
            {

                TextColor = Color.FromHex("#990033"),
                ImageSource = "img.png",
                Text = "  Upload",
                Margin = 9,
                CornerRadius = 5,
                BackgroundColor = Color.FromHex("#f2f2f2"),

            };
            pickPhotoButton.SetBinding(Button.CommandProperty, "PickPhotoCommand");

            var imageUrlEntry = new Entry
            {
                FontSize = 17,
                TextColor = Color.Blue,
              

            };
            imageUrlEntry.SetBinding(Entry.TextProperty, "ImageUrl");

            var image = new Image
            {
                HeightRequest = 301
            };
            image.SetBinding(Image.SourceProperty, "ImageUrl");



           var extractTextFromImageStreamButton = new Button
            {
                TextColor = Color.FromHex("#990033"),
                ImageSource = "ic_action_search.png",
                Text = "  Search",
               // WidthRequest = 150,
                //HeightRequest = 70,
                CornerRadius = 5,
                Margin = 20,
                BackgroundColor = Color.FromHex("#f2f2f2"),

            };
            extractTextFromImageStreamButton.SetBinding(Button.CommandProperty, "ExtractTextFromImageStreamCommand");

            var isBusyActivityIndicator = new ActivityIndicator();
            isBusyActivityIndicator.SetBinding(ActivityIndicator.IsRunningProperty, "IsBusy");
            isBusyActivityIndicator.SetBinding(ActivityIndicator.IsEnabledProperty, "IsBusy");
            isBusyActivityIndicator.SetBinding(ActivityIndicator.IsVisibleProperty, "IsBusy");

            var errorMessageLabel = new Label
            {
                TextColor = Color.Red,
                FontSize = 15
            };
            errorMessageLabel.SetBinding(Label.TextProperty, "ErrorMessage");

            var languageLabel = new Label
            {
                TextColor = Color.Maroon,
                FontSize = 17
            };
            languageLabel.SetBinding(Label.TextProperty, new Binding(
                "OcrResult.Language",
                BindingMode.Default,
                null,
                null,
                "Language: {0:F0}"));

            /* var textAngleLabel = new Label
             {
                 TextColor = Color.Teal,
                 FontSize = 20
             };
             textAngleLabel.SetBinding(Label.TextProperty, new Binding(
                 "OcrResult.TextAngle",
                 BindingMode.Default,
                 null,
                 null,
                 "TextAngle: {0:F0}"));

             var orientationLabel = new Label
             {
                 TextColor = Color.Teal,
                 FontSize = 20
             };
             orientationLabel.SetBinding(Label.TextProperty, new Binding(
                 "OcrResult.Orientation",
                 BindingMode.Default,
                 null,
                 null,
                 "Orientation: {0:F0}"));

             //var tagsLabel = new Label
             //{
             //    TextColor = Color.Green,
             //    FontSize = 20
             //};
             //tagsLabel.SetBinding(Label.TextProperty, new Binding(
             //    "ImageResult.Description.Tags",
             //    BindingMode.Default,
             //    new ListOfStringToOneStringConverter(),
             //    null,
             //    "TAGS: {0:F0}"));*/

            var regionDataTemplate = new DataTemplate(() =>
            {
                /* var boundingBoxLabel = new Label
                 {
                     TextColor = Color.Black,
                     FontSize = 20
                 };
                 boundingBoxLabel.SetBinding(Label.TextProperty, new Binding(
                     "BoundingBox",
                     BindingMode.Default,
                     null,
                     null,
                     "BoundingBox: {0:F0}"));*/

                var linesLabel = new Label
                {
                    TextColor = Color.Maroon,
                    FontSize = 17
                };
                linesLabel.SetBinding(Label.TextProperty, new Binding(
                    "Lines",
                    BindingMode.Default,
                    new ListOfLinesToOneStringConverter(),
                    null,
                    "Extracted Text: {0:F0}"));

                var faceStackLayout = new StackLayout
                {
                    Padding = 5,
                    Children =
                    {
                        //boundingBoxLabel,
                        linesLabel
                    }
                };

                return new ViewCell
                {
                    View = faceStackLayout
                };
            });

            var regionsListView = new ListView
            {
                HasUnevenRows = true,
                ItemTemplate = regionDataTemplate
            };
            regionsListView.SetBinding(ListView.ItemsSourceProperty, "OcrResult.Regions");

            var stackLayout = new StackLayout
            {
                Padding = new Thickness(10, 0),
                Children =
                {
                    new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        Margin = 21,
                        Children =
                        {
                            takePhotoButton,
                            pickPhotoButton
                        }
                    },
                  
                    image,
                    imageUrlEntry,
                    extractTextFromImageStreamButton,
                    isBusyActivityIndicator,
                    errorMessageLabel,
                    languageLabel,
                   // textAngleLabel,
                    //orientationLabel,
                    regionsListView
                }
            };

            Content = new ScrollView
            {
                Content = stackLayout
            };
        }
    }
}