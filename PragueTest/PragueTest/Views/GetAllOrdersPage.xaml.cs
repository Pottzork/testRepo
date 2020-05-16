using PragueTest.Models;
using PragueTest.Services;
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
    public partial class GetAllOrdersPage : ContentPage
    {
        public GetAllOrdersPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (var db = new SQLiteConnection(Constants.DatabasePath, Constants.Flags))
            {
                db.CreateTable<Orders>();
                var order = db.Table<Orders>().ToList();
                AllOrdersListView.ItemsSource = order;

            }
        }

    }
}