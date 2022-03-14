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
        private ShipType _shipType;

        public Ship(ShipType shipType)
        {
            _shipType = shipType;
            for (int i = 0; i < (int)shipType; i++)
            {
                Square shipSquare = new Square(SquareStatus.Ship);
                ShipLocation.Add(shipSquare);
            }
        }

    }
}
