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

        private Square(int x, int y)
        {
            _squareStatus = SquareStatus.Empty;
            Position = (x, y);
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
