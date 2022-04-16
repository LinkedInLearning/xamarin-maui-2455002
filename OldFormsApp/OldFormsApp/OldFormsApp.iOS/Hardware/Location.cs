using CoreLocation;
using OldFormsApp.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(OldFormsApp.iOS.Hardware.Location))]
namespace OldFormsApp.iOS.Hardware
{
    public class Location : ILocation
    { 
        static TaskCompletionSource<LocationResult> _LocationTaskCompletionSource;

        private CLLocationManager _LocationManager;

        public Task<LocationResult> GetLocation()
        {
            if (_LocationTaskCompletionSource != null)
            {
                return _LocationTaskCompletionSource.Task;
            }

            _LocationTaskCompletionSource = new TaskCompletionSource<LocationResult>();

            _LocationManager = new CLLocationManager();
            
            if (_LocationManager.RespondsToSelector(new ObjCRuntime.Selector("requestWhenInUseAuthorization")))
            
            _LocationManager.RequestWhenInUseAuthorization();
            _LocationManager.DistanceFilter = CLLocationDistance.FilterNone;
            _LocationManager.DesiredAccuracy = CLLocation.AccuracyNearestTenMeters;
            _LocationManager.LocationsUpdated += Location_Update;
            _LocationManager.StartUpdatingLocation();

            return _LocationTaskCompletionSource.Task;
        }

        private void Location_Update(object sender, CLLocationsUpdatedEventArgs e)
        {
            if (_LocationTaskCompletionSource != null)
            {
                try
                {
                    _LocationManager.StopUpdatingLocation();

                    if (e.Locations.Length > 0)
                    {
                        var foundLocation = e.Locations[e.Locations.Length - 1];
                        var oResult = new LocationResult
                        {
                            Latitude = foundLocation.Coordinate.Latitude,
                            Longitude = foundLocation.Coordinate.Longitude
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
        }
    }
}