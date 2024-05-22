using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneticAlgorythmWH
{
    public class GeneticAlgorithm
    {
        public List<Warehouse> Population { get; set; }
        public int TournamentSize { get; set; }
        public double MutationRate { get; set; }
        public double CrossoverRate { get; set; }
        public Random Random { get; set; }

        public GeneticAlgorithm(int populationSize, int tournamentSize, double mutationRate, double crossoverRate)
        {
            Population = new List<Warehouse>();
            TournamentSize = tournamentSize;
            MutationRate = mutationRate;
            CrossoverRate = crossoverRate;
            Random = new Random();

            for (int i = 0; i < populationSize; i++)
            {
                Population.Add(new Warehouse(10));
            }
        }

        public Warehouse TournamentSelection()
        {
            List<Warehouse> tournament = new List<Warehouse>();
            for (int i = 0; i < TournamentSize; i++)
            {
                int randomIndex = Random.Next(Population.Count);
                tournament.Add(Population[randomIndex]);
            }

            return tournament.OrderByDescending(w => w.GetWarehouseValue()).First();
        }

        public void EvolvePopulation()
        {
            List<Warehouse> newPopulation = new List<Warehouse>();

            for (int i = 0; i < Population.Count; i++)
            {
                Warehouse parent1 = TournamentSelection();
                Warehouse parent2 = TournamentSelection();
                Warehouse child;

                if (Random.NextDouble() < CrossoverRate)
                {
                    child = Crossover(parent1, parent2);
                }
                else
                {
                    child = parent1;
                }


                newPopulation.Add(child);
            }




            foreach (Warehouse warehouse in newPopulation)
            {
                if (Random.NextDouble() < MutationRate)
                {
                    Mutate(warehouse);
                }
            }

            Population = newPopulation;
        }

        public Warehouse Crossover(Warehouse parent1, Warehouse parent2)
        {
            //Creating offspring
            Warehouse offspring = new Warehouse(parent1.shelvesList.Count);

            //Getting crossoverPoint
            int crossoverPoint = Random.Next(1, parent1.shelvesList.Count - 1);

            //Getting shelvs from parent1
            for (int i = 0; i < crossoverPoint; i++)
            {
                offspring.shelvesList[i] = parent1.shelvesList[i];
            }
            
            //Getting shelvs from parent2
            for (int i = crossoverPoint; i < parent2.shelvesList.Count; i++)
            {
                offspring.shelvesList[i] = parent2.shelvesList[i];
            }

            return offspring;
        }

        public void Mutate(Warehouse warehouse)
        {
            //Getting random warehouse and random shelf and getting its coordinates
            int randomIndexMutation = Random.Next(Population.Count);
            int randomShelfMutation = Random.Next(Population[randomIndexMutation].shelvesList.Count);
            Point MutationPoint = Population[randomIndexMutation].shelvesList[randomShelfMutation].Coordinates;

            //Asign coordinates to random shelf in mutated warehouse
            int randomIndex = Random.Next(warehouse.shelvesList.Count);
            warehouse.shelvesList[randomIndex].Coordinates = MutationPoint;

        }
    }
}
