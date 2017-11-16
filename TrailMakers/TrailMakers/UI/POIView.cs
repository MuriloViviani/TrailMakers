using TrailMakers.Custom;
using Xamarin.Forms;

namespace TrailMakers.UI
{
    public class POIView : ContentPage
    {
        public POIView(CustomPin pin)
        {
            Content = new ScrollView()
            {
                Content = new StackLayout()
                {
                    Children =
                    {
                        new Frame()
                        {
                            BackgroundColor = DataAndHelper.HelperItens.GetPOIColor(pin.Poi.Type),
                            Content = new StackLayout()
                            {
                                Children =
                                {
                                    new Label()
                                    {
                                        Text = pin.Poi.Type.ToString(),
                                        VerticalOptions = LayoutOptions.Center,
                                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
                                    }
                                }
                            }
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
                                        Text = pin.Poi.Description,
                                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                                        VerticalOptions = LayoutOptions.Start
                                    }
                                }
                            }
                        }
                    }
                }
            };
        }
    }
}