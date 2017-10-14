using TrailMakers.Interface;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TrailMakers.UI
{
    public class MapPage : ContentPage
    {
        Map map;
        Button btnShowLocation;
        private ILocate locator = DependencyService.Get<ILocate>();

        public MapPage()
        {
            map = new Map
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            var place = locator.GetLocation();
            if(place == null)
                map.MoveToRegion(MapSpan.FromCenterAndRadius (new Position(0, 0), Distance.FromKilometers(1)));
            else
                map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(place.Latitude, place.Longitude), Distance.FromKilometers(1)));

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
            stack.Children.Add(map);
            stack.Children.Add(btnShowLocation);

            Content = stack;
        }
    }
}