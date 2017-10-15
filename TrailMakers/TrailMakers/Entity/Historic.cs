using System.Collections.Generic;

namespace TrailMakers.Entity
{
    public class Historic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string TimeSpent { get; set; }
        public double Distance { get; set; }
        public List<Location> TrailPath { get; set; }
    }
}
