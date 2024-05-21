using System.Net.Http.Headers;

namespace GeneticAlgorythmWH
{
    public class Warehouse
    {
        public List<Shelf> shelvesList = new List<Shelf>();
        

        public Warehouse(List<Shelf> shelves)
        {
            this.shelvesList = shelves;
        }
        public Warehouse(int shelfsCount)
        {
            Random random = new Random();

            for (int i = 0;i < shelfsCount; i++)
            {
                Shelf shelf = new Shelf(i,random.Next(0, 100),new Point(random.Next(0,100),random.Next(0,100)));
                shelvesList.Add(shelf);
            }
        }

        public void ShuffleShelvs()
        {
            shelvesList.Shuffle();
        }

        public double GetWarehouseValue()
        {
            double sum = 0;

            foreach (Shelf shelf in shelvesList){
                sum += shelf.GetShelfValue();
            }
            return sum;
        }

        public override string ToString()
        {
            string str = "Warehouse:";
            foreach (var shelf in shelvesList)
            {
                str += shelf.ToString();
            }
            return str;
        }
    }
}