internal class TheMagicCannon
{
    public TheMagicCannon() 
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.Write($"{i.ToString()}: ");
            if (i % 3 == 0)
            {
                Console.WriteLine("Fire");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine("Electric");
            }
            else
            {
                Console.WriteLine("Normal");
            }
        }
    }
};