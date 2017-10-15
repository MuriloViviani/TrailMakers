using System;

namespace TrailMakers.Entity
{
    public class News
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IntroText { get; set; }
        public string NewsText { get; set; }
        public DateTime Timestamp { get; set; }
        public string ImgWebPath { get; set; }
    }
}
