/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:EdSnider.HWC.Client.WP8"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using edsnider.CarSample.Core.Services;
using edsnider.CarSample.Core.ViewModel;
using edsnider.CarSample.WP8.View;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace edsnider.CarSample.WP8.ViewModel
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

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            //SimpleIoc.Default.Register<ISerializer, Serializer>();

            // Register Service Implementations
            SimpleIoc.Default.Register<ILocalDataService, LocalDataService>();
            //SimpleIoc.Default.Register<IAzureMobileService, AzureMobileService>();

            // New platform specific NavigationService instance
            //var navService = new WP8NavigationService(SimpleIoc.Default.GetInstance<ISerializer>());

            // Register ViewModel/View mappings in NavigationService instance
            //navService.Register(typeof(MainViewModel), typeof(MainView));
            //navService.Register(typeof(ItemDetailViewModel), typeof(ItemView));

            // Register NavigationService
            //SimpleIoc.Default.Register<INavigationService>(() => navService);

            // Register View Models
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
