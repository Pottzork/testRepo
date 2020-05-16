using PragueTest.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PragueTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }


        private async void CreateOrderButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddOrderPage());
        }

        private async void SeeOrdersButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GetAllOrdersPage());
        }
    }
}