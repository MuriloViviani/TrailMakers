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
using TrailMakers.Custom;
using TrailMakers.Droid.CustomRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using TrailMakers.Droid.CustomItens;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(CustomCellTrail), typeof(CustomCellTrailRenderer))]
namespace TrailMakers.Droid.CustomRenderers
{
    public class CustomCellTrailRenderer : ViewCellRenderer
    {
        CustomAndroidCellTrail cell;

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context)
        {
            var nativeCell = (CustomCellTrail)item;
            cell = convertView as CustomAndroidCellTrail;
            if (cell == null)
                cell = new CustomAndroidCellTrail(context, nativeCell);
            else
                cell.NativeCell.PropertyChanged -= OnNativeCellPropertyChange;

            nativeCell.PropertyChanged += OnNativeCellPropertyChange;

            cell.UpdateCell(nativeCell);
            return cell;
        }

        private void OnNativeCellPropertyChange(object sender, PropertyChangedEventArgs e)
        {
            var nativeCell = (CustomCellTrail)sender;
            if (e.PropertyName == CustomCellTrail.NameProperty.PropertyName)
            {
                cell.NameTextView.Text = nativeCell.Name;
            }
            else if (e.PropertyName == CustomCellTrail.DistanceProperty.PropertyName)
            {
                cell.DistanceTextView.Text = nativeCell.Distance;
            }
            else if (e.PropertyName == CustomCellTrail.TimeProperty.PropertyName)
            {
                cell.TimeTextView.Text = nativeCell.Time;
            }
        }
    }
}