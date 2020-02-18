using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFourthplace.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestFourthplace.View
{
   
    public partial class ViewLogin : ContentPage
    {
        public ViewLogin()
        {
            BindingContext = new ViewModelLogin();
            InitializeComponent();
        }
    }
}