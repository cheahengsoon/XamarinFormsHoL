# Xamarin.Forms HoL - MasterDetailPage Page #

本Lab演示 Xamarin.Forms MasterDetail Page 開發漢堡功能選單，透過這個Lab 將學會如何使用 Xamarin.Forms 所提供的Page UI以及資料繫結。




- 建立 Xamarin.Forms Portable 專案（專案名稱：XMenuApp，接下來的過程將以這個名稱來稱呼本專案），若您的環境尚未設定與Mac 電腦的相關連線資訊時，則會出現對話視窗，提供您進行連線設定，您可以選擇直接忽略（但將無法進行iOS專案的建置與測試），接下來您會遇新的通用Windows專案 （UWP Project）設定版本的對話視窗，您可以直接按確定即可（在本Lab裡並不打算針對UWP進行詳解）。

![](http://i.imgur.com/WvG4BBG.jpg)


- 開啟Share Project，建立名為model的目錄，並在model目錄內建立AppMenuItem 類別如下

	    public class AppMenuItem
	    {
	        public String Name { get; set; }
	        public String Icon { get; set; }
	        public int No { get; set; }
	    }

- 同樣在model目錄內建立Employee 類別如下

		public class Employee
	    {
	        public String Name { get; set; }
	        public String Title { get; set; }
	    }

- 接著於Share Project (XMenuApp)專案內，新增一個Xamarin.Forms Xaml Page，命名為MenuPage

![](http://i.imgur.com/JhCAl8F.jpg)


- 開啟MenuPage.xaml，並用以下XAML內容取代，在這個Page裡面我們放置了一個ListView資料容器元件，後續將運用資料繫結的方式來加入功能選單的項目

    	<?xml version="1.0" encoding="utf-8" ?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
		             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
		             x:Class="XMenuApp.MenuPage" Title="功能清單">
		  <ListView x:Name="MenuItems">
		    <ListView.ItemTemplate Padding="50,50,10,5">
		      <DataTemplate>
		        <TextCell Text="{Binding Name}"></TextCell>
		      </DataTemplate>
		    </ListView.ItemTemplate>
		  </ListView>
		</ContentPage>

- 開啟MenuPage.xaml.cs，並用以下程式碼取代，在這個程式裡我們建立了一個AppMenuItem資料集合，並將它繫結給ListView資料容器元件

	    using System;
		using System.Collections.Generic;
		using System.Collections.ObjectModel;
		using System.Linq;
		using System.Text;
		using System.Threading.Tasks;
		
		using Xamarin.Forms;
		using XMenuApp.Model;
		
		namespace XMenuApp
		{
		    public partial class MenuPage : ContentPage
		    {
		        public ListView MenuListItems { get { return MenuItems; } }
		
		        public MenuPage()
		        {
		            InitializeComponent();
		
		            ObservableCollection<AppMenuItem> menuitems = new ObservableCollection<AppMenuItem>() {
		                new AppMenuItem { Name = "EmpList", Icon = "",No=1 },
		                new AppMenuItem { Name = "News", Icon = "",No=2 },
		                new AppMenuItem { Name = "Setting", Icon = "",No=3 }
		            };
		            this.MenuItems.ItemsSource = menuitems;
		        }
		    }
		}

- 接著再新增一個Xamarin.Forms Xaml Page，命名為EmployeesPage，這個Page將做為第一個功能項的頁面。開啟EmployeesPage.xaml，並用以下XAML內容取代

		<?xml version="1.0" encoding="utf-8" ?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
		             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
		             x:Class="XMenuApp.EmployeesPage">
		  <ListView x:Name="EmployeeList">
		    <ListView.ItemTemplate Padding="10,50,10,5">
		      <DataTemplate>
		        <TextCell Text="{Binding Name}" Detail="{Binding Title}"></TextCell>
		      </DataTemplate>
		    </ListView.ItemTemplate>
		  </ListView>
		</ContentPage>

- 開啟EmployeesPage.xaml.cs，並用以下程式碼取代，在這個程式裡我們建立了一個Employee資料集合，並將它繫結給ListView資料容器元件

		using System;
		using System.Collections.Generic;
		using System.Collections.ObjectModel;
		using System.Linq;
		using System.Text;
		using System.Threading.Tasks;
		
		using Xamarin.Forms;
		using XMenuApp.Model;
		
		namespace XMenuApp
		{
		    public partial class EmployeesPage : ContentPage
		    {
		        public EmployeesPage()
		        {
		            InitializeComponent();
		
		            ObservableCollection<Employee> employees = new ObservableCollection<Employee>() {
		                new Employee { Name = "Ian", Title = "RD" },
		                new Employee { Name = "Andy", Title = "Boss" },
		                new Employee { Name = "Joe", Title = "PG" },
		                new Employee { Name = "Allen", Title = "PG" }
		            };
		            this.EmployeeList.ItemsSource = employees;
		        }
		    }
		}

- 接著同樣的方式，我們將再新增二個Xamarin.Forms Xaml Page，分別命名為NewsPage與SettingPage，其xaml內容分別如下

(1) NewsPage

		<?xml version="1.0" encoding="utf-8" ?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
		             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
		             x:Class="XMenuApp.NewsPage">
		  <Label Text="News Page" VerticalOptions="Center" HorizontalOptions="Center" />
		</ContentPage>

(2) SettingPage

		<?xml version="1.0" encoding="utf-8" ?>
		<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
		             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
		             x:Class="XMenuApp.SettingPage">
		  <Label Text="Setting Page" VerticalOptions="Center" HorizontalOptions="Center" />
		</ContentPage>

- 開啟Share Project (XMenuApp)裡的MainPage.xaml，並用以下XAML內容取代，在這裡我們將原本預設的ContentPage元件改為MasterDetailPage元件
    
		<?xml version="1.0" encoding="utf-8" ?>
		<MasterDetailPage xmlns="http://xamarin.com/schemas/2014/forms"
		             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
		             xmlns:local="clr-namespace:XMenuApp;assembly=XMenuApp"
		             x:Class="XMenuApp.MainPage"
		            Title="首頁">
		</MasterDetailPage>

- 開啟Share Project (XMenuApp)裡的MainPage.xaml.cs，並用以下程式碼取代。

> 
> (1) MenuPage menupage = new MenuPage( )，建立一個MenuPage的全域實例變數
> 
> (2) MasterDetailPage元件，有二個重要的屬性必須設置，分別是Master及Detail，Master屬性是用來呈現功能選單，而Detail屬性則是功能選項實際要呈現的頁面，在這裡我們將menupage指給Master屬性，而Detail則建立NavigationPage實例，並且產生EmployeesPage實例，傳入NavigationPage建構子參數，表示一開始我們將以EmployeesPage做為功能預設頁面。
> 
> (3) 另外我們也加入了功能選單ListView的ItemSelected事件，在ItemSelected事件裡針對使用者選擇功能項目時，可以切換到相對應的功能頁面，在這裡利用的是AppMenuItem物件的No屬性做為判斷，而IsPresented屬性則是通知功能選單可以收合起來。

	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Xamarin.Forms;
	using XMenuApp.Model;
	
	namespace XMenuApp
	{
	    public partial class MainPage : MasterDetailPage
	    {
	        MenuPage menupage = new MenuPage();
	
	        public MainPage()
	        {
	            InitializeComponent();
	
	            this.Master = menupage;
	            this.Detail= new NavigationPage(new EmployeesPage());
	            menupage.MenuListItems.ItemSelected += MenuListItems_ItemSelected;     
	        }
	
	        private void MenuListItems_ItemSelected(object sender, SelectedItemChangedEventArgs e)
	        {
	            var item = e.SelectedItem as AppMenuItem;
	
	            if (item != null)
	            {
	                switch (item.No)
	                {
	                    case 1:
	                        this.Detail = new NavigationPage(new EmployeesPage());
	                        menupage.MenuListItems.SelectedItem = null;
	                        this.IsPresented = false;
	                        break;
	                    case 2:
	                        this.Detail = new NavigationPage(new NewsPage());
	                        menupage.MenuListItems.SelectedItem = null;
	                        this.IsPresented = false;
	                        break;
	                    case 3:
	                        this.Detail = new NavigationPage(new SettingPage());
	                        menupage.MenuListItems.SelectedItem = null;
	                        this.IsPresented = false;
	                        break;
	                }
	            }
	        }
	    }
	}

- 完成之後就可以選擇以模擬器來進行功能測試，以下是Android 的執行結果畫面。

![](http://i.imgur.com/NhbA73M.jpg)

![](http://i.imgur.com/qLbHoZd.jpg)



