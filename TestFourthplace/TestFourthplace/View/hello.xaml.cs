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
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class hello : ContentPage
    {
        public hello()
        {
            BindingContext = new ViewModelLieux();
            //ViewModelLieux L = new ViewModelLieux();
            
            //L.NavigateToBuilding25();
            
         
            
            InitializeComponent();
        }
    }
}