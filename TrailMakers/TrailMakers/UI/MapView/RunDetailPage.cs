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

            var time = DateTime.Now - raceInfo.StartTime;

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
                    var pin = new CustomPin()
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
                    };

                    pin.InfoClicked += (sender) =>
                    {
                        var pinSelected = sender;
                        Navigation.PushModalAsync(new POIView(pinSelected));
                    };

                    customMap.PinsCoordinates.Add(pin);
                }
            }

            if (raceInfo.TrailPath.Count > 0)
            {
                foreach (var pos in raceInfo.TrailPath)
                {
                    customMap.RouteCoordinates.Add(new Position(pos.Latitude, pos.Longitude));
                }
            }

            var txtName = new Entry
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

            var txtTrailDetail = new Editor()
            {
                VerticalOptions = LayoutOptions.StartAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "Fale mais sobre sua trilha"
            };

            StringBuilder sb = new StringBuilder();
            if (!String.IsNullOrEmpty(raceInfo.StartTime.ToString()))
            {
                sb.Append("Ultima vez visitada\n\t");
                sb.Append(raceInfo.StartTime.ToString("dd/MM/yyyy"));
                sb.Append("\n");
            }
            if (!String.IsNullOrEmpty(raceInfo.Distance.ToString()))
            {
                sb.Append("Distancia Total\n\t");
                sb.Append(raceInfo.Distance);
                sb.Append("\n");
            }
            if (!String.IsNullOrEmpty(time.ToString()))
            {
                sb.Append("Tempo decorrido\n\t");
                sb.Append(time.ToString());
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
                    raceInfo.TrailPath.Add(new Location(mapLatitude, mapLongitude));
                    raceInfo.TrailPath.Add(new Location(mapLatitude, mapLongitude));
                    raceInfo.Poi.Add(new POI()
                    {
                        Type = DataAndHelper.Data.PinType.Begin,
                        Latitude = mapLatitude,
                        Longitude = mapLongitude
                    });
                    raceInfo.Poi.Add(new POI()
                    {
                        Type = DataAndHelper.Data.PinType.End,
                        Latitude = mapLatitude,
                        Longitude = mapLongitude
                    });
                }
            }

            btnStopRun = new Button()
            {
                Text = "Finalizar Corrida",
                BackgroundColor = Color.FromHex("#F44336"),
                TextColor = Color.White
            };
            btnStopRun.Clicked += async delegate
            {
                var x = await DisplayAlert("Hey Hey!", "Tem Certeza que quer finalizar esta corrida?", "Yup!", "Nop!");
                if (x)
                {
                    var hist = new Historic()
                    {
                        Name = txtName.Text,
                        Date = raceInfo.StartTime.ToString("dd/MM/yyyy"),
                        Description = lblInfo.Text,
                        Distance = raceInfo.Distance.ToString(),
                        Poi = raceInfo.Poi,
                        TimeSpent = time.ToString(),
                        TrailPath = raceInfo.TrailPath,
                        MainLatitude = mapLatitude,
                        MainLongitude = mapLongitude
                    };

                    if (!txtTrailDetail.Text.Equals("Fale mais sobre sua trilha"))
                    {
                        hist.Description = txtTrailDetail.Text;
                    }

                    await apiServices.AddToUserHistoricAsync(hist);
                    apiServices.SetLastTrail(new Historic() { Name = null });

                    await Navigation.PopToRootAsync();
                }
            };
            
            var layout = new StackLayout()
            {
                Spacing = 0,
                Children = {
                    customMap,
                    new StackLayout()
                    {
                        BackgroundColor = Color.FromHex("#3aa8ff"),
                        Padding = new Thickness(5,5,5,5),
                        Children = { txtName, lblInfo }
                    },
                    new StackLayout()
                    {
                        BackgroundColor = Color.White,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    },
                    txtTrailDetail,
                    btnStopRun
                }
            };

            Content = new ScrollView { Content = layout };
        }
    }
}