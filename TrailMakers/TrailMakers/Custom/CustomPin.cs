using TrailMakers.Entity;
using Xamarin.Forms.Maps;

namespace TrailMakers.Custom
{
    public delegate void ClickedEventHandler(CustomPin sender);

    public class CustomPin : Pin
    {
        public event ClickedEventHandler InfoClicked;

        public string Name { get; set; }
        public string IconUrl { get; set; }
        public POI Poi { get; set; }

        public void InfoWindowClicked(CustomPin pin)
        {
            InfoClicked(pin);
        }
    }
}
