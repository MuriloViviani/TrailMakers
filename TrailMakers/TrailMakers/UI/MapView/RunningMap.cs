using System;
using TrailMakers.Business.Interface;
using TrailMakers.Custom;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TrailMakers.UI.MapView
{
    public class RunningMap : ContentPage
    {
        CustomMap customMap;
        Button btnBegin;
        Image pointImage;
        Label lblDistace;
        Label lblHour, lblMinute, lblSecond;
        DateTime time;

        private ILocate locator = DependencyService.Get<ILocate>();

        public RunningMap()
        {
            Title = "Nova Corrida";
            BackgroundColor = Color.White;

            customMap = new CustomMap
            {
                IsShowingUser = true,
                HeightRequest = App.ScreenSize.Height / 5,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            var place = locator.GetLocation();
            if (place == null)
                customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(0, 0), Distance.FromKilometers(1)));
            else
                customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(place.Latitude, place.Longitude), Distance.FromKilometers(1)));


            lblHour = new Label()
            {
                Text = "00",
                FontSize = 50
            };
            lblMinute = new Label()
            {
                Text = "00",
                FontSize = 50
            };
            lblSecond = new Label()
            {
                Text = "00",
                FontSize = 30
            };

            lblDistace = new Label()
            {
                Text = "0.0 Km",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            btnBegin = new Button()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "Iniciar",
                BackgroundColor = Color.FromHex("#4CAF50")
            };

            pointImage = new Image()
            {
                Source = ImageSource.FromUri(new Uri(DataAndHelper.Data.DANGER_MAP_ICON)),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };

            Content = new StackLayout()
            {
                Children =
                {
                    customMap,
                    new StackLayout()
                    {
                        Padding = new Thickness(5,5,5,5),
                        Children = {
                            new Frame()
                            {
                                VerticalOptions = LayoutOptions.Center,
                                Content = new StackLayout()
                                {
                                    Children = {
                                        new StackLayout(){
                                            Orientation = StackOrientation.Horizontal,
                                            VerticalOptions = LayoutOptions.Center,
                                            HorizontalOptions = LayoutOptions.Center,
                                            Children =
                                            {
                                                lblHour,
                                                new Label()
                                                {
                                                    Text = ":",
                                                    FontSize = 25,
                                                    VerticalOptions = LayoutOptions.Center
                                                },
                                                lblMinute,
                                                new Label()
                                                {
                                                    Text = ":",
                                                    FontSize = 25,
                                                    VerticalOptions = LayoutOptions.Center
                                                },
                                                lblSecond
                                            }
                                        },
                                        lblDistace
                                    }
                                }
                            },
                            new StackLayout()
                            {
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                VerticalOptions = LayoutOptions.FillAndExpand,
                                Children =
                                {
                                    new StackLayout()
                                    {
                                        HorizontalOptions = LayoutOptions.FillAndExpand,
                                        VerticalOptions = LayoutOptions.FillAndExpand,
                                        Children =
                                        {
                                            btnBegin
                                        }
                                    },
                                    pointImage
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}