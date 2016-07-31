using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using XMenuApp.Model;

namespace XMenuApp
{
    public partial class SettingPage : ContentPage
    {
        public SettingPage()
        {
            InitializeComponent();
            this.orientationbtn.Clicked += Orientationbtn_Clicked;
            this.camerabtn.Clicked += async (sender, args) =>
             {

                 if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                 {
                     DisplayAlert("No Camera", ":( No camera available.", "OK");
                     return;
                 }

                 var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                 {
                     Directory = "Sample",
                     Name = "test.jpg"
                 });

                 if (file == null)
                     return;

                 DisplayAlert("File Location", file.Path, "OK");

                 this.myimg.Source = ImageSource.FromStream(() =>
                 {
                     var stream = file.GetStream();
                     file.Dispose();
                     return stream;
                 });
             };
        }

        private void Orientationbtn_Clicked(object sender, EventArgs e)
        {
            var orientation = DependencyService.Get<IDeviceOrientation>().GetOrientation();
            switch (orientation)
            {
                case DeviceOrientations.Undefined:
                    DisplayAlert("Message", "Undefined", "OK");
                    break;
                case DeviceOrientations.Landscape:
                    DisplayAlert("Message", "橫向", "OK");
                    break;
                case DeviceOrientations.Portrait:
                    DisplayAlert("Message", "直向", "OK");
                    break;
            }
        }
    }
}
