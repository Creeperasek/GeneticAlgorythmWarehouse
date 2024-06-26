﻿using System;

namespace GeneticAlgorythmWH
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            GeneticAlgorithm algorithm = new GeneticAlgorithm(5, 2, 0.1, 50);

            for (int i = 0; i < 5; i++)
            {
                algorithm.EvolvePopulation();
                List<Warehouse> population = algorithm.Population;

                Console.WriteLine($"GEN {i}:\n");
                var warehouses = population.OrderBy(w => w.GetWarehouseValue()).First();
                
                Console.WriteLine($"{warehouses}");
                
                Console.WriteLine("\n");
            }

        }
    }
}
