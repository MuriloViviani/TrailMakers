using TrailMakers.Business;
using TrailMakers.DataAndHelper;
using Xamarin.Forms;

namespace TrailMakers.UI.Newsfeed
{
    public class NewsPage : ContentPage
    {
        public NewsPage()
        {
            // Set the load page
            Content = HelperItens.Load();

            ApiRequestN apiServices = new ApiRequestN();
            
            // Make the request to the API
            var newsList = apiServices.GetNewsAsync();
            
            // Create the News on its pattern and the link to the detail page
            var stack = new StackLayout() { Padding = new Thickness(5, 5, 5, 5) };
            foreach (var item in newsList)
            {
                var pattern = new NewsPattern(item);

                // Add the tapp recognizer to the item
                var tapRecognizer = new TapGestureRecognizer();
                tapRecognizer.Tapped += delegate { Navigation.PushModalAsync(new NewsDetailPage(item)); };
                pattern.GestureRecognizers.Add(tapRecognizer);
                
                // Adds the item to the stack
                stack.Children.Add(pattern);
            }

            var sv = new ScrollView();
            sv.Content = stack;
            Content = sv;
        }
    }
}