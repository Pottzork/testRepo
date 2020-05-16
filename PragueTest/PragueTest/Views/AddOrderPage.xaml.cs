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
    public partial class AddOrderPage : ContentPage
    {
        public AddOrderPage()
        {
            InitializeComponent();
        }

        public AddOrderPage(INavigation navigation)
        {
            InitializeComponent();
            BindingContext = new AddOrderPage(Navigation);
        }


    }
}