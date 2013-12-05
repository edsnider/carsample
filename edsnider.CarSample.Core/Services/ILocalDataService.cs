using edsnider.CarSample.Core.Model;
using System;
using System.Collections.Generic;

namespace edsnider.CarSample.Core.Services
{
    public interface ILocalDataService
    {
        IList<Car> GetCars();
    }
}
