using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Codecool.Battleship.UI;

namespace Codecool.Battleship
{
    internal class BoardFactory
    {
        private Display _display;
        private Input _input;
        private Array _shipTypes = Enum.GetValues(typeof(ShipType));

        public BoardFactory(Display display, Input input)
        {
            _display = display;
            _input = input;

        }

        public void ManualPlacement(Board board, Player player)
        {
            foreach (ShipType shipType in _shipTypes)
            {
                while (true)
                {
                    var options = Enum.GetNames(typeof(Direction)).ToList();
                    _display.PrintMessage("Give a cord to put your ship!");
                    (int x, int y) = _input.GetCords();
                    _display.ShowMenuWithoutBackOption(options);
                    Direction direction = _input.GetDirection(options.Count);
                    if (board.IsPlacementOk(x, y, direction, shipType))
                    {
                        player.Ships.Add(new Ship(x, y, direction, shipType, board));
                        break;
                    }
                }
            }
        }

        public void RandomPlacement(Board board, Player player)
        {
            Random random = new Random();
            foreach (ShipType shipType in _shipTypes)
            {
                while (true)
                {
                    (int x, int y) = (random.Next(board.Ocean.GetLength(1)),
                        random.Next(board.Ocean.GetLength(0)));
                    Array directions = Enum.GetValues(typeof(Direction));
                    Direction direction = (Direction)directions.GetValue(random.Next(directions.Length));
                    if (board.IsPlacementOk(x, y, direction, shipType))
                    {
                        player.Ships.Add(new Ship(x, y, direction, shipType, board));
                        break;
                    }
                }
            }
        }
    }
}
