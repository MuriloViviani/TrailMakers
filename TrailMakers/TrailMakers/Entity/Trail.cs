using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailMakers.Entity
{
    public class Trail
    {
        public int ID { get; set; }
        public string TrailName { get; set; }
        public string TrailDescription { get; set; }
        public float MainLatitude { get; set; }
        public float MainLongitude { get; set; }
        public User User { get; set; }
        public int Rating { get; set; }
        public string Time { get; set; }
        public string Distance { get; set; }
    }
}
