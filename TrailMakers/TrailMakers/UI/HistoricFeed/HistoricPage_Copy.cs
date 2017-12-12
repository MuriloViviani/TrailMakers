using TrailMakers.Business;
using Xamarin.Forms;

namespace TrailMakers.UI.HistoricFeed
{
    public class HistoricPage_Copy : ContentPage
    {
        private ApiRequestN apiServices = new ApiRequestN();

        public HistoricPage_Copy()
        {
            Title = "Historico de trilhas";
            BackgroundColor = Color.White;

            Content = DataAndHelper.HelperItens.Load();

            LoadScreen();
        }

        private async void LoadScreen()
        {
            var trails = await apiServices.GetUserHistoricAsync();

            if (trails != null)
            {
                StackLayout layout = new StackLayout() { Padding = new Thickness(5, 5, 5, 5) };
                foreach (var trail in trails)
                {
                    layout.Children.Add(new HistoricListCompView(trail));
                }

                ScrollView sv = new ScrollView() { Content = layout };
                Content = sv;
            }
            else
            {
                Content = DataAndHelper.HelperItens.NoData(Navigation);
            }
        }
    }
}