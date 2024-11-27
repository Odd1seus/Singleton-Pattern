using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPatternProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var singleton = Singleton.Instance;
            var singleton1 = Singleton.Instance;

            var hashSingleton = singleton.GetHashCode();
            var hashSingleton1 = singleton1.GetHashCode();

            double latKharkiv = 49.988358;
            double lonKharkiv = 36.232845;

            singleton.CalculateDistance("Kharkiv", latKharkiv, lonKharkiv);

            double latOdessa = 46.482952;
            double lonOdessa = 30.712481;

            singleton.CalculateDistance("Odessa", latOdessa, lonOdessa);

            double wrongLat = 1231.4141412;
            double сorrectLon = -12.0123901;

            singleton.CalculateDistance("Not existent city", wrongLat, сorrectLon);

            double correctLat = 14.4141412;
            double wrongLon = -12123.0123901;

            singleton.CalculateDistance("Not existent city", correctLat, wrongLon);

            Console.WriteLine($"Hash code of singleton: {hashSingleton}");
            Console.WriteLine($"Hash code of sinleton 1: {hashSingleton1}");

            Console.ReadKey();
        }
    }
}
