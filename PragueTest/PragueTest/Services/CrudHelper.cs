using PragueTest.Models;
using PragueTest.ViewModels;
using PragueTest.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PragueTest.Services
{
    public class CrudHelper : INotifyPropertyChanged
    {
        public List<Orders> AllOrdersList = new List<Orders>();
        

        #region TASK CreateOrder()
        public async Task CreateOrder(string RegNR, string ParkSpot)
        {
            var db = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            db.CreateTable<Orders>();

            var maxPk = db.Table<Orders>().OrderByDescending(c => c.ID).FirstOrDefault();

            Orders order = new Orders()
            {
                ID = (maxPk == null ? 1 : maxPk.ID + 1), //om det inte finns ett item med id sålägger den till ett item med id 1, sen +1 för varje
                RegistrationNumber = RegNR,
                ParkingSpot = ParkSpot
            };

            AllOrdersList.Add(order);

            foreach (var item in AllOrdersList)
            {
                db.Insert(item);
            }

            await App.Current.MainPage.DisplayAlert(null, order.RegistrationNumber + " Saved", "OK");
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        #endregion

        #region Task SeeALLOrders()
        public async Task SeeAllOrders()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new GetAllOrdersPage());
        }
        #endregion

        public async Task UpdateOrder(string RegNr, string ParkSpot)
        {
            var db = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        

        public async Task DeleteOrder(Orders selectedOrder)
        {
            var db = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
            db.Delete(selectedOrder);
            await Application.Current.MainPage.DisplayAlert("ALERT!", "Do you want to DELETE?", "YES", "NO");
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

