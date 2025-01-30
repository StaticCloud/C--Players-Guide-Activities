internal class Watchtower
{
    public Watchtower()
    {
        string[,] directions = { { "NW", "N", "NE" }, 
                                 { "W" , "!", "E"}, 
                                 { "SW", "S", "SE" } };

        Console.Write("Enter an X coordinate between 0 and 2: ");
        int x = int.Parse(Console.ReadLine());

        Console.Write("Enter a Y coordinate between 0 and 2: ");
        int y = int.Parse(Console.ReadLine());

        string direction = "...well we don't know because those coordinates are off-grid, doofus";

        // Probably would be less tedious with a switch statement (and a dictionary for the directions), but I'm sticking to if statements because I'm a stickler
        if (x < 3 && y < 3)
        {
            if (directions[x, y] == "NW")
            {
                direction = "Northwest";
            }
            else if (directions[x, y] == "N")
            {
                direction = "North";
            }
            else if (directions[x, y] == "NE")
            {
                direction = "Northeast";
            }
            else if (directions[x, y] == "W")
            {
                direction = "West";
            }
            else if (directions[x, y] == "!")
            {
                direction = "...oh crap, they're here";
            }
            else if (directions[x, y] == "E")
            {
                direction = "East";
            }
            else if (directions[x, y] == "SW")
            {
                direction = "Southwest";
            }
            else if (directions[x, y] == "S")
            {
                direction = "South";
            }
            else if (directions[x, y] == "SE")
            {
                direction = "Southeast";
            }
        }
        

        Console.WriteLine($"The enemies are coming from the {direction}!");
    }
}