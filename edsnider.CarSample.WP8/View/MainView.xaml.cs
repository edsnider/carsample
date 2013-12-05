using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using edsnider.CarSample.Core.ViewModel;

namespace edsnider.CarSample.WP8.View
{
    public partial class MainView : PhoneApplicationPage
    {
        public MainView()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.NavigationMode == NavigationMode.New)
            {
                var vm = this.DataContext as MainViewModel;
                vm.Init();
            }

            base.OnNavigatedTo(e);
        }
    }
}