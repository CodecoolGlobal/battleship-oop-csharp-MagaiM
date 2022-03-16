using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Battleship
{
    internal class Player
    {
        public Board Board;
        public List<Ship> Ships = new();

        public Player()
        {
           Board = new Board();
        }

        public Player(Board board)
        {
           Board = board;
        }
    }
}
