internal class ThePoint
{
    public ThePoint()
    {
        Point point1 = new Point(2, 3);
        Point point2 = new Point(-4, 0);

        Console.WriteLine($"{point1.X}, {point1.Y}");
        Console.WriteLine($"{point2.X}, {point2.Y}");
    }
}

public class Point
{

    // Make X and Y mutable since points are subject to change
    public double X { get; set;  } = 0;
    public double Y { get; set;  } = 0;

    public Point() { }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
} 