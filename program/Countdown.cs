internal class Countdown
{
    public Countdown()
    {
        void CountFrom(int current)
        {
            if (current >= 0) {
                Console.WriteLine(current);
                CountFrom(current - 1);
            }
        }

        CountFrom(10);
    }
}