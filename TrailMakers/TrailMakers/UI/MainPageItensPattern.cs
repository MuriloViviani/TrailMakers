using System;
using TrailMakers.Entity;
using Xamarin.Forms;

namespace TrailMakers.UI
{
    public class MainPageItensPattern : ContentView
    {
        public MainPageItensPattern(MenuOption item)
        {
            var Imageframe = new Frame()
            {
                BackgroundColor = Color.FromHex(item.BkgColor),
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                HeightRequest = 50,
                WidthRequest = 50,
                Content = new Image()
                {
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Source = ImageSource.FromUri(new Uri(item.ImagePath))
                }
            };

            var ItemName = new Label()
            {
                Text = item.Name,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
            };

            Content = new StackLayout()
            {
                HeightRequest = (App.ScreenSize.Height / 4),
                WidthRequest = App.ScreenSize.Width / 2,
                Children =
                {
                    new StackLayout(){
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Children = {
                            Imageframe,
                            ItemName
                        }
                    }
                }
            };
        }
    }
}
