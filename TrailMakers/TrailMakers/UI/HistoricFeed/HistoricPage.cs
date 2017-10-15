using TrailMakers.Business;
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

            lvHistoric = new ListView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    var dtLvOpcoes = new TextCell();
                    dtLvOpcoes.SetBinding(TextCell.TextProperty, "Name");
                    dtLvOpcoes.SetBinding(TextCell.DetailProperty, "Date");

                    return dtLvOpcoes;
                }),
                SeparatorColor = Color.White,
                BackgroundColor = Color.White
            };

            lvHistoric.ItemSelected += (sender, e) =>
            {
                // TODO: Set to the nedded Object
                var selectedHistory = (Historic)e.SelectedItem;
                if (selectedHistory == null)
                    return;

                Navigation.PushAsync(new HistoricDetailPage(selectedHistory));

                // Cleans the selection
                ((ListView)sender).SelectedItem = null;
            };

            var historic = apiServices.GetUserHistoricAsync();
            lvHistoric.ItemsSource = historic;

            Content = new StackLayout
            {
                Children = { lvHistoric }
            };
        }
    }
}