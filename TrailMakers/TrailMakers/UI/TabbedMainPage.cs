using TrailMakers.UI.Newsfeed;
using Xamarin.Forms;

namespace TrailMakers.UI
{
    public class TabbedMainPage : TabbedPage
    {
        public TabbedMainPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var menuPage = new MainPage();
            //navigationPage.Icon = "";
            menuPage.Title = "Menu";

            var newsPage = new NewsPage();
            newsPage.Title = "News";

            Children.Add(menuPage);
            Children.Add(newsPage);
        }

    }
}
