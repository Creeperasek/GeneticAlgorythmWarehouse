using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace GeneticAlgorythmWH
{
    class Shelf
    {
        public int Id { get; set; }
        public int Usage { get; set; }
        public Point Coordinates { get; set; }

        public Shelf(int id, int usage,Point coordinates){
            Id = id;
            Usage = usage;
            Coordinates = coordinates;
        }
        
    }

}