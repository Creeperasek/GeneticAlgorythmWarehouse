namespace GeneticAlgorythmWH
{
    internal class Program
    {

        private static void Main(string[] args)
        {        
            int populationSize = 10;
            int shelfCount = 6;

            Random random = new Random();

            List<Warehouse> population = new List<Warehouse>();
    
            Warehouse warehouse= new Warehouse(shelfCount);

            population.Add(warehouse);

            for (int i = 0;i<populationSize;i++)
            {
                population.Add(new Warehouse(6));
                population[i].ShuffleShelvs();    
            }

            foreach (Warehouse wh in population)
            {
                Console.WriteLine(wh+"\n");
            }



            
            
        }
    }
}
    