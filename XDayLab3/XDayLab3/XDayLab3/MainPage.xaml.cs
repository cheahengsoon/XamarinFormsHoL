using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XDayLab3.Services;

namespace XDayLab3
{
    public partial class MainPage : CarouselPage
    {
        public MainPage()
        {
            InitializeComponent();

            var empservice = new EmployeeService();
            ItemsSource = empservice.GetAllEmployees();
        }
    }
}
