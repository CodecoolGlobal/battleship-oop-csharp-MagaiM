using Codecool.Battleship.UI;

namespace Codecool.Battleship.Players
{
    internal class ComputerPlayerHard : ComputerPlayerNormal
    {
        public ComputerPlayerHard(Display display) : base(display)
        {
        }

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
