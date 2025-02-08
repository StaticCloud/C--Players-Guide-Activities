internal class VinFletchersArrows
{

    public VinFletchersArrows()
    {
        init();
    }

    public void init()
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
            init();
        }
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