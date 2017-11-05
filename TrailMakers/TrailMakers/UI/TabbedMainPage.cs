using TrailMakers.UI.Newsfeed;
using Xamarin.Forms;

namespace TrailMakers.UI
{
    public class TabbedMainPage : TabbedPage
    {
        public TabbedMainPage()
        {
            BackgroundColor = Color.White;

            NavigationPage.SetHasNavigationBar(this, false);

            var menuPage = new MainPage() { Title = "Menu" };
            var newsPage = new NewsPage() { Title = "News" };

            Children.Add(menuPage);
            Children.Add(newsPage);
        }

    }
}
