# Xamarin.Forms HoL - DI Service #

延續 [Xamarin.Forms MasterDetail Page Lab](https://github.com/iangithub/Xamarin-Forms-HoL/blob/master/Xamarin%20Forms%20HoL%20-%20MD%20Page.md)，加入相依性服務（DependencyService）來取得設備的螢幕方向性資料，借以演示Xamarin.Forms相依性服務注入機制。

- 首先在Share Project的Model目錄內，新增一個介面IDeviceOrientation，並且定義一個GetOrientation方法，程式碼如下。

		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		using System.Threading.Tasks;
		
		namespace XMenuApp.Model
		{
		    public enum DeviceOrientations
		    {
		        Undefined,
		        Landscape,
		        Portrait
		    }
		    public interface IDeviceOrientation
		    {
		        DeviceOrientations GetOrientation();
		    }
		}

- 接著在android App專案(XMenuApp.Droid)，同樣新增一個Model目錄，並加入一個DeviceOrientationAndroid類別，然後繼承IDeviceOrientation介面，並且實作GetOrientation方法。

> 特別注意，除了實作GetOrientation方法之外，必須在namespace上方加入assembly屬性宣告

		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		
		using Android.App;
		using Android.Content;
		using Android.OS;
		using Android.Runtime;
		using Android.Views;
		using Android.Widget;
		using XMenuApp.Model;
		using XMenuApp.Droid.Model;
		
		[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientationAndroid))]
		namespace XMenuApp.Droid.Model
		{
		    public class DeviceOrientationAndroid : IDeviceOrientation
		    {
		        DeviceOrientations IDeviceOrientation.GetOrientation()
		        {
		            IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
		
		            var rotation = windowManager.DefaultDisplay.Rotation;
		            bool isLandscape = rotation == SurfaceOrientation.Rotation90 || rotation == SurfaceOrientation.Rotation270;
		            return isLandscape ? DeviceOrientations.Landscape : DeviceOrientations.Portrait;
		        }
		    }
		}

- 同樣的在UWP專案(XMenuApp.UWP)如法泡製，加入一個DeviceOrientationUWP類別，然後繼承IDeviceOrientation介面，並且實作GetOrientation方法。


> 特別注意，除了實作GetOrientation方法之外，必須在namespace上方加入assembly屬性宣告

		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		using System.Threading.Tasks;
		using Xamarin.Forms;
		using XMenuApp.Model;
		using XMenuApp.UWP.Model;
		
		[assembly: Dependency(typeof(DeviceOrientationUWP))]
		namespace XMenuApp.UWP.Model
		{
		    public class DeviceOrientationUWP : IDeviceOrientation
		    {
		        DeviceOrientations IDeviceOrientation.GetOrientation()
		        {
		            var orientation = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().Orientation;
		            if (orientation == Windows.UI.ViewManagement.ApplicationViewOrientation.Landscape)
		            {
		                return DeviceOrientations.Landscape;
		            }
		            else
		            {
		                return DeviceOrientations.Portrait;
		            }
		        }
		    }
		}

- 接著回到Share Project，開啟SettingPage.xaml，並用以下XAML內容取代，在這個Page裡面我們放置了一個按鈕元件。

		<?xml version="1.0" encoding="utf-8" ?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
		             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
		             x:Class="XMenuApp.SettingPage">
		
		  <StackLayout>
		    <Label Text="Setting Page" VerticalOptions="Center" HorizontalOptions="Center" />
		    <Button Text="GetOrientation" x:Name="orientationbtn" HorizontalOptions="FillAndExpand" />
		  </StackLayout>
		</ContentPage>

- 接著修改SettingPage.xaml.cs，並用以下程式碼取代，在按鈕click事件裡，我們把設備的螢幕方向性利用訊息框的方式顯示出來。

> DependencyService提供了一個Get靜態方法，來取得目前實際實作IDeviceOrientation介面的類別實例。

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

![](http://i.imgur.com/0kNKpfq.jpg)
