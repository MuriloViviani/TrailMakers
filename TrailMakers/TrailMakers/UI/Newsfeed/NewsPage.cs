using TrailMakers.Business;
using TrailMakers.Business.Interface;
using TrailMakers.DataAndHelper;
using Xamarin.Forms;

namespace TrailMakers.UI.Newsfeed
{
    public class NewsPage : ContentPage
    {
        IIntent intentService = DependencyService.Get<IIntent>();
        ApiRequestN apiServices = new ApiRequestN();

        public NewsPage()
        {
            BackgroundColor = Color.White;
            // Set the load page
            Content = HelperItens.Load();

            GetNews();
        }

        public async void GetNews()
        {
            // Make the request to the API
            var newsList = await apiServices.GetNewsAsync();

            // Create the News on its pattern and the link to the detail page
            var stack = new StackLayout() { Padding = new Thickness(5, 5, 5, 5) };
            foreach (var item in newsList)
            {
                var pattern = new NewsPattern(item);

                // Add the tapp recognizer to the item
                var tapRecognizer = new TapGestureRecognizer();
                
                tapRecognizer.Tapped += delegate { intentService.Navigator(item.Link); };
                pattern.GestureRecognizers.Add(tapRecognizer);

                // Adds the item to the stack
                stack.Children.Add(pattern);
            }

            var sv = new ScrollView() { Content = stack };
            Content = sv;
        }
    }
}