# Xamarin.Forms HoL - UIComponent #

延續 [Xamarin.Forms MasterDetail Page Lab](https://github.com/iangithub/Xamarin-Forms-HoL/blob/master/Xamarin%20Forms%20HoL%20-%20MD%20Page.md)，加入DateUI 以及button UI元件，透過這個Lab 將學會如何使用 Xamarin.Forms 所提供的UI Component以及使用Component事件。

- 首先Share Project的NewsPage.xaml，並用以下XAML內容取代，在這個Page裡面我們放置了一個DatePicker日期元件，以及一個按鈕元件。

		<?xml version="1.0" encoding="utf-8" ?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
		             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
		             xmlns:sys="clr-namespace:System;assembly=mscorlib"
		             x:Class="XMenuApp.NewsPage">
		  <StackLayout>
		    <DatePicker x:Name="querydate" VerticalOptions="CenterAndExpand" Date="{x:Static sys:DateTime.Now}">
		      <DatePicker.Format>yyyy-MM-dd</DatePicker.Format>
		      <DatePicker.MinimumDate>
		        <sys:DateTime x:FactoryMethod="Parse">
		          <x:Arguments>
		            <x:String>Jan 1 2000</x:String>
		          </x:Arguments>
		        </sys:DateTime>
		      </DatePicker.MinimumDate>
		      <DatePicker.MaximumDate>
		        <sys:DateTime x:FactoryMethod="Parse">
		          <x:Arguments>
		            <x:String>Dec 31 2050</x:String>
		          </x:Arguments>
		        </sys:DateTime>
		      </DatePicker.MaximumDate>
		    </DatePicker>
		    <Button Text="Query" x:Name="querybtn" HorizontalOptions="FillAndExpand" />
		  </StackLayout>
		</ContentPage>


- 接著修改NewsPage.xaml.cs，並用以下程式碼取代，在按鈕click事件裡，我們把使用者所選擇的日期值利用訊息框的方式顯示出來。

		using System;
		using System.Collections.Generic;
		using System.Linq;
		using System.Text;
		using System.Threading.Tasks;
		
		using Xamarin.Forms;
		
		namespace XMenuApp
		{
		    public partial class NewsPage : ContentPage
		    {
		        public NewsPage()
		        {
		            InitializeComponent();
		            this.querybtn.Clicked += Querybtn_Clicked;
		        }
		
		        private void Querybtn_Clicked(object sender, EventArgs e)
		        {
		            DisplayAlert("Message", this.querydate.Date.ToString(), "OK");
		        }
		    }
		}

- 完成之後就可以選擇以模擬器來進行功能測試。

(1) Android 的執行結果畫面

![](http://i.imgur.com/LUXGI4d.jpg)

(2) Windows 10 UWP 的執行結果畫面
![](http://i.imgur.com/FO1cftW.jpg)