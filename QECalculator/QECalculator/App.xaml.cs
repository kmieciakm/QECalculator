using QECalculator.Pages.QECalculator;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace QECalculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new QECalculatorPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
