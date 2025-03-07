using System.ComponentModel.DataAnnotations;
using System.Dynamic;

namespace Program
{
    internal class TheRobotFactory
    {
        private int _count = 0;
        private dynamic _robot;

        public TheRobotFactory() 
        {
            Run();
        }

        private void Run()
        {
            _count++;
            _robot = new ExpandoObject();

            Console.WriteLine($"You are producing robot #{_count}");

            PerformOperation("Would you like to name this robot?: ", AssignName);
            PerformOperation("Does this robot have a specific size?: ", AssignSize);
            PerformOperation("Does this robot need to be a specific color?: ", AssignColor);

            DisplayInfo();

            Run();
        }

        private void PerformOperation(string message, Action action)
        {
            Console.WriteLine(message);

            if (Console.ReadLine().ToLower() == "yes")
            {
                action();
            }
        }

        private void AssignName()
        {
            Console.WriteLine("What would you like to name this robot?: ");
            _robot.Name = Console.ReadLine();
        }

        private void AssignSize()
        {
            Console.WriteLine("What is its height?: ");
            _robot.Height = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("What is its height?: ");
            _robot.Width = Convert.ToInt32(Console.ReadLine());
        }

        private void AssignColor()
        {
            Console.WriteLine("What color?: ");
            _robot.Color = Console.ReadLine();
        }

        private void DisplayInfo()
        {
            foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)_robot) Console.WriteLine($"{property.Key}: {property.Value}");
        }
    }
}