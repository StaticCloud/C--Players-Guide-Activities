internal class TheLawsOfFrench
{
    public TheLawsOfFrench()
    {
        // Finding minimum
        int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
        int min = int.MaxValue;
        int total = 0;
        float average = 0;

        foreach (int i in array)
        {
            min = i < min ? i : min;
            total += i;
        }

        average = (float)total / array.Length;

        Console.WriteLine($"Smallest integer: {min}");
        Console.WriteLine($"Average: {average}");
    }
}