using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Battleship
{
    internal class ComputerPlayerHard : ComputerPlayerNormal
    {
        protected override (int, int) GetRandomCords(Player otherPlayer, Random random)
        {
            int x, y;
            do
            {
                (x, y) = (random.Next(otherPlayer.Board.Ocean.GetLength(1)),
                    random.Next(otherPlayer.Board.Ocean.GetLength(0)));
            } while (!(x % 2 != y % 2));

            return (x, y);
        }
    }
}
