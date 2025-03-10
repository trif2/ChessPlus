# ChessPlus
A chess library for C# that implements obscure variants of chess. As of writing, this library implements:
- Standard Chess
- Glinski's Hexagonal Chess

## Installation

Since ChessPlus is not available on NuGet Gallery, you can install it by cloning the repository and building the project manually:

```bash
git clone https://github.com/yourusername/ChessPlus.git
cd ChessPlus
dotnet build
```

## Usage

Each variant has the following classes, prefixed by the variant (Classic, Hex):
- Board (ClassicBoard, HexBoard)
- Directions
- Move
- Piece (ClassicPiece subclasses do not have a prefix (ex. Bishop, King, etc.))
- Position

A game can be simulated using the following logic.
```csharp
HexBoard board = new HexBoard();
while (true)
{
    Console.WriteLine(board.ToString());
    Move playerMove = GetMove(); // Write method for retrieving move
    
    board.MovePiece(playerMove);

    // Check if game is over
    if (board.IsCheckmate())
    {
        Console.WriteLine("Checkmate!");
        break;
    }
    else if (board.IsStalemate())
    {
        Console.WriteLine("Stalemate!");
        break;
    }
    else if (board.IsKingInCheck(!currentPlayer))
    {
        Console.WriteLine("Check!");
    }
}
```