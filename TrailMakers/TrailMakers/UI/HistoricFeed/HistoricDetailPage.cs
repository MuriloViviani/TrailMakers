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
                TextColor = Color.FromHex("#EE635D"),
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Start,
                HorizontalTextAlignment = TextAlignment.Start
            };

            foreach (var item in historic.TrailPath)
            {
                customMap.RouteCoordinates.Add(new Position(item.Latitude, item.Longitude));
            }

            Content = new StackLayout
            {
                Children = {
                    customMap,
                    lblName
                }
            };
        }
    }
}