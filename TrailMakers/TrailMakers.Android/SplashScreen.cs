﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace TrailMakers.Droid
{
    [Activity(Theme = "@style/Theme.Splash",
             MainLauncher = true,
             NoHistory = true)]

    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            this.StartActivity(typeof(MainActivity));
        }
    }
}