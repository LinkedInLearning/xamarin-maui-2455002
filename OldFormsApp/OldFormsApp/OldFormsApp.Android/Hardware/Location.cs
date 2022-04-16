using Android.Locations;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using OldFormsApp.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(OldFormsApp.Droid.Hardware.Location))]
namespace OldFormsApp.Droid.Hardware
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

            _LocationManager = Android.App.Application.Context.GetSystemService(Android.Content.Context.LocationService) as LocationManager;

            if (_LocationManager != null)
            {
                _LocationManager.RequestLocationUpdates(LocationManager.GpsProvider, 2000, 1, this);
            }

            return _LocationTaskCompletionSource.Task;
        }

        public void OnLocationChanged(Android.Locations.Location location)
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