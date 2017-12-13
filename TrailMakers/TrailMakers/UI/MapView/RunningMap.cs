using System;
using TrailMakers.Business;
using TrailMakers.Business.Interface;
using TrailMakers.Custom;
using TrailMakers.Entity;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TrailMakers.UI.MapView
{
    public class RunningMap : ContentPage
    {
        CustomMap customMap;
        Button btnBegin, btnDanger;
        Label lblDistace;
        Label lblHour, lblMinute, lblSecond;
        DateTime time;

        private ILocate locator = DependencyService.Get<ILocate>();
        private IIntent intents = DependencyService.Get<IIntent>();
        private ApiRequestN apiServices = new ApiRequestN();

        public RunningMap()
        {
            Title = "Nova Corrida";
            BackgroundColor = Color.White;

            CreateLayout();
        }

        private async void CreateLayout()
        {
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

            var lastTrail = await apiServices.GetLastTrail();
            if (lastTrail != null)
            {
                if (!String.IsNullOrEmpty(lastTrail.Name))
                {
                    foreach (var poi in lastTrail.Poi)
                    {
                        var pin = new CustomPin()
                        {
                            Position = new Position(poi.Latitude, poi.Longitude),
                            Label = poi.Type.ToString(),
                            Id = poi.Type,
                            IconUrl = poi.IconUlr,
                            Poi = new POI()
                            {
                                Description = poi.Description,
                                Type = poi.Type
                            }
                        };

                        pin.InfoClicked += (sender) =>
                        {
                            var pinSelected = sender;
                            Navigation.PushModalAsync(new POIView(pinSelected));
                        };

                        customMap.PinsCoordinates.Add(pin);
                    }

                    foreach (var pos in lastTrail.TrailPath)
                    {
                        customMap.RouteCoordinates.Add(new Position(pos.Latitude, pos.Longitude));
                    }
                }
            }

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

            var info = new RaceInfo()
            {
                StartTime = DateTime.Now,
                Poi = new System.Collections.Generic.List<POI>(),
                TrailPath = new System.Collections.Generic.List<Location>(),
                Description = "Esta é minha mais nova trilha! =D",
                Name = "Nova trilha"
            };
            var state = false;
            btnBegin = new Button()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Text = "Iniciar",
                BackgroundColor = Color.FromHex("#4CAF50"),
                TextColor = Color.White
            };
            btnBegin.Clicked += async delegate
            {
                state = !state;
                if (state)
                {
                    btnBegin.Text = "Parar";
                    btnBegin.BackgroundColor = Color.FromHex("#F44336");
                    Device.StartTimer(TimeSpan.FromMilliseconds(1000), () =>
                    {
                        info.Time = info.Time.AddSeconds(1);

                        lblSecond.Text = info.Time.Second.ToString();
                        lblMinute.Text = info.Time.Minute.ToString();
                        lblHour.Text = info.Time.Hour.ToString();

                        return state;
                    });
                }
                else
                {
                    await Navigation.PushAsync(new RunDetailPage(info));
                    state = !state;
                }
            };

            btnDanger = new Button()
            {
                Text = "SOCORRO!",
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("#F44336")
            };
            btnDanger.Clicked += async delegate
            {
                await DisplayAlert("Aguente Firme!", "Não se preocupe!\nOs trilheiros mais próximos a você serão alertados!", "OKAY!");
                intents.Call("192");
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
                                    btnDanger
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}