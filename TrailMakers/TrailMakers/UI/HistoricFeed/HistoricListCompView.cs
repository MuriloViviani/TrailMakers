using TrailMakers.Custom;
using TrailMakers.Entity;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace TrailMakers.UI.HistoricFeed
{
    public class HistoricListCompView : ContentView
    {
        public HistoricListCompView(Historic histTrail)
        {
            var customMap = new CustomMap
            {
                IsShowingUser = true,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HasZoomEnabled = false,
                HasScrollEnabled = false,
            };

            foreach (var poi in histTrail.Poi)
            {
                customMap.PinsCoordinates.Add(new CustomPin()
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
                });
            }

            foreach (var pos in histTrail.TrailPath)
            {
                customMap.RouteCoordinates.Add(new Position(pos.Latitude, pos.Longitude));
            }

            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(histTrail.MainLatitude, histTrail.MainLongitude), Distance.FromKilometers(1)));

            Content = new StackLayout
            {
                Children = {
                    new Frame ()
                    {
                        Content = new StackLayout {
                            Children =
                            {
                                customMap,
                                new Label {
                                    Text = histTrail.Name,
                                    FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
                                    HorizontalOptions = LayoutOptions.StartAndExpand,
                                    VerticalOptions = LayoutOptions.Center
                                },
                                new Label {
                                    Text = histTrail.Description,
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