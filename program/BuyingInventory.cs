// Level 8 Challenge
// DefenseOfConsolas defenseOfConsolas = new DefenseOfConsolas();

internal class BuyingInventory
{
    public BuyingInventory()
    {
        string[] items = new string[] { "Lamp Oil", "Rope", "Bombs", "Machete", "Canoe", "Beefy-5-Layered Burrito" };

        Console.WriteLine("Lamp oil? Rope? Bombs? You want it? It's yours my friend, as long as you have enough rubies:");

        for (int i = 0; i < items.Length; i++)
        {
            Console.WriteLine($"{i + 1} - {items[i]}");
        }

        Console.WriteLine("Make your choice: ");

        int choice = int.Parse(Console.ReadLine());

        string response = choice switch
        {
            1 => "Lamp Oil costs 50 rubies!",
            2 => "Rope costs 10 rubies!",
            3 => "Bombs cost 100 rubies!",
            4 => "A machete costs 10 fingers!",
            5 => "A canoe costs 150 rubies!",
            6 => "A beefy-5-layered burrito costs $3.99 plus tax.",
            _ => "Sorry Link, I can't give credit. Come back when you're a little... hmmmmm... richer."
        };

        Console.WriteLine(response);
    }
}