using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternProject
{
    public sealed class Singleton // "sealed" means we cant make inheritance what is the main point of Singleton
    {

        private static readonly Lazy<Singleton> _instance = new Lazy<Singleton>(() => new Singleton());

        private const double _KyivLat = 50.450001;
        private const double _KyivLon = 30.523333;
        private const double _EarthRadius = 6371.0;
        

        private Singleton() 
        {
        
        }
        
        public static Singleton Instance => _instance.Value;

        private static double DegreesToRadians(double degrees)
        {
            return degrees * Math.PI / 180.0;
        }

        public double CalculateDistance(string CityInput, double LatInput, double LonInput)
        {
            try
            {
                
                if (LatInput < -90.0 || LatInput > 90.0)
                {
                    throw new ArgumentException("Latitude can`t be out of [-90;90] range");
                }

                if (LonInput < -180.0 || LonInput > 180.0)
                {
                    throw new ArgumentException("Longitude can`t be out of [-180;180] range");
                }

                
                double kyivLatRad = DegreesToRadians(_KyivLat);
                double kyivLonRad = DegreesToRadians(_KyivLon);

                double latInputRad = DegreesToRadians(LatInput);
                double lonInputRad = DegreesToRadians(LonInput);

                
                double deltaLat = latInputRad - kyivLatRad;
                double deltaLon = lonInputRad - kyivLonRad;

                // Haversine formula 
                double a = Math.Pow(Math.Sin(deltaLat / 2), 2) +
                    Math.Cos(kyivLatRad) * Math.Cos(latInputRad) *
                    Math.Pow(Math.Sin(deltaLon / 2), 2);

                double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

                double distance = _EarthRadius * c;

                
                Console.WriteLine($"Distance between Kyiv and {CityInput}({LatInput},{LonInput}) is {distance} km");

                return distance;
            }
            catch (ArgumentException ex)
            {
                
                Console.WriteLine($"Error: {ex.Message}. City: {CityInput}, Lat: {LatInput}, Lon: {LonInput}");
                return 0; 
            }
            catch (Exception ex)
            {
              
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                return 0; 
            }
        }
    }
}
