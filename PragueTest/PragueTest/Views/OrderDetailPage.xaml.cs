using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PragueTest.Models;
using PragueTest.Services;
using PragueTest.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PragueTest.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrderDetailPage : ContentPage
    {
        CreateOrderVM vm;

        public OrderDetailPage(Orders selectedOrder)
        {
            InitializeComponent();
            vm = Resources["vm"] as CreateOrderVM;
            vm.Orders = selectedOrder;
        }
    }
}