using TrailMakers.Entity;
using Xamarin.Forms;

namespace TrailMakers.UI.Newsfeed
{
    // TODO: Create the News Visualization
    public class NewsDetailPage : ContentPage
    {
        public NewsDetailPage(News news)
        {
            var frameShare = new Frame()
            {
                Content = new Label()
                {
                    Text = "Compartilhar",
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.Center
                },
                BackgroundColor = Color.AliceBlue
            };
            var shareTapRecognizer = new TapGestureRecognizer();
            shareTapRecognizer.Tapped += delegate 
            {
                // TODO: Implement the news message method (see in the Jundiaí's portal app)
                DisplayAlert("Mensagem", "a ser implementado", "Ok");
            };
            frameShare.GestureRecognizers.Add(shareTapRecognizer);

            Content = new StackLayout()
            {
                Padding = new Thickness(0, 0, 0, 0),
                Spacing = 0,
                Children =
                {
                    new StackLayout ()
                    {
                        // TODO: Change to a fraction of the Screen Height
                        HeightRequest = 50,
                        BackgroundColor = Color.Black,
                        Orientation = StackOrientation.Horizontal,
                        Children = { /* TODO: Put some more Options, return buttom for example */ }
                    },
                    new StackLayout()
                    {
                        Padding = new Thickness(5,5,5,5),
                        Spacing = 4,
                        Children =
                        {
                            new Label ()
                            {
                                Text = news.Name,
                                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                                TextColor = Color.Black,
                                HorizontalOptions = LayoutOptions.StartAndExpand,
                            },
                            new Label ()
                            {
                                Text = news.IntroText,
                                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                                TextColor = Color.Black,
                                HorizontalTextAlignment = TextAlignment.Center,
                                HorizontalOptions = LayoutOptions.CenterAndExpand
                            },
                            new Label ()
                            {
                                Text = news.NewsText,
                                TextColor = Color.Gray
                            },
                            frameShare
                        }
                    }
                }
            };
        }
    }
}
