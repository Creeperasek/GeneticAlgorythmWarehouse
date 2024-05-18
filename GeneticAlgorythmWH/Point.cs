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

        public double CalculateDistance (Point other)
        {
            return Math.Sqrt(Math.Pow(other.X - X,2)+Math.Pow(other.Y - Y,2));
        }

        public override string ToString ()
        {
            return $"({X},{Y})";
        }

    }
}