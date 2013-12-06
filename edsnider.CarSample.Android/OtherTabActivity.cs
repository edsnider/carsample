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

namespace edsnider.CarSample.Android
{
    [Activity(Label = "Other Tab Activity")]
    public class OtherTabActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            TextView textView = new TextView(this);
            textView.Text = "What did you expect to see here?";
            SetContentView(textView);
        }
    }
}