using Codecool.Battleship.Enums;
using Codecool.Battleship.UI;

namespace Codecool.Battleship.Players
{
    internal class ComputerPlayerNormal : ComputerPlayer
    {
        public List<Square> PreviousHits = new List<Square>();

        public ComputerPlayerNormal(Display display) : base(display)
        {
        }

        protected override (int, int) GetCords(Player otherPlayer)
        {
            int x, y;
            Random random = new Random();
            if (PreviousHits.Count > 0 && PreviousHits[0].SquareStatus == SquareStatus.Sunk)
                PreviousHits.Clear();

            if (PreviousHits is not null && PreviousHits.Count == 1)
            {
                (x, y) = (PreviousHits[0].Position.x, PreviousHits[0].Position.y);
                while (true)
                {
                    int randomOption = random.Next(0, 4);
                    switch (randomOption)
                    {
                        case 0:
                            if (x + 1 < Board.Ocean.GetLength(1) &&
                                otherPlayer.Board.Ocean[y, x + 1].SquareStatus != SquareStatus.Missed &&
                                otherPlayer.Board.Ocean[y, x + 1].SquareStatus != SquareStatus.NexToSunk)
                            {
                                if (otherPlayer.Board.Ocean[y, x + 1].SquareStatus == SquareStatus.Ship)
                                    PreviousHits.Add(otherPlayer.Board.Ocean[y, x + 1]);
                                return (x + 1, y);
                            }

                            break;
                        case 1:
                            if (x - 1 >= 0 &&
                                otherPlayer.Board.Ocean[y, x - 1].SquareStatus != SquareStatus.Missed &&
                                otherPlayer.Board.Ocean[y, x - 1].SquareStatus != SquareStatus.NexToSunk)
                            {
                                if (otherPlayer.Board.Ocean[y, x - 1].SquareStatus == SquareStatus.Ship)
                                    PreviousHits.Add(otherPlayer.Board.Ocean[y, x - 1]);
                                return (x - 1, y);
                            }

                            break;
                        case 2:
                            if (y + 1 < otherPlayer.Board.Ocean.GetLength(1) &&
                                otherPlayer.Board.Ocean[y + 1, x].SquareStatus != SquareStatus.Missed &&
                                otherPlayer.Board.Ocean[y + 1, x].SquareStatus != SquareStatus.NexToSunk)
                            {
                                if (otherPlayer.Board.Ocean[y + 1, x].SquareStatus == SquareStatus.Ship)
                                    PreviousHits.Add(otherPlayer.Board.Ocean[y + 1, x]);
                                return (x, y + 1);
                            }

                            break;
                        case 3:                 //TODO Extract into method------------------------------------------
                            if (y - 1 >= 0 &&
                                otherPlayer.Board.Ocean[y - 1, x].SquareStatus != SquareStatus.Missed &&
                                otherPlayer.Board.Ocean[y - 1, x].SquareStatus != SquareStatus.NexToSunk)
                            {
                                if (otherPlayer.Board.Ocean[y - 1, x].SquareStatus == SquareStatus.Ship)
                                    PreviousHits.Add(otherPlayer.Board.Ocean[y - 1, x]);
                                return (x, y - 1);
                            }
                            break;
                    }
                }
            }
            else if (PreviousHits is not null && PreviousHits.Count > 1)
            {
                
                if (PreviousHits[0].Position.x == PreviousHits[1].Position.x)
                {
                    while (true)
                    {


                        PreviousHits = PreviousHits.OrderByDescending(s => s.Position.y).ToList();
                        int randomOption = random.Next(0, 2);
                        switch (randomOption)
                        {
                            case 0:                 //TODO Extract into method------------------------------------------
                                x = PreviousHits[PreviousHits.Count - 1].Position.x;
                                y = PreviousHits[PreviousHits.Count - 1].Position.y;
                                if (y - 1 >= 0 &&
                                    otherPlayer.Board.Ocean[y - 1, x].SquareStatus != SquareStatus.Missed &&
                                    otherPlayer.Board.Ocean[y - 1, x].SquareStatus != SquareStatus.NexToSunk)
                                {
                                    if (otherPlayer.Board.Ocean[y - 1, x].SquareStatus == SquareStatus.Ship)
                                        PreviousHits.Add(otherPlayer.Board.Ocean[y - 1, x]);
                                    return (x, y - 1);
                                }

                                break;
                            case 1:
                                x = PreviousHits[0].Position.x;
                                y = PreviousHits[0].Position.y;
                                if (y + 1 < otherPlayer.Board.Ocean.GetLength(1) &&
                                    otherPlayer.Board.Ocean[y + 1, x].SquareStatus != SquareStatus.Missed &&
                                    otherPlayer.Board.Ocean[y + 1, x].SquareStatus != SquareStatus.NexToSunk)
                                {
                                    if (otherPlayer.Board.Ocean[y + 1, x].SquareStatus == SquareStatus.Ship)
                                        PreviousHits.Add(otherPlayer.Board.Ocean[y + 1, x]);
                                    return (x, y + 1);
                                }

                                break;
                        }
                    }
                }
                else
                {
                    while (true)
                    {
                        PreviousHits = PreviousHits.OrderByDescending(s => s.Position.x).ToList();
                        int randomOption = random.Next(0, 2);
                        switch (randomOption)
                        {
                            case 0:
                                x = PreviousHits[PreviousHits.Count - 1].Position.x;
                                y = PreviousHits[PreviousHits.Count - 1].Position.y;
                                if (x - 1 >= 0 &&
                                    otherPlayer.Board.Ocean[y, x - 1].SquareStatus != SquareStatus.Missed &&
                                    otherPlayer.Board.Ocean[y, x - 1].SquareStatus != SquareStatus.NexToSunk)
                                {
                                    if (otherPlayer.Board.Ocean[y, x - 1].SquareStatus == SquareStatus.Ship)
                                        PreviousHits.Add(otherPlayer.Board.Ocean[y, x - 1]);
                                    return (x - 1, y);
                                }

                                break;
                            case 1:
                                x = PreviousHits[0].Position.x;
                                y = PreviousHits[0].Position.y;
                                if (x + 1 < otherPlayer.Board.Ocean.GetLength(1) &&
                                    otherPlayer.Board.Ocean[y, x + 1].SquareStatus != SquareStatus.Missed &&
                                    otherPlayer.Board.Ocean[y, x + 1].SquareStatus != SquareStatus.NexToSunk)
                                {
                                    if (otherPlayer.Board.Ocean[y, x + 1].SquareStatus == SquareStatus.Ship)
                                        PreviousHits.Add(otherPlayer.Board.Ocean[y, x + 1]);
                                    return (x + 1, y);
                                }

                                break;
                        }
                    }
                }
            }
            else
            {
                (x, y) = GetRandomCords(otherPlayer, random);
                if (otherPlayer.Board.Ocean[y, x].SquareStatus == SquareStatus.Ship)
                    PreviousHits.Add(otherPlayer.Board.Ocean[y, x]);
                return (x, y);
            }
        }

        protected virtual (int, int) GetRandomCords(Player otherPlayer, Random random)
        {
            int x;
            int y;
            (x, y) = (random.Next(otherPlayer.Board.Ocean.GetLength(1)),
                random.Next(otherPlayer.Board.Ocean.GetLength(0)));

            return (x, y);
        }
    }
}
