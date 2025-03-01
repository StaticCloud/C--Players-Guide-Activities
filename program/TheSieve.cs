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

            Sieve sieve = option switch
            {
                1 => new Sieve(n => n % 2 == 0),
                2 => new Sieve(n => n > 0),
                3 => new Sieve(n => n % 10 == 0),
                _ => new Sieve(n => n % 2 == 0)
            };

            Console.WriteLine(sieve.IsGood(number));
        }
    }

    class Sieve
    {
        Func<int, bool> Func;

        public Sieve(Func<int, bool> func)
        {
            Func = func;
        }

        public bool IsGood(int number) => Func(number);
    }
}