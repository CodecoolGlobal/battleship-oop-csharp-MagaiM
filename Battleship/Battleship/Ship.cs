using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Battleship
{
    internal class Ship
    {
        public List<Square> ShipLocation = new List<Square>();
        public ShipType ShipType { get; }
        public bool HasSunk
        {
            get
            {
                foreach (Square square in ShipLocation)
                {
                    if (square.SquareStatus == SquareStatus.Ship)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public Ship(ShipType shipType)
        {
            ShipType = shipType;
            for (int i = 0; i < (int)shipType; i++)
            {
                Square shipSquare = new Square(SquareStatus.Ship);
                ShipLocation.Add(shipSquare);
            }
        }

        public void SetSunk()
        {
            foreach (var square in ShipLocation)
            {
                square.SquareStatus = SquareStatus.Sunk;
            }
        }

        public Ship(int x, int y, Direction direction, ShipType shipType, Board board)
        {
            ShipType = shipType;
            for (int i = 0; i < (int)shipType; i++)
            {
                switch (direction)
                {
                    case Direction.Up:
                        ShipLocation.Add(board.Ocean[y - i, x]);
                        board.Ocean[y - i, x].SquareStatus = SquareStatus.Ship;
                        break;
                    case Direction.Down:
                        ShipLocation.Add(board.Ocean[y + i, x]);
                        board.Ocean[y + i, x].SquareStatus = SquareStatus.Ship;
                        break;
                    case Direction.Left:
                        ShipLocation.Add(board.Ocean[y, x - i]);
                        board.Ocean[y, x - i].SquareStatus = SquareStatus.Ship;
                        break;
                    case Direction.Right:
                        ShipLocation.Add(board.Ocean[y, x + i]);
                        board.Ocean[y, x + i].SquareStatus = SquareStatus.Ship;
                        break;
                }
            }
        }
    }
}
