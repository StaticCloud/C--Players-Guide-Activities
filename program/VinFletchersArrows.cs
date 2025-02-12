internal class VinFletchersArrows
{

    public VinFletchersArrows()
    {
        string input;

        while (true)
        {
            Console.WriteLine("Would you like a custom or pre-defined arrow (custom or predefined)?: ");
            input = Console.ReadLine();

            if (input.ToLower() == "custom")
            {
                customArrow();
                break;
            } else if (input.ToLower() == "predefined")
            {
                preDefinedArrow();
                break;
            }
        }
    }

    public void customArrow()
    {
        string arrowHeadInput = "";
        string fletchingInput = "";
        int lengthInput = 0;

        Console.Write("What type of arrowhead would you like (steel, wood, obsidian)?: ");
        arrowHeadInput = Console.ReadLine();

        Console.Write("What type of fletching would you like (plastic, turkey, goose)?: ");
        fletchingInput = Console.ReadLine();

        Console.Write("What is the desired length of your shaft (60-100cm)?: ");
        lengthInput = int.Parse(Console.ReadLine());

        if (Enum.TryParse(arrowHeadInput, true, out ArrowHead arrowHead) && 
            Enum.TryParse(fletchingInput, true, out Fletching fletching) &&
            (lengthInput < 101 && lengthInput > 59))
        {
            Arrow arrow = new Arrow(arrowHead, lengthInput, fletching);
            Console.WriteLine($"Your total is: {arrow.GetCost()} gold");
        } else
        {
            Console.WriteLine("Sorry, one of your choices was invalid");
            customArrow();
        }
    }

    public void preDefinedArrow()
    {
        Console.WriteLine("Which predefined arrow would you like (Elite, Beginner or Marksman)?: ");

        string input;
        Arrow arrow;

        while (true)
        {
            input = Console.ReadLine();

            if (input.ToLower() == "elite")
            {
                arrow = Arrow.CreateEliteArrow();
                break;
            } else if (input.ToLower() == "beginner")
            {
                arrow = Arrow.CreateBeginnerArrow();
                break;
            } else if (input.ToLower() == "marksman")
            {
                arrow = Arrow.CreateMarksmanArrow();
                break;
            }
        }

        Console.WriteLine($"Your total is: {arrow.GetCost()} gold");
    }

}

class Arrow
{
    private ArrowHead ArrowHead { get; set; }
    private int ShaftLength { get; set; }
    private Fletching Fletching { get; set; }

    public Arrow(ArrowHead arrowHead, int shaftLength, Fletching fletching)
    {
        ArrowHead = arrowHead;
        ShaftLength = shaftLength;
        Fletching = fletching;
    }

    public int CalculateHeadPrice() => ArrowHead == ArrowHead.steel ? 10 : (ArrowHead == ArrowHead.wood ? 3 : 5);

    public float CalculateShaftPrice() => (float)(ShaftLength * 0.05);

    public int CalculareFletchingPrice() => Fletching == Fletching.plastic ? 10 : (Fletching == Fletching.goose ? 3 : 5);

    public float GetCost() => CalculateHeadPrice() + CalculateShaftPrice() + CalculareFletchingPrice();

    public static Arrow CreateEliteArrow() => new Arrow(ArrowHead.steel, 95, Fletching.plastic);

    public static Arrow CreateBeginnerArrow() => new Arrow(ArrowHead.wood, 75, Fletching.goose);

    public static Arrow CreateMarksmanArrow() => new Arrow(ArrowHead.steel, 65, Fletching.goose);
}

enum ArrowHead
{
    steel,
    wood,
    obsidian
}

enum Fletching
{
    plastic,
    turkey,
    goose
}