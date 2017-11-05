using Android.Content;
using TrailMakers.Business.Interface;
using TrailMakers.Droid.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof(IIntent_Android))]
namespace TrailMakers.Droid.DependencyServices
{
    public class IIntent_Android : IIntent
    {
        public void Navigator(string link)
        {
            var uri = Android.Net.Uri.Parse(link);
            var intent = new Intent(Intent.ActionView, uri);
            Forms.Context.StartActivity(intent);
        }
    }
}