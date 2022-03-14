using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Battleship
{
    internal class Board
    {
        private Square[,] _ocean;

        public bool IsPlacementOk { get; }

        public Board()
        {
            _ocean = new Square[10, 10];

            for (int y = 0; y < _ocean.GetLength(0); y++)
            {
                for (int x = 0; x < _ocean.GetLength(1); x++)
                {
                    _ocean[y, x].Position = (x, y);
                }
            }
        }
    }
}
