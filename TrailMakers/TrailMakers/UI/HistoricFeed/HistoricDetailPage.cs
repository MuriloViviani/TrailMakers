using System;
using System.Text;
using TrailMakers.Business;
using TrailMakers.Business.Interface;
using TrailMakers.Custom;
using TrailMakers.Entity;
using TrailMakers.UI.MapView;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TrailMakers.UI.HistoricFeed
{
    public class HistoricDetailPage : ContentPage
    {
        CustomMap customMap;
        Button btnStartRun;
        IIntent intentServices = DependencyService.Get<IIntent>();
        ISaveAndLoad fileServices = DependencyService.Get<ISaveAndLoad>();
        ILocate locator = DependencyService.Get<ILocate>();

        ApiRequestN apiServices = new ApiRequestN();

        public HistoricDetailPage(Historic historic)
        {
            Title = historic.Name;
            BackgroundColor = Color.White;

            customMap = new CustomMap
            {
                IsShowingUser = true,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            if (historic.Poi.Count > 0)
            {
                foreach (var poi in historic.Poi)
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

            foreach (var pos in historic.TrailPath)
            {
                customMap.RouteCoordinates.Add(new Position(pos.Latitude, pos.Longitude));
            }
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(historic.MainLatitude, historic.MainLongitude), Distance.FromKilometers(1)));

            btnStartRun = new Button()
            {
                Text = "Iniciar Corrida",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#4CAF50")
            };
            btnStartRun.Clicked += async delegate 
            {
                var x = await DisplayAlert("Hey Hey!", "Você esta prestes a ser direcionado para o local de inicio da corrida selecionada\n\nDeseja continuar?", "Yup!", "Nop!");
                if (x)
                {
                    apiServices.SetLastTrail(historic);

                    var place = historic.TrailPath[0];
                    await fileServices.SaveTextAsync("activeTrail.json", Newtonsoft.Json.JsonConvert.SerializeObject(historic));
                    intentServices.PlaceNavigation(place.Latitude.ToString(), place.Longitude.ToString());

                    await Navigation.PopToRootAsync();
                }
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
                sb.Append("Ultima vez visitada\n\t");
                sb.Append(historic.Date);
                sb.Append("\n");
            }
            if (!String.IsNullOrEmpty(historic.Distance))
            {
                sb.Append("Distancia Total\n\t");
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
            if (historic.TrailPath.Count > 0)
            {
                mapLatitude = mapLatitude / historic.TrailPath.Count;
                mapLongitude = mapLongitude / historic.TrailPath.Count;

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
                }
            }

            var lblInfoTrail = new Label()
            {
                Text = historic.Description
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
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    },
                    new StackLayout()
                    {
                        BackgroundColor = Color.White,
                        Padding = new Thickness(5,5,5,5),
                        Children = { lblInfoTrail }
                    },
                    btnStartRun
                }
            };
        }
    }
}