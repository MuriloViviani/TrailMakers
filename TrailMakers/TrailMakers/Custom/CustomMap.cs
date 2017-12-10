using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace TrailMakers.Custom
{
    public class CustomMap : Map
    {
        /// <summary>
        /// Route Coordinates, coordinates for the trail
        /// </summary>
        public List<Position> RouteCoordinates { get; set; }
        /// <summary>
        /// Coordinates for the areas to be shownd in the Map
        /// </summary>
        public List<Position> AreaCoordinates { get; set; }
        /// <summary>
        /// Pins that are going to be shownd, Points of Interest to be more specific
        /// </summary>
        public List<CustomPin> PinsCoordinates { get; set; }

        public CustomMap()
        {
            RouteCoordinates = new List<Position>();
            AreaCoordinates = new List<Position>();
            PinsCoordinates = new List<CustomPin>();
        }
    }
}
