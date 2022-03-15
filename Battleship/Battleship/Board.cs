﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Battleship
{
    internal class Board
    {
        public Square[,] Ocean { get; }

        public bool IsPlacementOk { get; }      //WTF is this?

        public Board()
        {
            Ocean = new Square[10, 10];

            for (int y = 0; y < Ocean.GetLength(0); y++)
            {
                for (int x = 0; x < Ocean.GetLength(1); x++)
                {
                    Ocean[y, x].Position = (x, y);
                }
            }
        }
    }
}
