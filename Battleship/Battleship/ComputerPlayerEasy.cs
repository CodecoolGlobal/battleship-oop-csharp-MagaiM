using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Codecool.Battleship
{
    internal class ComputerPlayerEasy : ComputerPlayer
    {
        protected override (int, int) GetCords(Player otherPlayer)
        {
            Random random = new Random();
            return (random.Next(Board.Ocean.GetLength(1)),
                        random.Next(Board.Ocean.GetLength(0)));
        }
    }
}
