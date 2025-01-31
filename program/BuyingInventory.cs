// Level 8 Challenge
// DefenseOfConsolas defenseOfConsolas = new DefenseOfConsolas();

internal class BuyingInventory
{
    public BuyingInventory()
    {
        string[,] items = { { "Lamp Oil", "50" }, { "Rope", "10" }, { "Bombs", "100" }, { "Machete", "10" }, { "Canoe", "150" }, { "Beefy-5-Layered Burrito", "20" } };

        Console.WriteLine("Lamp oil? Rope? Bombs? You want it? It's yours my friend, as long as you have enough rubies:");

        for (int i = 0; i < items.Length / 2; i++)
        {
            Console.WriteLine($"{i + 1} - {items[i, 0]}");
        }

        Console.Write("Make your choice: ");

        int choice = int.Parse(Console.ReadLine());

        string[] selection = choice switch
        {
            1 => [items[0, 0], items[0, 1]],
            2 => [items[1, 0], items[1, 1]],
            3 => [items[2, 0], items[2, 1]],
            4 => [items[3, 0], items[3, 1]],
            5 => [items[4, 0], items[4, 1]],
            6 => [items[5, 0], items[5, 1]],
            _ => ["Sorry Link, I can't give credit. Come back when you're a little... hmmmmm... richer.", "0"]
        };

        Console.Write("What is your name, traveler?: ");
        string name = Console.ReadLine();

        if (name == "Paulie")
        {
            selection[1] = (int.Parse(selection[1]) / 2).ToString();
        }

        if (choice > 6)
        {
            Console.WriteLine(selection[0]);
        } else
        {
            Console.WriteLine($"{selection[0]} costs {selection[1]} rubies!");
        }
    }
}