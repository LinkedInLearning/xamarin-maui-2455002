using Android.Locations;
using Android.OS;
using Android.Runtime;
using NewMAUIApp.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using android = Android;

namespace NewMAUIApp.Library.Platforms.Android
{
    public class Location : Java.Lang.Object, ILocation, ILocationListener
    {
        static TaskCompletionSource<LocationResult> _LocationTaskCompletionSource;

        private LocationManager _LocationManager;

        public Task<LocationResult> GetLocation()
        {

            if (_LocationTaskCompletionSource != null)
            {
                return _LocationTaskCompletionSource.Task;
            }

            _LocationTaskCompletionSource = new TaskCompletionSource<LocationResult>();

            _LocationManager = android.App.Application.Context.GetSystemService(android.Content.Context.LocationService) as LocationManager;

            if (_LocationManager != null)
            {
                _LocationManager.RequestLocationUpdates(LocationManager.GpsProvider, 2000, 1, this);
            }

            return _LocationTaskCompletionSource.Task;
        }

        public void OnLocationChanged(android.Locations.Location location)
        {
            try
            {
                _LocationManager.RemoveUpdates(this);

                if (location != null)
                {
                    var oResult = new LocationResult
                    {
                        Latitude = location.Latitude,
                        Longitude = location.Longitude
                    };

                    _LocationTaskCompletionSource.SetResult(oResult);
                }
                else
                {
                    _LocationTaskCompletionSource.SetCanceled();
                }
            }
            catch (Exception ex)
            {
                _LocationTaskCompletionSource.SetException(ex);
            }
            finally
            {
                _LocationTaskCompletionSource = null;
            }
        }

        public void OnProviderDisabled(string provider)
        {
        }

        public void OnProviderEnabled(string provider)
        {
        }

        public void OnStatusChanged(string provider, [GeneratedEnum] Availability status, Bundle extras)
        {
        }
    }
}
