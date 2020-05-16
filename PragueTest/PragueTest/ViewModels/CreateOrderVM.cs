using PragueTest.Models;
using PragueTest.Services;
using PragueTest.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PragueTest.ViewModels
{
    public class CreateOrderVM : INotifyPropertyChanged
    {
        public Command CreateOrdercmd { get; set; }
        public Command ListAllOrderscmd { get; set; }
        public Command DeleteOrdercmd { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        //public List<Orders> AllOrdersList = new List<Orders>();

        private Orders orders;

        public Orders Orders
        {
            get { return orders; }
            set { orders = value;
                RegistrationNumber = orders.RegistrationNumber;
                ParkingSpot = orders.ParkingSpot;
                OnPropertyChanged("Orders");
                }
        }



        private string registrationNumber;
        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set { registrationNumber = value;
                OnPropertyChanged("RegistrationNumber");
            }
        }

        private string parkingSpot;
        CrudHelper helper = new CrudHelper();
  
        public string ParkingSpot
        {
            get { return parkingSpot; }
            set { parkingSpot = value; OnPropertyChanged("ParkingSpot"); }
        }



        public CreateOrderVM()
        {
            CreateOrdercmd = new Command(async () => await helper.CreateOrder(RegistrationNumber, ParkingSpot));
            ListAllOrderscmd = new Command(async () => await helper.SeeAllOrders());
            DeleteOrdercmd = new Command(async () => await helper.DeleteOrder(SelectedOrder));
        }

        private Orders selectedOrder;

        public Orders SelectedOrder
        {
            get { return selectedOrder; }
            set
            {
                selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
                if (selectedOrder != null)
                {
                    App.Current.MainPage.Navigation.PushAsync(new OrderDetailPage(selectedOrder));
                }
            }
        }


        //public async Task CreateOrder()
        //{
        //    var db = new SQLiteConnection(Constants.DatabasePath, Constants.Flags);
        //    db.CreateTable<Orders>();

        //    var maxPk = db.Table<Orders>().OrderByDescending(c => c.ID).FirstOrDefault();

        //    Orders order = new Orders()
        //    {
        //        ID = (maxPk == null ? 1 : maxPk.ID + 1), //om det inte finns ett item med id sålägger den till ett item med id 1, sen +1 för varje
        //        RegistrationNumber = RegistrationNumber,
        //        ParkingSpot = ParkingSpot
        //    };

        //    AllOrdersList.Add(order);

        //    foreach (var item in AllOrdersList)
        //    {
        //        db.Insert(item);
        //    }

        //    await App.Current.MainPage.DisplayAlert(null, order.RegistrationNumber + " Saved", "OK");
        //    await Application.Current.MainPage.Navigation.PopAsync();
        //}


        //private async Task SeeAllOrders()
        //{
        //     //= db.Table<Orders>().OrderBy(x => x.RegistrationNumber).ToList();
        //    await Application.Current.MainPage.Navigation.PushAsync(new GetAllOrdersPage());
        //}


        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
