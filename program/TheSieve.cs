namespace Program
{
    internal class TheSieve
    {
        public TheSieve() 
        {
            Console.WriteLine(@$"Select an option:
1. Check if a number is even.
2. Check if a number is positive.
3. Check if a number is a multiple of 10.
");
            int option = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter a number: ");

            int number = Convert.ToInt32(Console.ReadLine());

            Predicate<int> func = option switch
            {
                1 => Sieve.IsEven,
                2 => Sieve.IsPositive,
                3 => Sieve.IsMultiple,
                _ => Sieve.IsEven
            };

            Sieve sieve = new Sieve(func);
            Console.WriteLine(sieve.IsGood(number));
        }
    }

    class Sieve
    {
        Predicate<int> Func;

        public Sieve(Predicate<int> func)
        { 
            Func = func;
        }

        public bool IsGood(int number)
        {
            return Func(number);
        }

        public static Predicate<int> IsEven = (num) => num % 2 == 0;
        public static Predicate<int> IsPositive = (num) => num > 0;
        public static Predicate<int> IsMultiple = (num) => num % 10 == 0;
    }
}