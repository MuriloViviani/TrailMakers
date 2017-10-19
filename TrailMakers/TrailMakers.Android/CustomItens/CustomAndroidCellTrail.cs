using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using TrailMakers.Custom;

namespace TrailMakers.Droid.CustomItens
{
    public class CustomAndroidCellTrail : LinearLayout, INativeElementView
    {
        public TextView NameTextView { get; set; }
        public TextView DistanceTextView { get; set; }
        public TextView TimeTextView { get; set; }

        public CustomCellTrail NativeCell { get; private set; }
        public Element Element => NativeCell;


        public CustomAndroidCellTrail(Context context, CustomCellTrail cell) : base(context)
        {
            NativeCell = cell;

            var view = (context as Activity).LayoutInflater.Inflate(Resource.Layout.CustomCellTrail_layout, null);
            NameTextView = view.FindViewById<TextView>(Resource.Id.NameText);
            DistanceTextView = view.FindViewById<TextView>(Resource.Id.DistanceText);
            TimeTextView = view.FindViewById<TextView>(Resource.Id.TimeText);

            AddView(view);
        }

        public void UpdateCell(CustomCellTrail cell)
        {
            NameTextView.Text = cell.Name;
            DistanceTextView.Text = cell.Distance;
            TimeTextView.Text = cell.Time;
        }
    }
}