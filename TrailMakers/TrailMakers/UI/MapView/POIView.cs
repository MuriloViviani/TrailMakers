using System;
using TrailMakers.Custom;
using Xamarin.Forms;

namespace TrailMakers.UI.MapView
{
    public class POIView : ContentPage
    {
        public POIView(CustomPin pin)
        {
            BackgroundColor = Color.White;

            var fixedPin = DataAndHelper.HelperItens.FixPOI(pin);

            Button btnBack = new Button()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.FromHex("#4CAF50"),
                Text = "Ok! Quero voltar!"
            };
            btnBack.Clicked += delegate
            {
                Navigation.PopModalAsync();
            };

            Content = new ScrollView()
            {
                Content = new StackLayout()
                {
                    Children =
                    {
                        new Frame ()
                        {
                            VerticalOptions = LayoutOptions.CenterAndExpand,
                            HorizontalOptions = LayoutOptions.Center,
                            Content = new StackLayout ()
                            {
                                VerticalOptions = LayoutOptions.Center,
                                HorizontalOptions = LayoutOptions.CenterAndExpand,
                                Children =
                                {
                                    new Image ()
                                    {
                                        Source = ImageSource.FromUri(new Uri(fixedPin.IconUrl))
                                    },
                                    new Label()
                                    {
                                        Text = fixedPin.Name,
                                        VerticalOptions = LayoutOptions.Center,
                                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                                    },
                                    new Frame()
                                    {
                                        Content = new StackLayout()
                                        {
                                            Children =
                                            {
                                                new Label ()
                                                {
                                                    Text = "Descrição",
                                                    HorizontalOptions = LayoutOptions.StartAndExpand,
                                                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
                                                },
                                                new Label ()
                                                {
                                                    Text = fixedPin.Poi.Description,
                                                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                                                    VerticalOptions = LayoutOptions.Start
                                                }
                                            }
                                        }
                                    },
                                    btnBack
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}