internal class TheOldRobot
{
    IRobotCommand command;
    string input;
    Robot robot;

    public TheOldRobot() 
    {
        robot = new Robot();

        while (input != "stop")
        {
            input = Console.ReadLine();

            command = input switch
            {
                "on" => new OnCommand(),
                "off" => new OffCommand(),
                "north" => new NorthCommand(),
                "south" => new SouthCommand(),
                "east" => new EastCommand(),
                "west" => new WestCommand(),
                "stop" => new OffCommand()
            };

            robot.Commands?.Add(command);
        }

        robot.Run();
    }
}

class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public List<IRobotCommand>? Commands = new List<IRobotCommand>();

    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

interface IRobotCommand
{
    void Run(Robot robot);
}

class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) 
        {
            robot.Y += 1;
        }
    }
}

class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X -= 1;
        }
    }
}

class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y -= 1;
        }
    }
}

class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X += 1;
        }
    }
}