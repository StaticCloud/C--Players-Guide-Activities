namespace Program
{
    internal class NavigatingOperandCity
    {
        public NavigatingOperandCity()
        {
            BlockCoordinate blockCoordinate = new BlockCoordinate(0, 0);
            BlockOffset blockOffset = new BlockOffset(-5, 5);

            blockCoordinate = blockCoordinate + blockOffset;

            Console.WriteLine(blockCoordinate.ToString());

            blockCoordinate = blockCoordinate + Direction.North;

            Console.WriteLine(blockCoordinate.ToString());
        }
    }

    public record BlockCoordinate(int Row, int Column)
    {
        public static BlockCoordinate operator +(BlockCoordinate blockCoordinate, BlockOffset blockOffset) => new BlockCoordinate(blockCoordinate.Row + blockOffset.RowOffset, blockCoordinate.Column + blockOffset.ColumnOffset);
        public static BlockCoordinate operator +(BlockCoordinate blockCoordinate, Direction direction)
        {
            return direction switch
            {
                Direction.North => new BlockCoordinate(blockCoordinate.Row + 1, blockCoordinate.Column),
                Direction.East => new BlockCoordinate(blockCoordinate.Row, blockCoordinate.Column + 1),
                Direction.South => new BlockCoordinate(blockCoordinate.Row - 1, blockCoordinate.Column),
                Direction.West => new BlockCoordinate(blockCoordinate.Row, blockCoordinate.Column - 1)
            };
        }
    };
    public record BlockOffset(int RowOffset, int ColumnOffset);

    public enum Direction { North, East, South, West }
}