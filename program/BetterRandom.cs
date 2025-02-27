namespace Program
{
    internal class BetterRandom
    {
        public BetterRandom()
        {
            Console.WriteLine(new Random().NextDoubleExtension(50.2345));
            Console.WriteLine(new Random().NextString("I", "like", "to", "sing!"));
            Console.WriteLine(new Random().CoinFlip(23));
        }
    }

    public static class RandomExtensions 
    {
        public static double NextDoubleExtension(this Random random, double max) 
        {
            return new Random().Next((int)max);
        }

        public static string NextString(this Random random, params string[] strings) 
        { 
            return strings[new Random().Next(strings.Length)];
        }

        public static bool CoinFlip(this Random random, double headsFreq = 50) 
        {
            return new Random().Next(100) < headsFreq;
        }
    }
}