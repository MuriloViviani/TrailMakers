using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace TrailMakers.Custom
{
    public class CustomMap : Map
    {
        public List<Position> RouteCoordinates { get; set; }
        public List<Position> AreaCoordinates { get; set; }
        public List<CustomPin> PinsCoordinates { get; set; }

        public CustomMap()
        {
            RouteCoordinates = new List<Position>();
            AreaCoordinates = new List<Position>();
            PinsCoordinates = new List<CustomPin>();
        }
    }
}
