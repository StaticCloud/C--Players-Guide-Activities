﻿internal class TheFountainOfObjects
{
    public TheFountainOfObjects() 
    { 
        Game game = new Game();
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

    public Game()
    {
        IsActivated = false;
        Rooms = new Room[4, 4];
        Player = new Player();

        BuildRooms();
    }

    public void BuildRooms()
    {
        for (int i = 0; i < 4; i++) {
            for (int j = 0; j < 4; j++) {
                if (i == 0 && j == 0)
                {
                    Rooms[i, j] = new Entrance();
                }
                else if (i == 3 && j == 3)
                {
                    Rooms[i, j] = new Fountain();
                } else
                {
                    Rooms[i, j] = new Room();
                }
            }
        }
    }

    public void ReadInput()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("What do you want to do? ");
        string command = Console.ReadLine();
        if (command == "move north")
        {
            Player.Y -= 1;
        }
        else if (command == "move south")
        {
            Player.Y += 1;
        }
        else if (command == "move east")
        {
            Player.X += 1;
        }
        else if (command == "move west")
        {
            Player.X -= 1;
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

    public IRoom GetRoom() => Rooms[Player.Y, Player.X];

    public bool CheckWinningCondition() => IsActivated && Player.X == 0 && Player.Y == 0;

    public void Run()
    {
        while (CheckWinningCondition() == false)
        {
            DisplayPosition();
            CheckActivated();
            ReadInput();
        }

        DisplayPosition();
        CheckActivated();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("You win!");
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

