internal class SimulasTest
{
    enum Chest
    {
        open,
        closed,
        locked
    }

    public SimulasTest() 
    {
        Chest chest = Chest.closed;
        string input;

        while (true) {
            Console.Write($"The chest is {chest}. What do you want to do?: ");
            input = Console.ReadLine().ToLower();

            if (chest == Chest.open)
            {
                chest = input == "close" ? Chest.closed : Chest.open;
            }
            else if (chest == Chest.closed) 
            {
                chest = input == "lock" ? Chest.locked : (input == "open" ? Chest.open : Chest.closed);
            }
            else if (chest == Chest.locked)
            {
                chest = input == "unlock" ? Chest.closed : Chest.locked;
            }
        }
    }
}