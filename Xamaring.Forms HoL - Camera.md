# Xamarin.Forms HoL - Camera #

延續 [Xamarin.Forms MasterDetail Page Lab](https://github.com/iangithub/Xamarin-Forms-HoL/blob/master/Xamarin%20Forms%20HoL%20-%20MD%20Page.md)，加入拍照功能，透過這個Lab 將學會如何使用 Xamarin 所提供的[Component plugin](https://components.xamarin.com/)。

- 首先透過NuGet來取得Xamarin所提供的Component plugin　—　Xam.Plugin.Media，安裝完成後，通常在readme.txt裡，你可以找到簡單的Sample Code，可以做為開發上的參考範例。 。

![](http://i.imgur.com/GbnUP8c.jpg)

- 安裝完成後，通常在readme.txt裡，你可以找到簡單的Sample Code，可以做為開發上的參考範例。

![](http://i.imgur.com/5xadkql.jpg)

- 開啟SettingPage.xaml，加入一顆button做為啟動拍照功能的按鈕，另外也放置一個Image元件，做為顯示照片之用，完整的xaml如下。

		<?xml version="1.0" encoding="utf-8" ?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
		             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
		             x:Class="XMenuApp.SettingPage">
		
		  <StackLayout>
		    <Label Text="Setting Page" VerticalOptions="Center" HorizontalOptions="Center" />
		    <Button Text="GetOrientation" x:Name="orientationbtn" HorizontalOptions="FillAndExpand" />
		    <Button Text="Camera" x:Name="camerabtn" HorizontalOptions="FillAndExpand" />
			<Image x:Name="myimg"></Image>
		  </StackLayout>
		</ContentPage>

- 接著修改SettingPage.xaml.cs，撰寫button的click事件，由於拍照一個是非同步的作業，所以button的click事件我們所撰寫也是個非同步的方法，程式碼如下。

> 
CrossMedia.Current.IsCameraAvailable以及CrossMedia.Current.IsTakePhotoSupported 用來判斷設備是否支援照相。

> CrossMedia.Current.TakePhotoAsync 則是Xam.Plugin.Media Component plugin提供照相的非同步方法，並且將拍好的照片指定儲存的目錄及名稱，完成後傳回Media物件。

> 最後透過Media物件的GetStream()方法，將Stream 資料繫結到 Image元件的Source屬性上，來顯示照片。

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

- 完成之後就可以選擇以模擬器來進行功能測試，Android 的執行結果畫面。

![](http://i.imgur.com/GzJoxUc.jpg)

