using TrailMakers.Entity;
using Xamarin.Forms;

namespace TrailMakers.UI.HistoricFeed
{
    public class HistoricDetailPage : ContentPage
    {
        public HistoricDetailPage(Historic historic)
        {
            Title = historic.Name;

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Welcome to Xamarin Forms!" }
                }
            };
        }
    }
}