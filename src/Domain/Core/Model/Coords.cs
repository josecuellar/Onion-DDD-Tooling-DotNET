using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core.Model
{

    /// <summary>
    /// Value Object Coords
    /// </summary>
    public class Coords
    {

        private readonly double Latitude;

        private readonly double Longitude;

        public Coords(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public Coords changeLatitude(double latitude)
        {
            return new Coords(latitude, this.Longitude);
        }

        public Coords changeLongitude(double longitude)
        {
            return new Coords(this.Latitude, longitude);
        }

        public Coords relocatePosition(double latitude, double longitude)
        {
            return new Coords(latitude, longitude);
        }

    }

}
