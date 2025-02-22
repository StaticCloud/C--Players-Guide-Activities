internal class TheOldRobot
{
    RobotCommand command;
    int index;
    string input;
    Robot robot;

    public TheOldRobot() 
    {
        index = 0;
        robot = new Robot();

        while (index < 3)
        {
            input = Console.ReadLine();

            command = input switch
            {
                "on" => new OnCommand(),
                "off" => new OffCommand(),
                "north" => new NorthCommand(),
                "south" => new SouthCommand(),
                "east" => new EastCommand(),
                "west" => new WestCommand()
            };

            robot.Commands[index++] = command;
        }

        robot.Run();
    }
}

class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public RobotCommand?[] Commands { get; } = new RobotCommand?[3];

    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}

class OnCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}

class NorthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered) 
        {
            robot.Y += 1;
        }
    }
}

class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X -= 1;
        }
    }
}

class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y -= 1;
        }
    }
}

class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X += 1;
        }
    }
}