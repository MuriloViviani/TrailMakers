using System.Collections.Generic;

namespace TrailMakers.Entity
{
    public class Historic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string TimeSpent { get; set; }
        public string Distance { get; set; }
        public List<Location> TrailPath { get; set; }
        public List<POI> Poi { get; set; }
        public string Description { get; set; }
        public double MainLatitude { get; set; }
        public double MainLongitude { get; set; }
    }
}
