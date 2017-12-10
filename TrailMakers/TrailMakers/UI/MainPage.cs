using System;
using System.Collections.Generic;
using TrailMakers.Entity;
using TrailMakers.UI.HistoricFeed;
using TrailMakers.UI.MapView;
using TrailMakers.UI.UserPage;
using Xamarin.Forms;

namespace TrailMakers.UI
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            //BackgroundColor = Color.White;
            BackgroundImage = "MainBack.png";

            var optionsList = new List<MainPageItensPattern>();
            // opções sendo criadas e adicionadas a lista

            //------------------------------------------------------------------
            // Meu perfil
            var menuInfo = new MenuOption()
            {
                Name = "Meu Perfil",
                BkgColor = "#FFB74D",
                ImagePath = DataAndHelper.Data.MY_PROFILE_ICON
            };
            var itemAux = new MainPageItensPattern(menuInfo);
            var ClickListenerAux = new TapGestureRecognizer();
            ClickListenerAux.Tapped += delegate
            {
                Navigation.PushModalAsync(new UserHomePage());
            };
            itemAux.GestureRecognizers.Add(ClickListenerAux);
            optionsList.Add(itemAux);

            //------------------------------------------------------------------
            // Nova Corrida
            menuInfo = new MenuOption()
            {
                Name = "Nova Corrida",
                BkgColor = "#FFB74D",
                ImagePath = DataAndHelper.Data.NEW_TRAIL_ICON
            };
            itemAux = new MainPageItensPattern(menuInfo);
            ClickListenerAux = new TapGestureRecognizer();
            ClickListenerAux.Tapped += delegate
            {
                Navigation.PushAsync(new MapPage());
            };
            itemAux.GestureRecognizers.Add(ClickListenerAux);
            optionsList.Add(itemAux);

            //------------------------------------------------------------------
            // Historico de Carridas
            menuInfo = new MenuOption()
            {
                Name = "Historico de Corridas",
                BkgColor = "#FFB74D",
                ImagePath = DataAndHelper.Data.ROUTE_HISTORIC_ICON
            };
            itemAux = new MainPageItensPattern(menuInfo);
            ClickListenerAux = new TapGestureRecognizer();
            ClickListenerAux.Tapped += delegate
            {
                Navigation.PushAsync(new HistoricPage_Copy());
            };
            itemAux.GestureRecognizers.Add(ClickListenerAux);
            optionsList.Add(itemAux);

            //------------------------------------------------------------------
            // Historico de Carridas
            menuInfo = new MenuOption()
            {
                Name = "Pesquisar Trilhas",
                BkgColor = "#FFB74D",
                ImagePath = DataAndHelper.Data.TRAIL_SEARCH_ICON
            };
            itemAux = new MainPageItensPattern(menuInfo);
            ClickListenerAux = new TapGestureRecognizer();
            ClickListenerAux.Tapped += delegate
            {
                Navigation.PushAsync(new TrailSearch());
            };
            itemAux.GestureRecognizers.Add(ClickListenerAux);
            optionsList.Add(itemAux);

            var mainLayout = new StackLayout();

            int count = 0;
            var supportLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Start
            };
            foreach (var item in optionsList)
            {
                if (count < 1)
                {
                    supportLayout.Children.Add(item);
                }
                else
                {
                    supportLayout.Children.Add(item);
                    mainLayout.Children.Add(supportLayout);
                    supportLayout = new StackLayout()
                    {
                        Orientation = StackOrientation.Horizontal,
                        VerticalOptions = LayoutOptions.Start
                    };
                    count = -1;
                }
                count++;
            }
            mainLayout.Children.Add(supportLayout);


            //-----------------
            Button btn = new Button()
            {
                Text = "Do IT"
            };
            btn.Clicked += delegate
            {
                Business.ApiRequestN api = new Business.ApiRequestN();

                var hist = new Historic()
                {
                    Id = 0,
                    Name = "teste",
                    Description = "Apenas um teste de trilha, mas que pode ser bem interessante caso de certo!",
                    Date = DateTime.Now.ToString("dd/MM/yyyy"),
                    TrailPath = new List<Location>()
                    {
                        new Location()
                        {
                            Latitude = -23.359192,
                            Longitude = -46.735441
                        },
                        new Location()
                        {
                            Latitude = -23.358897,
                            Longitude = -46.735538
                        },
                        new Location()
                        {
                            Latitude = -23.358266,
                            Longitude = -46.735270
                        },
                        new Location()
                        {
                            Latitude = -23.357416,
                            Longitude = -46.736457
                        },
                        new Location()
                        {
                            Latitude = -23.357495,
                            Longitude = -46.737895
                        },
                        new Location()
                        {
                            Latitude = -23.356126,
                            Longitude = -46.740148
                        },
                        new Location()
                        {
                            Latitude = -23.355377,
                            Longitude = -46.741467
                        },
                        new Location()
                        {
                            Latitude = -23.355692,
                            Longitude = -46.741703
                        },
                        new Location()
                        {
                            Latitude = -23.356973,
                            Longitude = -46.740459
                        },
                        new Location()
                        {
                            Latitude = -23.358086,
                            Longitude = -46.738549
                        },
                        new Location()
                        {
                            Latitude = -23.360361,
                            Longitude = -46.736178
                        },
                        new Location()
                        {
                            Latitude = -23.362719,
                            Longitude = -46.735915
                        },
                        new Location()
                        {
                            Latitude = -23.364876,
                            Longitude = -46.734424
                        },
                        new Location()
                        {
                            Latitude = -23.366629,
                            Longitude = -46.732685
                        }
                    },
                    Poi = new List<POI>()
                    {
                        new POI()
                        {
                            Type = DataAndHelper.Data.PinType.Turism,
                            Latitude = -23.358266,
                            Longitude = -46.735270
                        },
                        new POI()
                        {
                            Type = DataAndHelper.Data.PinType.Begin,
                            Latitude = -23.359192,
                            Longitude = -46.735441
                        },
                        new POI()
                        {
                            Type = DataAndHelper.Data.PinType.End,
                            Latitude = -23.366629,
                            Longitude = -46.732685
                        }
                    }
                };

                api.AddToUserHistoricAsync(hist);

                DisplayAlert("YEY!", "Deu certo!", "YUPI");
            };
            mainLayout.Children.Add(btn);
            //-----------------

            var sv = new ScrollView() { Content = mainLayout };
            Content = sv;
        }
    }
}