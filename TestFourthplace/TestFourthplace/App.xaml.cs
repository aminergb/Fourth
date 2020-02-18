using Storm.Mvvm;
using System;
using TestFourthplace.View;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestFourthplace
{
    public partial class App : MvvmApplication
    {
        public App() : base(() => new ViewLogin())

        {

            InitializeComponent();

        }

    }
}
