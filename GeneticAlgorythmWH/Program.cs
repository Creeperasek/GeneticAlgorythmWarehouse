using System;

namespace GeneticAlgorythmWH
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GeneticAlgorithm algorithm = new GeneticAlgorithm(10, 2, 0.1, 50);

            for (int i = 0; i < 10; i++)
            {
                algorithm.EvolvePopulation();
                List<Warehouse> population = algorithm.Population;

                Console.WriteLine($"GEN {i}:\n");
                var warehouses = population.OrderByDescending(w => w.GetWarehouseValue()).First();
                // foreach (var warehouse in warehouses){
                Console.WriteLine($"{warehouses}");
                // }
                
                Console.WriteLine("\n");
            }

        }
    }
}
