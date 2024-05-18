using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace GeneticAlgorythmWH
{
    public class Shelf
    {
        public int Id { get; set; }
        public int Usage { get; set; }
        public Point Coordinates { get; set; }

        public Shelf(int id, int usage,Point coordinates){
            Id = id;
            Usage = usage;
            Coordinates = coordinates;
        }

        public double GetShelfValue()
        {
            double coordinatesValue = Coordinates.CalculateDistance(new Point(0,0));
            return coordinatesValue*Usage;
        }

        public override string ToString()
        {
            return $"Id:{Id}\tUsage:{Usage}\tCords:{Coordinates}\n";
        }

    }

}