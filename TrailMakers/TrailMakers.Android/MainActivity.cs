using Android.App;
using Android.Content.PM;
using Android.OS;

namespace TrailMakers.Droid
{
    [Activity(Label = "TrailMakers", Icon = "@drawable/icon", Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            App.ScreenSize = new Xamarin.Forms.Size(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density, Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            global::Xamarin.FormsMaps.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}

