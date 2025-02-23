internal class ColoredItems
{
    public ColoredItems() 
    {

        ColoredItem<Sword> coloredSword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Red);
        coloredSword.Display();
        ColoredItem<Bow> coloredBow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Blue);
        coloredBow.Display();
        ColoredItem<Axe> coloredAxe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);
        coloredAxe.Display();
    }
}

public class Sword() { }
public class Bow() { }
public class Axe() { }

class ColoredItem<T>
{
    public T Item { get; set; }
    public ConsoleColor Color { get; set; }

    public ColoredItem(T item, ConsoleColor color) 
    {
        Item = item;
        Color = color;
    }

    public void Display()
    {
        Console.ForegroundColor = Color;
        Console.WriteLine(Item.ToString());
    }
}