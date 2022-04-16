using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewMAUIApp.Library.Interfaces
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
