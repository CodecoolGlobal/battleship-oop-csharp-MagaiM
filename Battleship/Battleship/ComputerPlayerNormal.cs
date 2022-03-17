using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.Battleship
{
    internal class ComputerPlayerNormal : ComputerPlayer
    {
        public List<Square> PreviousHits;
        protected override (int, int) GetCords()
        {
            int x, y;
            Random random = new Random();
            if (PreviousHits.Count > 0 && PreviousHits[0].SquareStatus == SquareStatus.Sunk)
                PreviousHits.Clear();
            if (PreviousHits.Count == 1)
            {
                (x, y) = (PreviousHits[0].Position.x, PreviousHits[0].Position.y);
                while (true)
                {
                    int randomOption = random.Next(0, 4);
                    switch (randomOption)
                    {
                        case 0:
                            if (x + 1 < Board.Ocean.GetLength(1) &&
                                Board.Ocean[y, x + 1].SquareStatus != SquareStatus.Missed &&
                                Board.Ocean[y, x + 1].SquareStatus != SquareStatus.NexToSunk)
                            {
                                if (Board.Ocean[y, x + 1].SquareStatus == SquareStatus.Ship)
                                    PreviousHits.Add(Board.Ocean[y, x + 1]);
                                return (x + 1, y);
                            }

                            break;
                        case 1:
                            if (x - 1 >= 0 &&
                                Board.Ocean[y, x - 1].SquareStatus != SquareStatus.Missed &&
                                Board.Ocean[y, x - 1].SquareStatus != SquareStatus.NexToSunk)
                            {
                                if (Board.Ocean[y, x - 1].SquareStatus == SquareStatus.Ship)
                                    PreviousHits.Add(Board.Ocean[y, x - 1]);
                                return (x - 1, y);
                            }

                            break;
                        case 2:
                            if (y + 1 < Board.Ocean.GetLength(1) &&
                                Board.Ocean[y + 1, x].SquareStatus != SquareStatus.Missed &&
                                Board.Ocean[y + 1, x].SquareStatus != SquareStatus.NexToSunk)
                            {
                                if (Board.Ocean[y + 1, x].SquareStatus == SquareStatus.Ship)
                                    PreviousHits.Add(Board.Ocean[y + 1, x]);
                                return (x, y + 1);
                            }

                            break;
                        case 3:
                            if (y - 1 >= 0 &&
                                Board.Ocean[y - 1, x].SquareStatus != SquareStatus.Missed &&
                                Board.Ocean[y - 1, x].SquareStatus != SquareStatus.NexToSunk)
                            {
                                if (Board.Ocean[y - 1, x].SquareStatus == SquareStatus.Ship)
                                    PreviousHits.Add(Board.Ocean[y - 1, x]);
                                return (x, y - 1);
                            }
                            break;
                    }
                }
            }
            else if (PreviousHits.Count > 1)
            {

            }


            (x, y) = (random.Next(Board.Ocean.GetLength(1)),
                random.Next(Board.Ocean.GetLength(0)));
            if (Board.Ocean[y, x].SquareStatus == SquareStatus.Ship)
                PreviousHits.Add(Board.Ocean[y, x]);
            return (x, y);
        }
    }
}
