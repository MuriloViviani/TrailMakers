using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrailMakers.Entity
{
    public class News
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LilText { get; set; }
        public string BigText { get; set; }
        public DateTime Timestamp { get; set; }
        public string ImgWebPath { get; set; }
    }
}
