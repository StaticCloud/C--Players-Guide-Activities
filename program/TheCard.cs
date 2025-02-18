internal class TheCard
{
    public TheCard() { }
}

enum CardColor
{
    Red,
    Green,
    Blue,
    Yellow
}

enum CardSymbol
{
    DollarSign,
    Percent,
    Power,
    Ampersand
}

class Card
{
    public CardColor Color { get; }
    public CardSymbol? Symbol { get; } = null;
    public int? Rank { get; } = null;

    public Card(CardColor color, int rank)
    {
        Color = color;
        Rank = rank;
    }

    public Card(CardColor color, CardSymbol symbol) 
    {
        Color = color;
        Symbol = symbol;
    }

    public string GetCardType() => Rank == null ? "Symbol" : "Rank";

    public string GenerateCardInfo()
    {
        string color;
        string? symbol = null;
        string? number = null;

        color = Color switch
        {
            CardColor.Red => "Red",
            CardColor.Green => "Green",
            CardColor.Blue => "Blue",
            CardColor.Yellow => "Yellow"
        };

        symbol = Symbol switch
        {
            CardSymbol.Power => "Power",
            CardSymbol.Ampersand => "Ampersand",
            CardSymbol.Percent => "Percent",
            CardSymbol.DollarSign => "Dollar Sign",
            null => null
        };

        number = Rank switch
        {
            1 => "One",
            2 => "Two",
            3 => "Three",
            4 => "Four",
            5 => "Five",
            6 => "Six",
            7 => "Seven",
            8 => "Eight",
            9 => "Nine",
            10 => "Ten",
            null => null
        };

        return $"The {color} {symbol ?? number}";
    }

    public static Card[] GenerateDeck() => new Card[]
    {
        new Card(CardColor.Red, CardSymbol.DollarSign),
        new Card(CardColor.Red, CardSymbol.Percent),
        new Card(CardColor.Red, CardSymbol.Power),
        new Card(CardColor.Red, CardSymbol.Ampersand),
        new Card(CardColor.Blue, CardSymbol.DollarSign),
        new Card(CardColor.Blue, CardSymbol.Percent),
        new Card(CardColor.Blue, CardSymbol.Power),
        new Card(CardColor.Blue, CardSymbol.Ampersand),
        new Card(CardColor.Green, CardSymbol.DollarSign),
        new Card(CardColor.Green, CardSymbol.Percent),
        new Card(CardColor.Green, CardSymbol.Power),
        new Card(CardColor.Green, CardSymbol.Ampersand),
        new Card(CardColor.Yellow, CardSymbol.DollarSign),
        new Card(CardColor.Yellow, CardSymbol.Percent),
        new Card(CardColor.Yellow, CardSymbol.Power),
        new Card(CardColor.Yellow, CardSymbol.Ampersand),
        new Card(CardColor.Red, 1),
        new Card(CardColor.Red, 2),
        new Card(CardColor.Red, 3),
        new Card(CardColor.Red, 4),
        new Card(CardColor.Red, 5),
        new Card(CardColor.Red, 6),
        new Card(CardColor.Red, 7),
        new Card(CardColor.Red, 8),
        new Card(CardColor.Red, 9),
        new Card(CardColor.Red, 10),
        new Card(CardColor.Blue, 1),
        new Card(CardColor.Blue, 2),
        new Card(CardColor.Blue, 3),
        new Card(CardColor.Blue, 4),
        new Card(CardColor.Blue, 5),
        new Card(CardColor.Blue, 6),
        new Card(CardColor.Blue, 7),
        new Card(CardColor.Blue, 8),
        new Card(CardColor.Blue, 9),
        new Card(CardColor.Blue, 10),
        new Card(CardColor.Yellow, 1),
        new Card(CardColor.Yellow, 2),
        new Card(CardColor.Yellow, 3),
        new Card(CardColor.Yellow, 4),
        new Card(CardColor.Yellow, 5),
        new Card(CardColor.Yellow, 6),
        new Card(CardColor.Yellow, 7),
        new Card(CardColor.Yellow, 8),
        new Card(CardColor.Yellow, 9),
        new Card(CardColor.Yellow, 10),
        new Card(CardColor.Green, 1),
        new Card(CardColor.Green, 2),
        new Card(CardColor.Green, 3),
        new Card(CardColor.Green, 4),
        new Card(CardColor.Green, 5),
        new Card(CardColor.Green, 6),
        new Card(CardColor.Green, 7),
        new Card(CardColor.Green, 8),
        new Card(CardColor.Green, 9),
        new Card(CardColor.Green, 10),
    };
}