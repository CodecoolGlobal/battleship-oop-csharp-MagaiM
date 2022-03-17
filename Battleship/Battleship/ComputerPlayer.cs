using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codecool.Battleship.UI;

namespace Codecool.Battleship
{
    internal class ComputerPlayer : Player
    {

        public ComputerPlayer(): base(new Board())
        {
        }
    }
}
