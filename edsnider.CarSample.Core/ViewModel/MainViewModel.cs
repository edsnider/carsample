using edsnider.CarSample.Core.Model;
using edsnider.CarSample.Core.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edsnider.CarSample.Core.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ILocalDataService _localService;
        //private readonly INavigationService _navService;

        private ObservableCollection<Car> _items;

        private bool _isDataLoaded;

        public MainViewModel(ILocalDataService localService)
        {
            this._localService = localService;

            this._isDataLoaded = false;
        }

        #region Public Bindable Properties

        public ObservableCollection<Car> Items
        {
            get { return this._items; }
            set
            {
                this._items = value;
                base.RaisePropertyChanged("Items");
            }
        }

        #endregion

        public async Task Init()
        {
            if (!this._isDataLoaded)
            {
                this.Items = new ObservableCollection<Car>();

                // Get cars from the data service, order them by Number
                //IEnumerable<Car> items = (await this._mobileService.GetCars()).OrderBy(c => c.Number);
                IEnumerable<Car> items = (this._localService.GetCars()).OrderBy(c => c.Number);
                this.Items = new ObservableCollection<Car>(items);

                // Get distinct list of Years to use for filtering by year
                //List<string> years = (from i in items
                //                      orderby i.Year descending
                //                      select i.Year).Distinct().ToList();

                // Set flag after initial call to the service has been made to load ALL items
                this._isDataLoaded = true;
            }
        }

        #region Commands

        //private RelayCommand<object> _viewItemCommand;
        //public RelayCommand<object> ViewItemCommand
        //{
        //    get
        //    {
        //        return this._viewItemCommand ?? (this._viewItemCommand = new RelayCommand<object>(ExecuteViewItemCommand));
        //    }
        //}

        #endregion

        #region Command Execute Methods

        //public void ExecuteViewItemCommand(object item)
        //{
        //    this._navService.NavigateTo<ItemDetailViewModel, Car>(item);
        //}
        
        #endregion
    }
}
