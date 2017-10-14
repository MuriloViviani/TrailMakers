﻿using Android.Content;
using Android.Locations;
using System.Collections.Generic;
using System.Linq;
using TrailMakers.Droid.DependencyServices;
using TrailMakers.Entity;
using TrailMakers.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(ILocate_Android))]
namespace TrailMakers.Droid.DependencyServices
{
    class ILocate_Android : ILocate
    {
        public Entity.Location GetLocation()
        {
            string _locationProvider;
            Entity.Location location = null;

            LocationManager _locationManager = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine
            };
            IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

            if (acceptableLocationProviders.Any())
            {
                _locationProvider = acceptableLocationProviders.First();

                var lastLocation = _locationManager.GetLastKnownLocation(_locationProvider);
                location = new Entity.Location(lastLocation.Latitude, lastLocation.Longitude);

                return location;
            }
            else
            {
                _locationProvider = string.Empty;

                return location;
            }
        }
    }
}