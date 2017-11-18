using System.Collections.Generic;
using TrailMakers.Business.Interface;
using TrailMakers.Custom;
using TrailMakers.Entity;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TrailMakers.UI.MapView
{
    public class MapPage : ContentPage
    {
        CustomMap customMap;
        Button btnShowLocation;
        private ILocate locator = DependencyService.Get<ILocate>();

        public MapPage()
        {
            Title = "Mapa";
            customMap = new CustomMap
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            // Custom Pin
            var pin = new CustomPin()
            {
                Position = new Position(-23.359233, -46.735372),
                Label = "Teste",
                Address = "Teste",
                Id = DataAndHelper.Data.PinType.Danger,
                IconUrl = DataAndHelper.Data.DANGER_MAP_ICON,
                Poi = new POI()
                {
                    Description = "Aviso de perigo na trilha, esse aviso pode ser de extrema importância para perigos na trilha",
                    Type = DataAndHelper.Data.PinType.Danger
                }
            };
            pin.InfoClicked += (sender) => 
            {
                var pinSelected = sender;
                Navigation.PushModalAsync(new POIView(pinSelected));
            };

            customMap.PinsCoordinates = new List<CustomPin> { pin };
            customMap.Pins.Add(pin);

            var place = locator.GetLocation();
            if(place == null)
                customMap.MoveToRegion(MapSpan.FromCenterAndRadius (new Position(0, 0), Distance.FromKilometers(1)));
            else
                customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(place.Latitude, place.Longitude), Distance.FromKilometers(1)));

            btnShowLocation = new Button()
            {
                Text = "Get My Location"
            };
            btnShowLocation.Pressed += delegate
            {
                place = locator.GetLocation();
                if(place == null)
                    DisplayAlert("Localização", "Localização não disponivel", "Kay");
                else
                    DisplayAlert("Localização", "Latitude = " + place.Latitude + "\nLongitude = " + place.Longitude, "Kay");
            };

            // put the page together
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(customMap);
            stack.Children.Add(btnShowLocation);

            Content = stack;
        }
    }
}