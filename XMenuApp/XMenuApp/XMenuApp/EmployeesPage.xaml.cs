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
