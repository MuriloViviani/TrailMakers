using System;
using System.Text;
using TrailMakers.Business.Interface;
using TrailMakers.Custom;
using TrailMakers.Entity;
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

        public HistoricDetailPage(Historic historic)
        {
            Title = historic.Name;
            BackgroundColor = Color.White;

            customMap = new CustomMap
            {
                IsShowingUser = true,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HasZoomEnabled = false,
                HasScrollEnabled = false,
            };

            if (historic.Poi.Count > 0)
            {
                foreach (var poi in historic.Poi)
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

            foreach (var pos in historic.TrailPath)
            {
                customMap.RouteCoordinates.Add(new Position(pos.Latitude, pos.Longitude));
            }
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(historic.MainLatitude, historic.MainLongitude), Distance.FromKilometers(1)));

            btnStartRun = new Button()
            {
                Text = "Iniciar Corrida"
            };
            btnStartRun.Clicked += async delegate 
            {
                var x = await DisplayAlert("Hey Hey!", "Você esta prestes a ser direcionado para o local de inicio da corrida selecionada\n\nDeseja continuar?", "Yup!", "Nop!");
                if (x)
                {
                    var place = historic.TrailPath[0];
                    await fileServices.SaveTextAsync("activeTrail.json", Newtonsoft.Json.JsonConvert.SerializeObject(historic));
                    intentServices.PlaceNavigation(place.Latitude.ToString(), place.Longitude.ToString());
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
                    },
                    btnStartRun
                }
            };
        }
    }
}