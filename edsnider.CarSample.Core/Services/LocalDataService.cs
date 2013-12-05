using edsnider.CarSample.Core.Model;
using edsnider.CarSample.Core.SampleData;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edsnider.CarSample.Core.Services
{
    public class LocalDataService : ILocalDataService
    {
        public IList<Car> GetCars()
        {
            IList<Car> items = new List<Car>();

            JObject o = JObject.Parse(SampleLocalDataSource.CarsJSON);

            IList<JToken> tokens = o["Cars"].Children().ToList();

            // Order the cars by their Number property
            //IOrderedEnumerable<JToken> orderedTokens = tokens.OrderByDescending(x => x["Number"].ToString());

            foreach (JToken t in tokens)
            {
                Car item = JsonConvert.DeserializeObject<Car>(t.ToString());

                items.Add(item);
            }

            return items;
        }
    }
}
