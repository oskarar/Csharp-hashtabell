using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Csharp_hashtabell
{
    class GeoLoaction
    {


        private double longitude, latitude;



        public GeoLoaction(double latitude, double longitude) // So we can see location as 1 object
        {
            this.longitude = longitude;
            this.latitude = latitude;
        }

        public double Longitude
        {
            get => longitude;
        }

        public double Latitude
        {
            get => latitude;
        }

        public override bool Equals(object obj)
        {

            GeoLoaction location = (GeoLoaction)obj;

            bool latitude = location.latitude.Equals(this.latitude);
            bool longitude = location.longitude.Equals(this.longitude);


            return latitude && longitude;
        }
        public override int GetHashCode()
        {
            int hashcode = Math.Abs(Math.Pow(longitude, latitude)).GetHashCode();
            return hashcode;
        }

    }
}
