internal class RoomCoordinates
{
    public RoomCoordinates()
    {
        Coordinate coordinateA = new Coordinate(1, 2);
        Coordinate coordinateB = new Coordinate(2, 2);
        Console.WriteLine(CheckAdjacency(coordinateA, coordinateB));
    }

    public bool CheckAdjacency(Coordinate A, Coordinate B) => (Math.Abs(A.Row - B.Row) == 1 || Math.Abs(A.Col - B.Col) == 1);
}

struct Coordinate
{
    public readonly int Row { get; }
    public readonly int Col { get; }

    public Coordinate(int row, int col)
    {
        Row = row;
        Col = col;
    }
}