using TrailMakers.UI.HistoricFeed;
using Xamarin.Forms;

namespace TrailMakers.UI
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var btnMap = new Button()
            {
                Text = "map",
            };
            btnMap.Clicked += delegate { Navigation.PushAsync(new MapPage()); };
            var btnHistoric = new Button()
            {
                Text = "Historic",
            };
            btnHistoric.Clicked += delegate { Navigation.PushAsync(new HistoricPage()); };

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "TrailMakers" },
                    btnMap,
                    btnHistoric
                }
            };
        }
    }
}