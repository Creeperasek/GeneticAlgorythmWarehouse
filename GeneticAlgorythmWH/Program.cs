namespace GeneticAlgorythmWH
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Warehouse> population = new List<Warehouse>();

            population.GeneratePopulation(10, 6);


            foreach (var warehouse in population)
            {
                Console.WriteLine("Warehouse: {0}", warehouse.GetWarehouseValue());
            }


        }
    }
}
