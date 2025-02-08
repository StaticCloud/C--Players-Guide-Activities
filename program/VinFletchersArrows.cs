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

        Console.Write("What type of arrowhead would you like (steel, wool, obsidian)?: ");
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
    public ArrowHead _arrowHead;
    public int _shaftLength;
    public Fletching _fletching;

    public Arrow(ArrowHead arrowHead, int shaftLength, Fletching fletching)
    {
        _arrowHead = arrowHead;
        _shaftLength = shaftLength;
        _fletching = fletching;
    }

    public int CalculateHeadPrice() => _arrowHead == ArrowHead.steel ? 10 : (_arrowHead == ArrowHead.wood ? 3 : 5);

    public float CalculateShaftPrice() => (float)(_shaftLength * 0.05);

    public int CalculareFletchingPrice() => _fletching == Fletching.plastic ? 10 : (_fletching == Fletching.goose ? 3 : 5);

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