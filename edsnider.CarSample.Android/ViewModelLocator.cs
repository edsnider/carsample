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
using GalaSoft.MvvmLight.Ioc;
using edsnider.CarSample.Core.Services;
using edsnider.CarSample.Core.ViewModel;

namespace edsnider.CarSample.Android
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Register Service Implementations
            // NOTE both the interface and the implementation class both happen to be in the Core PCL in this case
            //  but typically the implementation class will be a platform specific implementation and reside in this
            //  platform library - as with Navigation
            SimpleIoc.Default.Register<ILocalDataService, LocalDataService>();

            // New platform specific NavigationService instance
            // TODO NavigationService for Android

            // Register ViewModel/View mappings in NavigationService instance

            // Register NavigationService

            // Register ViewModels
            SimpleIoc.Default.Register<MainViewModel>();
            //SimpleIoc.Default.Register<ItemDetailViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        //public ItemDetailViewModel ItemDetail
        //{
        //    get
        //    {
        //        return ServiceLocator.Current.GetInstance<ItemDetailViewModel>();
        //    }
        //}

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}