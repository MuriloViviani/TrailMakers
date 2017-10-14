using Xamarin.Forms;

namespace TrailMakers.UI
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            var btn = new Button()
            {
                Text = "map",
            };
            btn.Clicked += delegate 
            {
                Navigation.PushAsync(new MapPage());
            };

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "TrailMakers" },
                    btn
                }
            };
        }
    }
}