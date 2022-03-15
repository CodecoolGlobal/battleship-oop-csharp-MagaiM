using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codecool.Battleship.UI;

namespace Codecool.Battleship
{
    internal class BoardFactory
    {
        public void manualPlacement(Board board, Player player)
        {
            //int x, int y, Direction direction, ShipType shipType
            var shipTypes = Enum.GetValues(typeof(ShipType));

            foreach (var shipType in shipTypes)
            {
                
                while (true)
                {

                }
            }
            //Ship ship = new Ship(x, y, direction, shipType);
            //display.PrintLine("Give a cord to put your ship");
            //(int x, int y) shipStartingCords = input.GetCords();
        }
    }
}
