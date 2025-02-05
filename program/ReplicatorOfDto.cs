internal class ReplicatorOfDto
{
    public ReplicatorOfDto() {
        int[] numbers = new int[5];
        string suffix;

        for (int i = 0; i < numbers.Length; i++) {
            suffix = i + 1 < 4 ? (i + 1 < 3 ? (i + 1 < 2 ? "st" : "nd") : "rd") : "th";
            Console.Write($"Enter the {i + 1}{suffix} number: ");
            numbers[i] = int.Parse(Console.ReadLine());
        }

        int[] copy = numbers[0..5];

        Console.WriteLine("Original | Copy");
        Console.WriteLine("----------------");
        for (int i = 0; i < 5; i++) {
            Console.WriteLine($"{numbers[i], -8} | {copy[i]}");
        }
    }
}