using System;
using System.Text;
using TrailMakers.Business;
using TrailMakers.Business.Interface;
using TrailMakers.Custom;
using TrailMakers.Entity;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TrailMakers.UI.MapView
{
    public class RunDetailPage : ContentPage
    {
        CustomMap customMap;
        Button btnStopRun;

        private ISaveAndLoad fileServices = DependencyService.Get<ISaveAndLoad>();
        private ILocate locator = DependencyService.Get<ILocate>();

        ApiRequestN apiServices = new ApiRequestN();

        public RunDetailPage(RaceInfo raceInfo)
        {
            Title = raceInfo.Name;
            BackgroundColor = Color.White;

            customMap = new CustomMap
            {
                IsShowingUser = true,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HasZoomEnabled = false,
                HasScrollEnabled = false,
            };

            if (raceInfo.Poi.Count > 0)
            {
                foreach (var poi in raceInfo.Poi)
                {
                    customMap.PinsCoordinates.Add(new CustomPin()
                    {
                        Position = new Position(poi.Latitude, poi.Longitude),
                        Label = poi.Type.ToString(),
                        Id = poi.Type,
                        IconUrl = poi.IconUlr,
                        Poi = new POI()
                        {
                            Description = poi.Description,
                            Type = poi.Type
                        }
                    });
                }
            }

            if (raceInfo.TrailPath.Count > 0)
            {
                foreach (var pos in raceInfo.TrailPath)
                {
                    customMap.RouteCoordinates.Add(new Position(pos.Latitude, pos.Longitude));
                }
            }

            var lblName = new Label
            {
                Text = raceInfo.Name,
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
            if (!System.String.IsNullOrEmpty(raceInfo.StartTime.ToString()))
            {
                sb.Append("Ultima vez visitada\n\t");
                sb.Append(raceInfo.StartTime.ToString("dd/MM/yyyy"));
                sb.Append("\n");
            }
            if (!System.String.IsNullOrEmpty(raceInfo.Distance.ToString()))
            {
                sb.Append("Distancia Total\n\t");
                sb.Append(raceInfo.Distance);
                sb.Append("\n");
            }
            if (!System.String.IsNullOrEmpty(raceInfo.StartTime.ToString("dd/MM/yyyy")))
            {
                sb.Append("Tempo decorrido\n\t");
                sb.Append(raceInfo.StartTime.ToString("dd/MM/yyyy"));
            }
            lblInfo.Text = sb.ToString();

            double mapLatitude = 0, mapLongitude = 0;
            if (raceInfo.TrailPath.Count > 0)
            {
                foreach (var item in raceInfo.TrailPath)
                {
                    mapLatitude += item.Latitude;
                    mapLongitude += item.Longitude;
                    customMap.RouteCoordinates.Add(new Position(item.Latitude, item.Longitude));
                }
                mapLatitude = mapLatitude / raceInfo.TrailPath.Count;
                mapLongitude = mapLongitude / raceInfo.TrailPath.Count;

                customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(mapLatitude, mapLongitude), Distance.FromKilometers(2)));
            }
            else
            {
                var place = locator.GetLocation();
                if (place == null)
                    customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(0, 0), Distance.FromKilometers(1)));
                else
                {
                    customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(place.Latitude, place.Longitude), Distance.FromKilometers(1)));
                    mapLatitude = place.Latitude;
                    mapLongitude = place.Longitude;
                }
            }

            btnStopRun = new Button()
            {
                Text = "Finalizar Corrida",
                BackgroundColor = Color.FromHex("#F44336")
            };
            btnStopRun.Clicked += async delegate
            {
                var x = await DisplayAlert("Hey Hey!", "Tem Certeza que quer finalizar esta corrida?", "Yup!", "Nop!");
                if (x)
                {
                    await apiServices.AddToUserHistoricAsync(new Historic()
                    {
                        Name = lblName.Text,
                        Date = raceInfo.StartTime.ToString("dd/MM/yyyy"),
                        Description = lblInfo.Text,
                        Distance = raceInfo.Distance.ToString(),
                        Poi = raceInfo.Poi,
                        TimeSpent = "", // TODO: Add the time calc
                        TrailPath = raceInfo.TrailPath,
                        MainLatitude = mapLatitude,
                        MainLongitude = mapLongitude
                    });

                    await Navigation.PopToRootAsync();
                }
            };

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
                    },
                    btnStopRun
                }
            };
        }
    }
}