
using System.Threading.Tasks;

namespace OldFormsApp.Interfaces
{
    public interface ILocation
    {
        Task<LocationResult> GetLocation();
    }

    public class LocationResult
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}