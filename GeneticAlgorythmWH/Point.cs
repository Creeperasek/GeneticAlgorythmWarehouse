namespace GeneticAlgorythmWH
{
    public class Point
    {
        public double X { get; set;}
        public double Y { get; set;}

        public Point(double x, double y){
            this.X = x;
            this.Y = y;
        }

        public static double CalculateDistance (Point p1, Point p2)
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X,2)+Math.Pow(p2.Y - p1.Y,2));
        }

    }
}