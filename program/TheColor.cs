internal class TheColor
{
    public TheColor()
    {
        Color red = Color.Red();
        Color maroon = new Color(128, 0, 0);
    }
}

public class Color
{
    private double R;
    private double G;
    private double B;

    public Color(double r, double g, double b)
    {
        R = r;
        G = g;
        B = b;
    }

    public static Color Red() => new Color(255, 0 , 0);
    public static Color Green() => new Color(0, 128, 0);
    public static Color Blue() => new Color(0, 0, 255);
    public static Color White() => new Color(255, 255, 255);
    public static Color Black() => new Color(0, 0, 0);
    public static Color Yellow() => new Color(255, 255, 0);
    public static Color Purple() => new Color(128, 0, 128);
    public static Color Orange() => new Color(255, 165, 0);
}
