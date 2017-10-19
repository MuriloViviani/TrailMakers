using System;
using System.Text;
using TrailMakers.Custom;
using TrailMakers.Entity;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TrailMakers.UI.HistoricFeed
{
    public class HistoricDetailPage : ContentPage
    {
        CustomMap customMap;
        public HistoricDetailPage(Historic historic)
        {
            Title = historic.Name;
            BackgroundColor = Color.White;

            customMap = new CustomMap
            {
                IsShowingUser = true,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = App.ScreenSize.Height / 3
            };

            var lblName = new Label
            {
                Text = historic.Name,
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                HorizontalTextAlignment = TextAlignment.Start
            };

            var lblInfo = new Label()
            {
                TextColor = Color.White,
                FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.Start
            };

            StringBuilder sb = new StringBuilder();
            if (!String.IsNullOrEmpty(historic.Date))
            {
                sb.Append("Ultima vez vizitada\n\t");
                sb.Append(historic.Date);
                sb.Append("\n");
            }
            if (!String.IsNullOrEmpty(historic.Distance))
            {
                sb.Append("Distancia da ultima corrida\n\t");
                sb.Append(historic.Distance);
                sb.Append("\n");
            }
            if (!String.IsNullOrEmpty(historic.TimeSpent))
            {
                sb.Append("Tempo decorrido\n\t");
                sb.Append(historic.TimeSpent);
            }
            lblInfo.Text = sb.ToString();

            double mapLatitude = 0, mapLongitude = 0;
            foreach (var item in historic.TrailPath)
            {
                mapLatitude += item.Latitude;
                mapLongitude += item.Longitude;
                customMap.RouteCoordinates.Add(new Position(item.Latitude, item.Longitude));
            }
            mapLatitude = mapLatitude / historic.TrailPath.Count;
            mapLongitude = mapLongitude / historic.TrailPath.Count;

            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(mapLatitude, mapLongitude), Distance.FromKilometers(2)));

            Content = new StackLayout
            {
                Spacing = 0,
                Children = {
                    customMap,
                    new StackLayout()
                    {
                        BackgroundColor = Color.FromHex("#2196F3"),
                        Padding = new Thickness(5,5,5,5),
                        Children = { lblName, lblInfo }
                    },
                    new StackLayout()
                    {
                        BackgroundColor = Color.White,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    }
                }
            };
        }
    }
}