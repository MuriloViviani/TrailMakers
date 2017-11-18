using TrailMakers.Business;
using TrailMakers.Custom;
using TrailMakers.Entity;
using Xamarin.Forms;

namespace TrailMakers.UI.HistoricFeed
{
    public class HistoricPage : ContentPage
    {
        private ListView lvHistoric;
        private ApiRequestN apiServices = new ApiRequestN(); 

        public HistoricPage()
        {
            Title = "Historico de trilhas";
            BackgroundColor = Color.White;

            Content = DataAndHelper.HelperItens.Load();

            lvHistoric = new ListView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    var dtLvOpcoes = new CustomCellTrail();
                    dtLvOpcoes.SetBinding(CustomCellTrail.NameProperty, "Name");
                    dtLvOpcoes.SetBinding(CustomCellTrail.DistanceProperty, "DistShownd");
                    dtLvOpcoes.SetBinding(CustomCellTrail.TimeProperty, "TimeSpent");

                    return dtLvOpcoes;
                }),
                SeparatorColor = Color.White,
                BackgroundColor = Color.White
            };

            lvHistoric.ItemSelected += (sender, e) =>
            {
                var selectedHistory = (Historic)e.SelectedItem;
                if (selectedHistory == null)
                    return;

                Navigation.PushAsync(new HistoricDetailPage(selectedHistory));

                // Cleans the selection
                ((ListView)sender).SelectedItem = null;
            };
        }

        private async void LoadScreen()
        {
            var historic = await apiServices.GetUserHistoricAsync();
            lvHistoric.ItemsSource = historic;

            Content = new StackLayout
            {
                Children = { lvHistoric }
            };
        }
    }
}