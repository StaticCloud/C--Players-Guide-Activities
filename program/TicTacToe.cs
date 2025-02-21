internal class TicTacToe
{
    public TicTacToe() 
    {
        Board board = new Board();

        Tile[] players = [Tile.X, Tile.O];

        // Use currentPlayerIndex on our players array to index the current player
        // position represents the position (within the range of 1 - 9) on the board the current player wants to make their move
        // movesLeft tracks our remaining moves and decrements after every round (if the move was valid)
        int currentPlayerIndex = 0, position = 0, movesLeft = 9;

        // validMove tracks if the move was within range and placed on an empty tile
        // winningCondition tracks if any of the winning conditions have been met
        bool validMove = true, winningCondition = false;

        // Our actual variable that keeps track of the current player (return X or O)
        Tile currentPlayer = players[currentPlayerIndex];

        while (!winningCondition && movesLeft > 0)
        {
            Console.Clear();

            if (!validMove) Console.WriteLine("Input was either invalid or that tile is already occupied.");

            board.Render();

            Console.Write($"Player {currentPlayer}, where would you like to make your move (1 - 9)?: ");
            position = int.Parse(Console.ReadLine());

            // Assess if position was valid (in range, or not in an occupied spot)
            validMove = board.Update(position, currentPlayer);

            // Assess if the updated board meets the winning conditions in board.AssessBoard
            winningCondition = validMove ? board.AssessBoard(currentPlayer) : winningCondition;

            // Update the current player (if the winning condition is not met and if the move was valid) using modulus to alternate between the two values in our players array
            currentPlayer = validMove && !winningCondition ? players[++currentPlayerIndex % players.Length] : currentPlayer;
            
            // Reduce total moves left if the move was valid
            movesLeft = validMove ? movesLeft - 1 : movesLeft;
        }

        Console.Clear();
        board.Render();

        // If the game terminates and the winning condition was met, congratulate the victorious player
        if (winningCondition) Console.WriteLine($"Congratulations, player {currentPlayer}! You reign victorious!");

        // If the total number of moves left is 0 and the winning condition was not met, declare a draw
        if (movesLeft == 0 && !winningCondition) Console.WriteLine("It's a draw! No one is victorious!");
    }
}

class Board
{
    // Our dictionary collection that tracks each tile within our board
    private Dictionary<int, Tile?> _tiles;

    public Board()
    {
        // Initialize an empty board
        _tiles = new Dictionary<int, Tile?>()
        {
            { 1, Tile._ },
            { 2, Tile._ },
            { 3, Tile._ },
            { 4, Tile._ },
            { 5, Tile._ },
            { 6, Tile._ },
            { 7, Tile._ },
            { 8, Tile._ },
            { 9, Tile._ }
        };
    }

    // Render our board to the console
    public void Render()
    {
        Console.WriteLine($@"{_tiles[1]} | {_tiles[2]} | {_tiles[3]}
---------
{_tiles[4]} | {_tiles[5]} | {_tiles[6]}
---------
{_tiles[7]} | {_tiles[8]} | {_tiles[9]}");
    }

    // Update our board array given a valid index and symbol
    // Returning bool to inform main gameplay loop if updating the board was successful or not
    public bool Update(int index, Tile symbol)
    {
        // Inform the user that the board failed to update if the index was not within range or the tile was not empty
        if ((index > 9 || index < 1) || _tiles[index] != Tile._) return false;

        _tiles[index] = symbol;

        return true;
    }

    // Assess the current state of our board given a symbol and test it against the winning conditions below
    // Return true if any of the following conditions are met
    public bool AssessBoard(Tile symbol)
    {
        return (_tiles[1] == symbol && _tiles[2] == symbol && _tiles[3] == symbol) ||
               (_tiles[4] == symbol && _tiles[5] == symbol && _tiles[6] == symbol) ||
               (_tiles[7] == symbol && _tiles[8] == symbol && _tiles[9] == symbol) ||
               (_tiles[1] == symbol && _tiles[4] == symbol && _tiles[7] == symbol) ||
               (_tiles[2] == symbol && _tiles[5] == symbol && _tiles[8] == symbol) ||
               (_tiles[3] == symbol && _tiles[6] == symbol && _tiles[9] == symbol) ||
               (_tiles[1] == symbol && _tiles[5] == symbol && _tiles[9] == symbol) ||
               (_tiles[3] == symbol && _tiles[5] == symbol && _tiles[7] == symbol);
    }
}

// Our enumerable object that contains the contents of our board which will either be and empty space, X, or O
enum Tile { X, O, _ }