using Xamarin.Forms;

namespace TrailMakers.Custom
{
    public class CustomCellTrail : ViewCell
    {
        public static readonly BindableProperty NameProperty = BindableProperty.Create("Name", typeof(string), typeof(CustomCellTrail));
        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        public static readonly BindableProperty DistanceProperty = BindableProperty.Create("Distance", typeof(string), typeof(CustomCellTrail));
        public string Distance
        {
            get { return (string)GetValue(DistanceProperty); }
            set { SetValue(DistanceProperty, value); }
        }

        public static readonly BindableProperty TimeProperty = BindableProperty.Create("Time", typeof(string), typeof(CustomCellTrail));
        public string Time
        {
            get { return (string)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }
    }
}