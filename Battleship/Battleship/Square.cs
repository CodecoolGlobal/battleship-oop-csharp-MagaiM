using Codecool.Battleship.Enums;

namespace Codecool.Battleship
{
    internal class Square
    {
        public (int x, int y) Position { get; set; }

        public SquareStatus SquareStatus { get; set; }

        public Square(int x, int y)
        {
            SquareStatus = SquareStatus.Empty;
            Position = (x, y);
        }

        public Square(SquareStatus squareStatus)
        {
            SquareStatus = squareStatus;
        }

        public Square(int x, int y, SquareStatus squareStatus)
        {
            SquareStatus = squareStatus;
            Position = (x, y);
        }

        public Square()
        {
            SquareStatus = SquareStatus.Empty;
        }

        public char GetCharacter()
        {
            return (char)SquareStatus;
        }
    }
}
