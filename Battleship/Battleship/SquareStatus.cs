using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Battleship
{
    enum SquareStatus
    {
        Empty = '~',
        Ship = 'X',
        Hit = 'H',
        Missed = 'M',
        Sunk = 'S'
    }
}
