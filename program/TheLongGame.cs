namespace Program
{
    internal class TheLongGame
    {
        public TheLongGame() 
        {
            new Game().Run();
        }
    }

    class Game
    {
        private int _score;
        private string _name;

        public Game()
        {
            _name = ReadName();
            _score = ReadScore();
        }

        private string ReadName()
        {
            Console.Write("Enter your name: ");
            return Console.ReadLine();
        }

        public void Run()
        {
            do
            {
                Console.Clear();
                _score += 1;
                Console.WriteLine($"Your score: {_score}");
            } while (Console.ReadKey().Key != ConsoleKey.Enter);

            SaveFile();
        }

        private void SaveFile()
        {
            File.WriteAllText($"./{_name}.txt", $"score={_score}");
        }

        private int ReadScore() 
        {
            if (File.Exists($"./{_name}.txt")) 
            {
                return Convert.ToInt32(File.ReadAllText($"./{_name}.txt").Split("=")[1]);
            } 
            else
            {
                return 0;
            }
        }
    }
}