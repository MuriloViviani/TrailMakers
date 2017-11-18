using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrailMakers.Custom;
using TrailMakers.Entity;
using Xamarin.Forms;

namespace TrailMakers.DataAndHelper
{
    public class HelperItens
    {
        public static CustomPin FixPOI(CustomPin pin)
        {
            var pinFixed = new CustomPin()
            {
                Poi = pin.Poi,
            };

            pinFixed.IconUrl = pin.IconUrl.Replace("_60", "_120");

            if (pinFixed.Poi.Type == Data.PinType.Begin)
                pinFixed.Name = "Inicio da trilha";
            else if (pinFixed.Poi.Type == Data.PinType.Danger)
                pinFixed.Name = "Perigo";
            else if (pinFixed.Poi.Type == Data.PinType.End)
                pinFixed.Name = "Fim da trilha";
            else if (pinFixed.Poi.Type == Data.PinType.Help)
                pinFixed.Name = "Pedido de ajuda";
            else if (pinFixed.Poi.Type == Data.PinType.Rest)
                pinFixed.Name = "Ponto de descanso";
            else if (pinFixed.Poi.Type == Data.PinType.Turism)
                pinFixed.Name = "Um ótimo ponto para uma foto!";
            else
                pinFixed.Name = "Existe uma fonte de água por aqui!";

            return pinFixed;
        }

        /// <summary>
        /// No content indicator page
        /// </summary>
        /// <param name="navigation">Page Navigator</param>
        /// <returns></returns>
        public static StackLayout NoData(INavigation navigation)
        {
            Button btnGoBack = new Button
            {
                Text = "Retornar",
                VerticalOptions = LayoutOptions.Center
            };
            btnGoBack.Clicked += delegate { navigation.PopAsync(); };

            var noDataBody = new StackLayout
            {
                Padding = 20,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    new Label
                    {
                        Text = "Nenhum item foi encontrado!",
                        FontAttributes = FontAttributes.Bold,
                        FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.CenterAndExpand
                    },
                    new Label
                    {
                        Text = "=\\",
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 40,
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center
                    }, btnGoBack
                }
            };

            return noDataBody;
        }

        /// <summary>
        /// Load indicator
        /// </summary>
        /// <returns>StackLayout</returns>
        public static StackLayout Load()
        {
            var loadIndicator = new ActivityIndicator();
            loadIndicator.Color = Color.Gray;
            loadIndicator.IsRunning = true;
            loadIndicator.HeightRequest = 60;
            loadIndicator.WidthRequest = 60;

            var rand = new Random();
            int auxPos = 0;

            // Just a label to indicate that the data is loading
            var lblLoading = new Label
            {
                Text = "Carregando...\n",
                FontAttributes = FontAttributes.Bold,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            auxPos = rand.Next(0, Data.curiosities.Length);
            // Label used to show the curiosities about the spot (cyclism) and the app
            var lblSpentTime = new Label
            {
                Text = "Você sabia?\n" + Data.curiosities[auxPos],
                FontAttributes = FontAttributes.Italic,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            // Gesture recognizer to let the user read the message on his own time
            var tapSpentTime = new TapGestureRecognizer();
            tapSpentTime.Tapped += async (s, e) =>
            {
                await App.Current.MainPage.DisplayAlert("", lblSpentTime.Text, "Fechar");
            };
            tapSpentTime.NumberOfTapsRequired = 1;
            lblSpentTime.GestureRecognizers.Add(tapSpentTime);

            int pos = 0;
            int auxTimer = 0;
            int stage = 0; // 0 = showing, 1 = fadeout n/ change, 2 = fadein
            Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
            {
                if (auxTimer >= 7 && stage == 0)
                {
                    lblSpentTime.FadeTo(0, 1000);
                    auxTimer = 0;
                    stage = 1;
                }
                else if (auxTimer >= 1 && stage == 1)
                {
                    do
                        pos = rand.Next(0, Data.curiosities.Length);
                    while (pos == auxPos);

                    auxPos = pos;
                    lblSpentTime.Text = "Você sabia?\n" + Data.curiosities[pos];

                    lblSpentTime.FadeTo(1, 1000);
                    stage = 2;
                    auxTimer = 0;
                }
                else if (auxTimer >= 1 && stage == 2)
                {
                    stage = 0;
                    auxTimer = 0;
                }

                auxTimer++;

                return true;
            });

            // Just the result =)
            var page = new StackLayout
            {
                BackgroundColor = Color.White,
                Padding = 20,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    loadIndicator,
                    lblLoading,
                    lblSpentTime
                }
            };

            return page;
        }
    }
}
