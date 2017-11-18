using System.Collections.Generic;
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

        List<Trail> trails = new List<Trail>();

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
                    dtLvOpcoes.SetBinding(CustomCellTrail.DistanceProperty, "DistShownd");
                    dtLvOpcoes.SetBinding(CustomCellTrail.TimeProperty, "TimeShownd");

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

                // Cleans the selection
                ((ListView)sender).SelectedItem = null;
            };

            sb = new SearchBar()
            {
                Placeholder = "Digite sua pesquisa aqui",
                SearchCommand = new Command(() =>
                {
                    lvSearch.BeginRefresh();

                    trails.Sort((x, y) => x.TrailName.CompareTo(y.TrailName));
                    lvSearch.ItemsSource = trails;

                    lvSearch.EndRefresh();
                })
            };

            LoadScreen();
        }

        private async void LoadScreen()
        {
            trails = await apiRequest.SearchTrailsAsync("","");

            lvSearch.ItemsSource = trails;

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