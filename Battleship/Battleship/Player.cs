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

        public bool IsAlive
        {
            get
            {
                foreach (Ship ship in Ships)
                {
                    foreach (Square square in ship.ShipLocation)
                    {
                        if (square.SquareStatus == SquareStatus.Ship)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

        internal void Shoot()
        {
            throw new NotImplementedException();
        }
    }
}
