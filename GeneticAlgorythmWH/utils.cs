namespace GeneticAlgorythmWH
{
    public static class Utils
    {
        public static void Shuffle<T>(this IList<T> array)
        {
            Random random= new Random();

            int n = array.Count;
            while (n > 1){
                int k = random.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
            
        }
    }

}