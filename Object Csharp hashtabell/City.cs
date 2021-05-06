using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Csharp_hashtabell
{
    class City
    {
        string name;
        int population;
        GeoLoaction location;

        public City(double Longitude, double Latitude, string Name, int Population)
        {
            name = Name;
            population = Population;
            location = new GeoLoaction(Latitude, Longitude);



        }
        
        public int Population
        {
            get => population;
            set => population = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }
        public GeoLoaction Location
        {
            get => location;
            set => location = value;
        }

    }
}
