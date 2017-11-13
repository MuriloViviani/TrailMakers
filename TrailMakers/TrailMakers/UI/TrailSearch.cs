using TrailMakers.Business;
using TrailMakers.Custom;
using TrailMakers.DataAndHelper;
using TrailMakers.Entity;
using Xamarin.Forms;

namespace TrailMakers.UI
{
    public class TrailSearch : ContentPage
    {
        ApiRequestN apiRequest = new ApiRequestN();

        SearchBar sb;
        ListView lvSearch;

        public TrailSearch()
        {
            Title = "Procurar trilhas";
            BackgroundColor = Color.White;

            Content = HelperItens.Load();

            lvSearch = new ListView
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    var dtLvOpcoes = new CustomCellTrail();
                    dtLvOpcoes.SetBinding(CustomCellTrail.NameProperty, "TrailName");
                    dtLvOpcoes.SetBinding(CustomCellTrail.DistanceProperty, "Distance");
                    dtLvOpcoes.SetBinding(CustomCellTrail.TimeProperty, "Time");

                    return dtLvOpcoes;
                }),
                SeparatorColor = Color.White,
                BackgroundColor = Color.White
            };

            lvSearch.ItemSelected += (sender, e) =>
            {
                var selectedIten = (Trail)e.SelectedItem;
                if (selectedIten == null)
                    return;

                //Navigation.PushAsync(new HistoricDetailPage(selectedHistory));

                // Cleans the selection
                ((ListView)sender).SelectedItem = null;
            };

            sb = new SearchBar()
            {
                Placeholder = "Digite sua pesquisa aqui",
                SearchCommand = new Command(() =>
                {
                    lvSearch.BeginRefresh();
                    lvSearch.ItemsSource = apiRequest.SearchTrailsAsync(sb.Text, sb.Text);

                    lvSearch.EndRefresh();
                })
            };

            Content = new ScrollView()
            {
                Content = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    Children = {
                        sb,
                        lvSearch
                    }
                }
            };
        }
    }
}