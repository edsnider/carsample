using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Practices.ServiceLocation;
using edsnider.CarSample.Core.ViewModel;
using edsnider.CarSample.Android.Adapters;

namespace edsnider.CarSample.Android
{
    [Activity(Label = "Cars Tab Activity")]
    public class CarsTabActivity : ListActivity
    {
        private MainViewModel _vm;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this._vm = ServiceLocator.Current.GetInstance<MainViewModel>();
            ListAdapter = new CarsAdapter(this, this._vm.Items);
        }
    }
}