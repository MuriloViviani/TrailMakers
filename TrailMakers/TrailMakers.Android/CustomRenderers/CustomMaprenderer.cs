using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using TrailMakers.Custom;
using TrailMakers.Droid.CustomRenderers;
using TrailMakers.Droid.DependencyServices;
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
        List<CustomPin> pinsCoordinates;

        SaveAndLoad_Android fileService = new SaveAndLoad_Android();

        bool isDrawn;

        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                NativeMap.InfoWindowClick -= OnInfoWindowClick;
            }
            else
            {
                var formsMap = (CustomMap)e.NewElement;

                pinsCoordinates = formsMap.PinsCoordinates;
                routeCoordinates = formsMap.RouteCoordinates;

                Control.GetMapAsync(this);
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            if (changed)
            {
                isDrawn = false;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            string imageURL = null, imageURLAux = null;
            Bitmap imageBitmap = null;

            if (e.PropertyName.Equals("VisibleRegion") && !isDrawn)
            {
                NativeMap.Clear();

                var polylineOptions = new PolylineOptions();
                polylineOptions.InvokeColor(Android.Graphics.Color.Rgb(244, 67, 54));

                foreach (var position in routeCoordinates)
                {
                    polylineOptions.Add(new LatLng(position.Latitude, position.Longitude));
                }

                NativeMap.AddPolyline(polylineOptions);

                if (pinsCoordinates != null && pinsCoordinates.Count > 0)
                {

                    foreach (var pin in pinsCoordinates)
                    {
                        var marker = new MarkerOptions();
                        marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
                        marker.SetTitle(pin.Label);
                        marker.SetSnippet(pin.Address);

                        // TODO: Temporary
                        pin.IconUrl = "http://icons.iconarchive.com/icons/icons-land/vista-map-markers/96/Map-Marker-Marker-Outside-Chartreuse-icon.png";

                        imageURL = pin.IconUrl;
                        if (imageURL == "" || imageURL == null)
                            marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.location_pin));
                        else
                        {
                            if (imageURLAux != imageURL)
                            {
                                // chaca se o arquivo com o ícone ja existe, 
                                // é necessário remover as '/' e as '\' por conta do sistema de pastas
                                if (!fileService.CheckFile(pin.IconUrl.Replace("/", "_").Replace("\\", "_"), true))
                                {
                                    fileService.SaveImage(pin.IconUrl.Replace("/", "_").Replace("\\", "_"), pin.IconUrl);
                                    marker.SetIcon(BitmapDescriptorFactory.FromBitmap(fileService.LoadImage(pin.IconUrl.Replace("/", "_").Replace("\\", "_"))));
                                    //marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.location_pin));
                                }
                                else
                                {
                                    marker.SetIcon(BitmapDescriptorFactory.FromBitmap(fileService.LoadImage(pin.IconUrl.Replace("/", "_").Replace("\\", "_"))));
                                }
                            }
                            else
                            {
                                marker.SetIcon(BitmapDescriptorFactory.FromBitmap(imageBitmap));
                            }

                            NativeMap.AddMarker(marker);
                        }
                    }
                    isDrawn = true;
                }
            }
        }

        private void OnInfoWindowClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            var customPin = GetCustomPin(e.Marker);
            if (customPin == null)
                throw new Exception("pino_nao_encontrado");
        }

        private CustomPin GetCustomPin(Marker marker)
        {
            var position = new Position(marker.Position.Latitude, marker.Position.Longitude);
            foreach (var pin in pinsCoordinates)
            {
                if (pin.Position == position)
                {
                    return pin;
                }
            }
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }
    }
}