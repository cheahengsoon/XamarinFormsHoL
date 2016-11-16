using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XDayLab2
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.AgeInput.ValueChanged += AgeInput_ValueChanged;
            this.SaveBtn.Clicked += SaveBtn_Clicked;
            this.DialBtn.Clicked += DialBtn_Clicked;
        }

        private async void DialBtn_Clicked(object sender, EventArgs e)
        {
            if (await this.DisplayAlert("Dial a Number", "Call 123456789 ?", "Yes", "No"))
            {
                Device.OpenUri(new Uri("tel://123456789"));
            }
        }

        private void SaveBtn_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Message", "Save Data", "OK");
        }

        private void AgeInput_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            this.AgeVal.Text = ((int)this.AgeInput.Value).ToString();
        }
    }
}
