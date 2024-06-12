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

            Warehouse warehouse = new Warehouse(6);

            for (int i = 1; i < populationSize; i++)
            {
                Population.Add(warehouse);
                warehouse.Shuffle();
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

            while (Population.Count > 0)
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
                Population.Remove(parent1);
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
            List<Shelf> offspringShelves = new List<Shelf>();

            int crossoverPoint = Random.Next(1, parent1.shelvesList.Count - 1);

            
            for (int i = 0; i < crossoverPoint; i++)
            {
                var parentShelf = parent1.shelvesList[i];
                offspringShelves.Add(new Shelf(parentShelf.Id, parentShelf.Usage, new Point(parentShelf.Coordinates.X, parentShelf.Coordinates.Y)));
            }

            
            for (int i = crossoverPoint; i < parent2.shelvesList.Count; i++)
            {
                var parentShelf = parent2.shelvesList[i];
                offspringShelves.Add(new Shelf(parentShelf.Id, parentShelf.Usage, new Point(parentShelf.Coordinates.X, parentShelf.Coordinates.Y)));
            }

            return new Warehouse(offspringShelves);
        }

        //Mutates Usage of random Shelf
        public void Mutate(Warehouse warehouse)
        {
            int randomShelfIndex = Random.Next(warehouse.shelvesList.Count);
            warehouse.shelvesList[randomShelfIndex].Usage = Random.Next(0, 100);
        }
    }
}
