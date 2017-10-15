using TrailMakers.Custom;
using TrailMakers.Interface;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TrailMakers.UI
{
    public class MapPage : ContentPage
    {
        CustomMap customMap;
        Button btnShowLocation;
        private ILocate locator = DependencyService.Get<ILocate>();

        public MapPage()
        {
            customMap = new CustomMap
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            customMap.RouteCoordinates.Add(new Position(-23.359233, -46.735372));
            customMap.RouteCoordinates.Add(new Position(-23.358934, -46.735474));
            customMap.RouteCoordinates.Add(new Position(-23.358448, -46.735365));
            customMap.RouteCoordinates.Add(new Position(-23.358199, -46.735219));
            customMap.RouteCoordinates.Add(new Position(-23.357896, -46.735614));
            customMap.RouteCoordinates.Add(new Position(-23.357607, -46.736103));

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