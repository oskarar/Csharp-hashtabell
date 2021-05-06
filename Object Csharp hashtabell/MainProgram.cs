using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Object_Csharp_hashtabell
{
    class MainProgram
    {


        public static void Main(string[] args)
        {

            string[] cities = System.IO.File.ReadAllLines("cities100000.txt"); // creates a huge string that contains all the data
            Hashdictionary<GeoLoaction, City> hashDictionary = new Hashdictionary<GeoLoaction, City>(100); // creates a dictionary with 100 slots and all the slots are a linked list


                foreach (var city in cities)
            {
                string[] info = city.Split('\t'); //info string is the length of the amount of tabs
                string CityName = info[0];
                double longitude = Double.Parse(info[1], System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
                double latitude = Double.Parse(info[2], System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
                int population = int.Parse(info[3]);
                GeoLoaction location = new GeoLoaction(longitude, latitude);
                City Newcity = new City(longitude, latitude, CityName, population);
                hashDictionary.Add(location , Newcity);


            }
            double Inputlongitude = 0;
            double Inputlatitude = 0;
            Console.WriteLine("Write a longitude and a latitude to see if there is a city there\n");
            Console.WriteLine("Longitude: ");
            Inputlatitude = Double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));
            Console.WriteLine("Latitude:");
            Inputlongitude = Double.Parse(Console.ReadLine(), System.Globalization.CultureInfo.CreateSpecificCulture("en-us"));

            GeoLoaction InputLocation = new GeoLoaction(Inputlongitude, Inputlatitude);

            if (hashDictionary.ContainsKey(InputLocation))
            {
                Console.WriteLine($"The city on that location is {hashDictionary[InputLocation].Name} with population of {hashDictionary[InputLocation].Population}");

            }
            else
            {
                Console.WriteLine("There was no city on that location");

                
            }

            Console.Read();
            //var enumerator = hashDictionary.GetEnumerator();
            //while(enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current);
            //}
        }


    }
}