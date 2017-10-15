using TrailMakers.Business;
using Xamarin.Forms;

namespace TrailMakers.UI.Newsfeed
{
    public class NewsPage : ContentPage
    {
        public NewsPage()
        {
            ApiRequestN apiServices = new ApiRequestN();

            var newsList = apiServices.GetNewsAsync();

            var stack = new StackLayout()
            {
                Padding = new Thickness(5,5,5,5)
            };

            foreach (var item in newsList)
            {
                stack.Children.Add(new NewsPattern(item));
            }

            var sv = new ScrollView();
            sv.Content = stack;
            Content = sv;
        }
    }
}