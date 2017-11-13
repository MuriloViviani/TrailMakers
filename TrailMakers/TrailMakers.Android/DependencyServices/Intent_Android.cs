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
    }
}