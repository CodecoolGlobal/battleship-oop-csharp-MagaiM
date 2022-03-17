using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Battleship
{
    internal class ComputerPlayerHard : ComputerPlayer
    {
        protected override (int, int) GetCords(Player otherPlayer)
        {
            return base.GetCords(otherPlayer);
        }
    }
}
