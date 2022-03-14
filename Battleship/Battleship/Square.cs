using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Battleship
{
    internal class Square
    {
        public (int x, int y) Position { get; set; }

        private SquareStatus _squareStatus;

        public Square(int x, int y)
        {
            _squareStatus = SquareStatus.Empty;
            Position = (x, y);
        }

        public Square(SquareStatus squareStatus)
        {
            _squareStatus = squareStatus;
        }

        public Square()
        {
            _squareStatus = SquareStatus.Empty;
        }

        public void SetSquareStatus(SquareStatus squareStatus)
        {
            _squareStatus = squareStatus;
        }

        public char GetCharacter()
        {
            return (char)_squareStatus;
        }
    }
}
