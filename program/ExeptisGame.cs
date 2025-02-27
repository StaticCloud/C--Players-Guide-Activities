namespace Program
{
    internal class ExeptisGame
    {
        List<int> selectedNums;
        int currentPlayer;
        int oatmealCookie;

        public ExeptisGame() 
        {
            selectedNums = new List<int>();
            currentPlayer = 1;
            oatmealCookie = new Random().Next(0, 10);

            try
            {
                Run();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        void Run()
        {
            int input = -1;

            while (input != oatmealCookie) 
            {
                if ((input >= 0) && (input <= 9))
                {
                    currentPlayer = (currentPlayer % 2) + 1;
                    selectedNums.Add(input);
                }

                Console.Write($"Player {currentPlayer}, pick a cookie (0 - 9)!: ");

                int.TryParse(Console.ReadLine(), out input);

                if (selectedNums.Contains(input)) throw new Exception("That number has already been selected!");
            }

            Console.WriteLine($"Player {currentPlayer} ate the cookie! Player {currentPlayer} loses!");

        }
    }
}