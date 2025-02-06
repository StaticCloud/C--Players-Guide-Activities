internal class HuntingTheManicore
{
    public HuntingTheManicore() {
        int distance = getDistance();
        int cityHealth = 15;
        int manticoreHealth = 10;
        int round = 1;
        int damage = 1;
        int range = 0;

        while (cityHealth > 0 && manticoreHealth > 0)
        {
            damage = (round % 5 == 0 && round % 3 == 0) ? 10 : (round % 5 == 0 || round % 3 == 0) ? 3 : 1;
            displayStatus(round, cityHealth, manticoreHealth, damage);

            range = getRange();

            if (range > distance)
            {
                Console.WriteLine("That round OVERSHOT the target");
            } else if (range < distance)
            {
                Console.WriteLine("That round FELL SHORT of the target");
            } else
            {
                Console.WriteLine("That round was a DIRECT HIT!");
                manticoreHealth -= 1;
            }

            round += 1;
            cityHealth -= 1;
        }

        if (manticoreHealth <= 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
        } else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The city of Consolas has been destroyed by the Manticore.");
        }
    }

    int getDistance()
    {
        int distance = -1;

        while (distance < 0 || distance > 100)
        {
            Console.Write("Enter the Manticore's distance from the city (0 - 100): ");
            distance = int.Parse(Console.ReadLine());
        }

        Console.Clear();

        return distance;
    }

    int getRange()
    {
        int range = -1;

        while (range < 0 || range > 100)
        {
            Console.Write($"Enter the cannon range (0 - 100): ");
            range = int.Parse(Console.ReadLine());
        }

        return range;
    }

    void displayStatus(int round, int cityHealth, int manticoreHealth, int damage)
    {
        Console.WriteLine("");
        Console.WriteLine("ROUND | CITY HEALTH | MANTICORE HEALTH | EXPECTED DAMAGE");
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine($"{round, -5} | {cityHealth + "/15", -11} | {manticoreHealth + "/10", -16} | {damage}");
    }
}