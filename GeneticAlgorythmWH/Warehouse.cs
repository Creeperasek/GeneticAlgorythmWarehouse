using System.Net.Http.Headers;

namespace GeneticAlgorythmWH
{
    
    public class Warehouse
    {
        public static int ClassID = 0;
        public int Id { get; set;}
        public List<Shelf> shelvesList = new List<Shelf>();
        

        public Warehouse(List<Shelf> shelves)
        {
            this.Id = ClassID;
            ClassID++;
            this.shelvesList = shelves;
        }
        public Warehouse(int shelfsCount)
        {
            this.Id = ClassID;
            ClassID++;

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
            string str = $"Warehouse {Id} - Value: {GetWarehouseValue()}:\n";
            foreach (var shelf in shelvesList)
            {
                str += shelf.ToString();
            }
            return str;
        }
    }
}