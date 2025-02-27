using System.Globalization;

namespace Program
{
    internal class SaferNumberCrunching
    {
        int intVal;
        double doubleVal;
        bool boolVal;

        public SaferNumberCrunching()
        {
            GetInput<int>(intVal);
            GetInput<double>(doubleVal);
            GetInput<bool>(boolVal);
        }

        public void GetInput<T>(T outVal) where T : IParsable<T>
        {
            while (true)
            {
                string? input = Console.ReadLine();

                if (T.TryParse(input, CultureInfo.InvariantCulture, out outVal)) break;
            }

            Console.WriteLine($"You have entered an {outVal.GetType()} value of: {outVal}");
        }
    }
}