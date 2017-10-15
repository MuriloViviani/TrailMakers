using Android.Gms.Maps.Model;
using System.Collections.Generic;
using System.ComponentModel;
using TrailMakers.Custom;
using TrailMakers.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace TrailMakers.Droid.CustomRenderers
{
    public class CustomMapRenderer : MapRenderer
    {
        List<Position> routeCoordinates;
        bool isDrawn;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }
            else
            {
                var formsMap = (CustomMap)e.NewElement;
                routeCoordinates = formsMap.RouteCoordinates;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals("VisibleRegion") && !isDrawn)
            {
                var polylineOptions = new PolylineOptions();
                polylineOptions.InvokeColor(Android.Graphics.Color.Rgb(244, 67, 54));

                foreach (var position in routeCoordinates)
                {
                    polylineOptions.Add(new LatLng(position.Latitude, position.Longitude));
                }

                NativeMap.AddPolyline(polylineOptions);
                isDrawn = true;
            }
        }
    }
}