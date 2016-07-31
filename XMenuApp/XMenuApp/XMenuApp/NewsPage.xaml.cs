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
