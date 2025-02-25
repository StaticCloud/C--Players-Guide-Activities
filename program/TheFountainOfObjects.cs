internal class TheFountainOfObjects
{
    public TheFountainOfObjects()
    {
        Game game;

        Console.WriteLine("Select a room size (small, medium, large): ");
        string input = Console.ReadLine();

        switch (input.ToLower())
        {
            case "small":
                game = new Game(4, 4);
                break;
            case "medium":
                game = new Game(6, 6);
                break;
            case "large":
                game = new Game(8, 8);
                break;
            default:
                game = new Game(8, 8);
                break;
        }

        game.Run();
    }
}

interface IRoom
{
    public string GetStatus(bool activated);
    public bool IsFountain { get; init; }
}

class Game
{
    private bool IsActivated;
    private IRoom[,] Rooms;
    private Player Player;
    private (int Height, int Width) Dimensions;

    public Game(int Width, int Height)
    {
        IsActivated = false;
        Rooms = new Room[Width, Height];
        Player = new Player();
        Dimensions.Width = Width; 
        Dimensions.Height = Height;

        BuildRooms();
    }

    public void BuildRooms()
    {
        for (int i = 0; i < Dimensions.Height; i++)
        {
            for (int j = 0; j < Dimensions.Width; j++)
            {
                if (i == 0 && j == 0)
                {
                    Rooms[i, j] = new Entrance();
                }
                else if (i == Dimensions.Height - 1 && j == Dimensions.Width - 1)
                {
                    Rooms[i, j] = new Fountain();
                }
                else
                {
                    Rooms[i, j] = new Room();
                }
            }
        }
    }

    public void RenderGrid()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        for (int i = 0; i < Dimensions.Height; i++)
        {
            for (int j = 0; j < Dimensions.Width; j++)
            {
                Console.Write('|');

                if (Player.X == j && Player.Y == i) 
                {
                    Console.Write(" O ");
                } else
                {
                    Console.Write("   ");
                }
            }
            Console.WriteLine('|');
            Console.WriteLine(new String('-', (Dimensions.Width * 4) + 1));
        }
    }

    public void ReadInput()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("What do you want to do? ");
        string command = Console.ReadLine();
        if (command == "move north")
        {
            Player.Y = Player.Y > 0 ? Player.Y -= 1 : Player.Y;
        }
        else if (command == "move south")
        {
            Player.Y = Player.Y < 3 ? Player.Y += 1 : Player.Y;
        }
        else if (command == "move east")
        {
            Player.X = Player.X < 3 ? Player.X += 1 : Player.X;
        }
        else if (command == "move west")
        {
            Player.X = Player.X > 0 ? Player.X -= 1 : Player.X;
        }
        else if (command == "enable fountain")
        {
            if (GetRoom().IsFountain && IsActivated == false)
            {
                IsActivated = true;
            }
        }
    }

    public void DisplayPosition()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("---------------------------------------------------------");
        Console.WriteLine($"You are in the room at (Row={Player.Y} Column={Player.X})");
    }

    public void CheckActivated()
    {
        Console.WriteLine(GetRoom().GetStatus(IsActivated));
    }

    public void DisplayVictoryStatus()
    {
        RenderGrid();
        DisplayPosition();
        CheckActivated();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You win!");
    }

    public IRoom GetRoom() => Rooms[Player.Y, Player.X];

    public bool CheckWinningCondition() => IsActivated && Player.X == 0 && Player.Y == 0;

    public void Run()
    {
        while (CheckWinningCondition() == false)
        {
            RenderGrid();
            DisplayPosition();
            CheckActivated();
            ReadInput();
        }

        DisplayVictoryStatus();
    }
}

class Player
{
    public int X { get; set; } = 0;
    public int Y { get; set; } = 0;
}

class Room : IRoom
{
    public virtual bool IsFountain { get; init; } = false;

    public virtual string GetStatus(bool activated)
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        return activated ? "The Fountain of Objects has been reactivated, make your way to the entrance!" : "You listen for the Fountain of Objects, you hear nothing.";
    }
}

class Entrance : Room
{
    public override string GetStatus(bool activated)
    {
        Console.ForegroundColor = ConsoleColor.White;
        return activated ? "The Fountain of Objects has been reactivated, and you have esacaped with your life!" : "You see light coming from the cavern entrance.";
    }
}

class Fountain : Room
{
    public override bool IsFountain { get; init; } = true;

    public override string GetStatus(bool activated)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        return activated ? "You hear the rushing waters from the Fountain of Objects. It has been reactivated!" : "You hear water dripping from this room. The Fountain of Objects is here!";
    }
}

