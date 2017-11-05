﻿using System.Collections.Generic;
using TrailMakers.Entity;
using TrailMakers.UI.HistoricFeed;
using TrailMakers.UI.UserPage;
using Xamarin.Forms;

namespace TrailMakers.UI
{
    public class MainPage : ContentPage
    {
        public MainPage()
        {
            //BackgroundColor = Color.White;
            BackgroundImage = "mainBcg.png";

            var optionsList = new List<MainPageItensPattern>();
            // opções sendo criadas e adicionadas a lista

            //------------------------------------------------------------------
            // Meu perfil
            var menuInfo = new MenuOption()
            {
                Name = "Meu Perfil",
                BkgColor = "#03A9F4",
                ImagePath = "http://simpleicon.com/wp-content/uploads/user1.png"
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
                BkgColor = "#8BC34A",
                ImagePath = "http://simpleicon.com/wp-content/uploads/user1.png"
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
                BkgColor = "#607D8B",
                ImagePath = "http://simpleicon.com/wp-content/uploads/user1.png"
            };
            itemAux = new MainPageItensPattern(menuInfo);
            ClickListenerAux = new TapGestureRecognizer();
            ClickListenerAux.Tapped += delegate
            {
                Navigation.PushAsync(new HistoricPage());
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

            var sv = new ScrollView() { Content = mainLayout };
            Content = sv;
        }
    }
}