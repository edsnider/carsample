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
using System.Collections.ObjectModel;
using edsnider.CarSample.Core.Model;

namespace edsnider.CarSample.Android.Adapters
{
    public class CarsAdapter : ObservableAdapter<Car>
    {
        public CarsAdapter(Activity context, ObservableCollection<Car> items)
            : base(context, items)
        { }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this._items[position];
            var view = (convertView ?? this._context.LayoutInflater.Inflate(Resource.Layout.carListItem, parent, false)) as LinearLayout;

            // Bind item properties to the view
            SetTextView(view, Resource.Id.txt_number, item.Number);
            SetTextView(view, Resource.Id.txt_name, item.Name);

            return view;
        }
    }
}