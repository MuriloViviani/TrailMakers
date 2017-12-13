using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailMakers.Entity
{
    public class RaceInfo
    {
        public DateTime StartTime { get; set; }
        public DateTime Time { get; set; }
        public float Distance { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Location> TrailPath { get; set; }
        public List<POI> Poi { get; set; }
        public double MainLatitude { get; set; }
        public double MainLongitude { get; set; }
    }
}
