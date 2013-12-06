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

namespace edsnider.CarSample.Android.Adapters
{
    public class ObservableAdapter<T> : BaseAdapter
    {
        protected readonly Activity _context;
        protected readonly ObservableCollection<T> _items;

        public ObservableAdapter(Activity context, ObservableCollection<T> items)
        {
            this._context = context;
            this._items = items;
            this._items.CollectionChanged += (o, e) => NotifyDataSetChanged();
        }

        public override int Count
        {
            get { return this._items.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this._items[position];
            var view = (convertView ?? this._context.LayoutInflater.Inflate(Resource.Layout.listItem, parent, false)) as LinearLayout;

            SetTextView(view, Resource.Id.text, item.ToString());
            return view;
        }

        protected void SetTextView(LinearLayout view, int id, string text)
        {
            var textView = (TextView)view.FindViewById(id);
            textView.SetText(text, TextView.BufferType.Normal);
        }
    }
}