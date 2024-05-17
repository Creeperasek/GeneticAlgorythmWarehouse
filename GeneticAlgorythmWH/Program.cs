namespace GeneticAlgorythmWH
{
    internal class Program
    {
        
        private static void Main(string[] args)
        {        
            int populationSize = 10;
            int shelfCount = 6;

            Random random = new Random();

            List<Shelf[]> population = new List<Shelf[]>();
    

            Shelf[] Warehouse = new Shelf[shelfCount];
            for (int i = 0;i < shelfCount; i++)
            {
                Warehouse[i].Id = i;
                Warehouse[i].Usage = random.Next(0, 100);
                Warehouse[i].Coordinates = new Point(random.Next(0,100),random.Next(0,100));
            }

            
            
        }
    }
}
    