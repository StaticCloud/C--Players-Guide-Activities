internal class TheLockedDoor
{
    public TheLockedDoor() 
    {
        Door door = new Door("seesharp");
        door.Unlock("incorrect password");
        door.Unlock("seesharp");
        door.Open();
        door.Close();
        door.Lock();
        door.UpdatePasscode("seesharp", "dotnet");
        door.Unlock("dotnet");
    }
}

class Door
{
    private DoorState State { get; set; } = DoorState.Locked;
    private string Password { get; set; }

    public Door(string password)
    {
        Password = password;
    }

    public void Open()
    {
        if (State == DoorState.Closed)
        {
            State = DoorState.Opened;
        } else
        {
            Console.WriteLine("The door cannot be opened in it's current state.");
        }
    }

    public void Close()
    {
        if (State == DoorState.Opened)
        {
            State = DoorState.Closed;
        } else
        {
            Console.WriteLine("The door cannot be opened in it's current state.");
        }
    }

    public void Lock()
    {
        if (State == DoorState.Closed)
        {
            State = DoorState.Locked;
        } else
        {
            Console.WriteLine("The door cannot be opened in it's current state.");
        }
    }

    public void Unlock(string password)
    {
        if (State == DoorState.Locked && password == Password)
        {
            State = DoorState.Closed;
        } else
        {
            Console.WriteLine("The door cannot be opened in it's current state or you entered the incorrect password.");
        }
    }

    public void UpdatePasscode(string password, string newPassword)
    {
        if (password == Password) 
        {
            Password = newPassword;
        } else
        {
            Console.WriteLine("Wrong password!");
        }
    }
}

enum DoorState
{
    Closed,
    Opened,
    Locked
}