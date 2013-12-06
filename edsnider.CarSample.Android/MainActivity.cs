using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using edsnider.CarSample.Core.ViewModel;

namespace edsnider.CarSample.Android
{
    [Activity(Label = "edsnider.CarSample.Android", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : TabActivity
    {
        private MainViewModel _vm;

        private string _currentTabId;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ViewModelLocator vml = new ViewModelLocator();
            this._vm = vml.Main;
            this._vm.Init();

            InitializeTabHost();
        }

        private void InitializeTabHost()
        {
            TabHost.AddTab(CreateNewTab("cars", "CARS", typeof(CarsTabActivity), Resource.Drawable.Icon));
            TabHost.AddTab(CreateNewTab("other", "OTHER", typeof(OtherTabActivity), Resource.Drawable.Icon));

            TabHost.TabChanged += TabHost_TabChanged;
        }

        void TabHost_TabChanged(object sender, TabHost.TabChangeEventArgs e)
        {
            this._currentTabId = e.TabId;
        }

        private TabHost.TabSpec CreateNewTab(string name, string title, Type type, int iconId = -1)
        {
            var intent = new Intent(this, type);
            intent.AddFlags(ActivityFlags.NewTask);

            var spec = TabHost.NewTabSpec(name);

            if (iconId < 0)
                spec.SetIndicator(title);
            else
                spec.SetIndicator(title, Resources.GetDrawable(iconId));

            spec.SetContent(intent);

            return spec;
        }
    }
}

