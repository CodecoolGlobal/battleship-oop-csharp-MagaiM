using Codecool.Battleship.UI;

namespace Codecool.Battleship.Players
{
    internal class ComputerPlayerEasy : ComputerPlayer
    {
        public ComputerPlayerEasy(Display display) : base(display)
        {
        }

        protected override (int, int) GetCords(Player otherPlayer)
        {
            Random random = new Random();
            return (random.Next(Board.Ocean.GetLength(1)),
                        random.Next(Board.Ocean.GetLength(0)));
        }
    }
}
