using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailMakers.Entity
{
    // TODO: Update this class
    public class SuporteTrails
    {
        public List<Trail> rows { get; set; }
    }

    public class Trail
    {
        [JsonProperty(PropertyName = "trailID")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "trailname")]
        public string TrailName { get; set; }

        public string TrailDescription { get; set; }
        public float MainLatitude { get; set; }
        public float MainLongitude { get; set; }
        public User User { get; set; }

        [JsonProperty(PropertyName = "trailrat")]
        public int Rating { get; set; }

        [JsonProperty(PropertyName = "trailtime")]
        public DateTime Time { get; set; }
        public string TimeShownd { get; set; }

        [JsonProperty(PropertyName = "traildist")]
        public float Distance { get; set; }
        public string DistShownd { get; set; }

        public List<POI> POIList { get; set; }
    }
}
