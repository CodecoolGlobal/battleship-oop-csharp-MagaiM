using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Codecool.Battleship.UI;

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

        internal void Shoot(Display display, Input input, Player otherPlayer)
        {
            while (true)
            {

                display.PrintMessage("Give a cord to shoot at.");
                (int x, int y) = input.GetCords();
                if (ValidShot(x, y, otherPlayer.Board))
                {
                    if (otherPlayer.Board.Ocean[y, x].SquareStatus == SquareStatus.Ship)
                    {
                        otherPlayer.Board.Ocean[y, x].SquareStatus = SquareStatus.Hit;
                        Ship hitShip = GetHitShip(x, y, otherPlayer);
                        if (hitShip is not null && hitShip.HasSunk)
                        {
                            hitShip.SetSunk();
                        }
                    }
                    else if (otherPlayer.Board.Ocean[y, x].SquareStatus == SquareStatus.Empty)
                    {
                        otherPlayer.Board.Ocean[y, x].SquareStatus = SquareStatus.Missed;
                    }
                    break;
                }
            }
        }

        //private void SetSunkSquareStatus(int x, int y, Player otherPlayer)
        //{
        //    foreach (var ship in otherPlayer.Ships)
        //    {
        //        if (ship.HasSunk)
        //        {
        //            ship.SetSunk();
        //        }
        //    }
        //}

        private Ship GetHitShip(int x, int y, Player otherPlayer)
        {
            foreach (var ship in otherPlayer.Ships)
            {
                foreach (var square in ship.ShipLocation)
                {
                    if (square.Position == (x, y))
                        return ship;
                }
            }
            return null; // What to put here?------------------------------------------
        }
        
        private bool ValidShot(int x, int y, Board board)
        {
            return (x >= 0 || x < board.Ocean.GetLength(1) ||
                    y >= 0 || y < board.Ocean.GetLength(0)) &&
                   (board.Ocean[y, x].SquareStatus == SquareStatus.Empty ||
                    board.Ocean[y, x].SquareStatus == SquareStatus.Ship);
        }
    }
}
