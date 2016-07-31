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
