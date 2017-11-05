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
                                new Image
                                {
                                    Source = ImageSource.FromUri(new System.Uri(news.ImageLink)),
                                    HorizontalOptions = LayoutOptions.FillAndExpand,
                                    VerticalOptions = LayoutOptions.Center,
                                },
                                new Label {
                                    Text = news.Heading,
                                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                                    HorizontalOptions = LayoutOptions.StartAndExpand,
                                    VerticalOptions = LayoutOptions.Center
                                },
                                new Label {
                                    Text = news.Dtstamp,
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