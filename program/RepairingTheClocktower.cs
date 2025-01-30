internal class RepairingTheClocktower
{
    public RepairingTheClocktower()
    {
        Console.Write("Enter a number: ");
        string message = int.Parse(Console.ReadLine()) % 2 == 0 ? "Tick" : "Tock";
        Console.Write(message);
    }
}