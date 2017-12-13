using System;
using Android.Content;
using TrailMakers.Business.Interface;
using TrailMakers.Droid.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(Intent_Android))]
namespace TrailMakers.Droid.DependencyServices
{
    public class Intent_Android : IIntent
    {
        public void Navigator(string link)
        {
            var uri = Android.Net.Uri.Parse(link);
            var intent = new Intent(Intent.ActionView, uri);
            Forms.Context.StartActivity(intent);
        }

        public void PlaceNavigation(string latitude, string longitude)
        {
            var routeURI = Android.Net.Uri.Parse("google.navigation:q=" + latitude.Replace(",", ".") + "," + longitude.Replace(",", "."));
            var routeURIIntent = new Intent(Intent.ActionView, routeURI);

            Forms.Context.StartActivity(routeURIIntent);
        }
    }
}