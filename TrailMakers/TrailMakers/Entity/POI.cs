using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TrailMakers.DataAndHelper.Data;

namespace TrailMakers.Entity
{
    public class POI
    {
        public int PoiID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public PinType Type { get; set; }
        public string Description { get; set; }
        public string IconUlr { get; set; }
    }
}
