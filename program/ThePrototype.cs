// Level 8 Challenge
// DefenseOfConsolas defenseOfConsolas = new DefenseOfConsolas();

internal class ThePrototype
{
    public ThePrototype() 
    {
        Console.Write("Pick a number between 0 and 100: ");
        int number = int.Parse(Console.ReadLine());

        int guess = -1;

        while (guess != number)
        {
            Console.Write("Guess the number: ");
            guess = int.Parse(Console.ReadLine());

            if (guess < number)
            {
                Console.WriteLine("Your guess is too low!");
            }

            if (guess > number)
            {
                Console.WriteLine("Your guess is too high!");
            }
        }

        Console.WriteLine("You have succesfully guessed the number!");
    }
}