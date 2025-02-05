internal class TakingANumber
{
    public TakingANumber()
    {
        static int AskForNumber(string text)
        {
            Console.Write(text);
            return int.Parse(Console.ReadLine());
        }

        static int AskForNumberInRange(string text, int min, int max)
        {
            int value = min - 1;

            while (value < min || value > max) 
            {
                Console.WriteLine(text);
                value = int.Parse(Console.ReadLine());
            }

            return value;
        }

        int askNum = AskForNumber("Enter a number: ");
        int numRange = AskForNumberInRange("Enter a number between 0 and 10: ", 0, 10);

        Console.WriteLine(askNum);
        Console.WriteLine(numRange);
    }
}