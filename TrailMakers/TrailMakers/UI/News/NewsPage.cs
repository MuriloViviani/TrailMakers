using Xamarin.Forms;

namespace TrailMakers.UI.News
{
    public class NewsPage : ContentPage
    {
        public NewsPage()
        {
            var sv = new ScrollView();
            sv.Content = new StackLayout()
            {
                Children = {
                    new NewsPattern()
                }
            };
            Content = sv;
        }
    }
}