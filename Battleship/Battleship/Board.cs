using Codecool.Battleship.Enums;

namespace Codecool.Battleship
{
    internal class Board
    {
        public Square[,] Ocean { get; }


        public Board()
        {
            Ocean = new Square[10, 10];

            for (int y = 0; y < Ocean.GetLength(0); y++)
            {
                for (int x = 0; x < Ocean.GetLength(1); x++)
                {
                    Ocean[y, x] = new Square(x, y);
                    //Ocean[y, x].Position = (x, y);
                }
            }
        }

        public bool IsPlacementOk(int x, int y, Direction direction, ShipType shipType)
        {
            for (int i = 0; i < (int)shipType; i++)
            {
                switch (direction)
                {
                    case Direction.Up:
                        if (IsOutOfRange(x, y - i) || IsNotEmpty(x, y - i) || !IsNotTouching(x, y - i))
                            return false;
                        break;
                    case Direction.Down:
                        if (IsOutOfRange(x, y + i) || IsNotEmpty(x, y + i) || !IsNotTouching(x, y + i))
                            return false;
                        break;
                    case Direction.Left:
                        if (IsOutOfRange(x - i, y) || IsNotEmpty(x - i, y) || !IsNotTouching(x - i, y))
                            return false;
                        break;
                    case Direction.Right:
                        if (IsOutOfRange(x + i, y) || IsNotEmpty(x + i, y) || !IsNotTouching(x + i, y))
                            return false;
                        break;
                    default:
                        return false;
                }
            }
            return true;
        }

        private bool IsNotTouching(int x, int y)
        {
            return (IsOutOfRange(x + 1, y) || !IsOutOfRange(x + 1, y) && !IsNotEmpty(x + 1, y)) &&
                   (IsOutOfRange(x - 1, y) || !IsOutOfRange(x - 1, y) && !IsNotEmpty(x - 1, y)) &&
                   (IsOutOfRange(x, y + 1) || !IsOutOfRange(x, y + 1) && !IsNotEmpty(x, y + 1)) &&
                   (IsOutOfRange(x, y - 1) || !IsOutOfRange(x, y - 1) && !IsNotEmpty(x, y - 1));
        }

        private bool IsOutOfRange(int x, int y)
        {
            return x < 0 || x >= Ocean.GetLength(1) || y < 0 || y >= Ocean.GetLength(0);
        }

        private bool IsNotEmpty(int x, int y)
        {
            return Ocean[y, x].SquareStatus != SquareStatus.Empty;
        }
    }
}

