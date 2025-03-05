namespace Program
{
    internal class TheRepeatingSystem
    {
        RecentNumbers recentNumbers;

        public TheRepeatingSystem() 
        {
            recentNumbers = new RecentNumbers();

            Thread thread = new Thread(GenerateNums);
            thread.Start();

            while (true) 
            {
                if (Console.ReadKey(intercept: true).Key == ConsoleKey.E) 
                { 
                    if (recentNumbers.IsEqual())
                    {
                        Console.WriteLine("You have correctly identified the repeat!");
                    } 
                    else
                    {
                        Console.WriteLine("That was incorrect!");
                    }
                }
            }
        }

        public void GenerateNums()
        {
            while (true) 
            { 
                Thread.Sleep(1000);
                int randomNum = new Random().Next(10);
                recentNumbers.UpdateNums(randomNum);
                recentNumbers.DisplayNums();
            }
        }
    }

    class RecentNumbers
    {
        private readonly object _prevLockOne = new object();
        private readonly object _prevLockTwo = new object();

        private int _prevOne;
        private int _prevTwo;

        public int PrevOne
        {
            get
            {
                lock (_prevLockOne)
                {
                    return _prevOne;
                }
            }

            set
            {
                lock ( _prevLockOne)
                {
                    _prevOne = value;
                }
            }
        }

        public int PrevTwo
        {
            get
            {
                lock (_prevLockTwo)
                {
                    return _prevTwo;
                }
            }

            set
            {
                lock (_prevLockTwo)
                {
                    _prevTwo = value;
                }
            }
        }

        public RecentNumbers()
        {
            PrevOne = 0;
            PrevTwo = PrevOne;
        }

        public void UpdateNums(int num)
        {
            PrevTwo = PrevOne;
            PrevOne = num;
        }

        public void DisplayNums() 
        {
            Console.WriteLine($"Previous two numbers: {PrevOne}, {PrevTwo}");
        }

        public bool IsEqual() => PrevOne == PrevTwo;
    }
}