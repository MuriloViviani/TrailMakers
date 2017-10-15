using TrailMakers.Entity;

using Xamarin.Forms;

namespace TrailMakers.UI.Newsfeed
{
    public class NewsPattern : ContentView
    {
        public NewsPattern(News news)
        {
            Content = new StackLayout
            {
                Children = {
                    new Frame ()
                    {
                        Content = new StackLayout {
                            Children =
                            {
                                new Label {
                                    Text = news.Name,
                                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                                    HorizontalOptions = LayoutOptions.StartAndExpand,
                                    VerticalOptions = LayoutOptions.Center
                                },
                                new Label {
                                    Text = news.IntroText,
                                    FontSize = Device.GetNamedSize(NamedSize.Default, typeof(Label)),
                                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                                    VerticalOptions = LayoutOptions.Center
                                },
                                new Label {
                                    Text = "data - " + news.Timestamp.ToString("dd/MM/yyyy"),
                                    FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                                    HorizontalTextAlignment = TextAlignment.End,
                                    HorizontalOptions = LayoutOptions.EndAndExpand
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}