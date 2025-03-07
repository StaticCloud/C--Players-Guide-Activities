namespace Program
{
    internal class UniterOfAdds
    {
        public UniterOfAdds() 
        {
            Console.WriteLine(Add(3, 5));
            Console.WriteLine(Add(4.7, 6.2));
            Console.WriteLine(Add("Hello ", "world!"));
            Console.WriteLine(Add(new DateTime(1999), new TimeSpan()));
        }

        public static dynamic Add(dynamic a, dynamic b) => a + b;
    }
}