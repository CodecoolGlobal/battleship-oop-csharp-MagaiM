using Codecool.Battleship.Enums;
using Codecool.Battleship.Players;
using Codecool.Battleship.UI;

namespace Codecool.Battleship
{
    internal class Game
    {
        public AiDifficulty Difficulty { get; set; }
        private Display _display;
        private Input _input;
        private BoardFactory _boardFactory;

        public Game(Display display, Input input)
        {
            _display = display;
            _input = input;
            _boardFactory = new BoardFactory(display, input);

        }

        public void Multiplayer()
        {
            var player1 = new Player(_input, _display);
            var player2 = new Player(_input, _display);
            _boardFactory.ManualPlacement(player1);
            _boardFactory.ManualPlacement(player2);
            while (true)
            {
                PlayerShoot(player1, player2, 1);
                if (IsAlive(player2, 1)) break;
                PlayerShoot(player2, player1, 2);
                if (IsAlive(player1, 2)) break;
            }

        }

        public void Singleplayer()
        {
            var player1 = new Player(_input, _display);
            ComputerPlayer player2;
            switch (Difficulty)
            {
                case AiDifficulty.Easy:
                    player2 = new ComputerPlayerEasy(_display);
                    break;
                case AiDifficulty.Normal:
                    player2 = new ComputerPlayerNormal(_display);
                    break;
                case AiDifficulty.Hard:
                    player2 = new ComputerPlayerHard(_display);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            _boardFactory.ManualPlacement(player1);
            _boardFactory.RandomPlacement(player2);
            while (true)
            {
                PlayerShoot(player1, player2, 1);
                if (!player2.IsAlive)
                {
                    PressEnterMessages("You have Won the Game!" + Environment.NewLine + "Press Enter To Continue!");
                    break;
                }
                player2.Shoot(player1);
                if (!player1.IsAlive)
                {
                    PressEnterMessages("You lost the Game!" + Environment.NewLine + "Press Enter To Continue!");
                    break;
                }
            }
        }

        private void PlayerShoot(Player player1, Player player2, int CurrentPlayerNum)
        {
            DisplayBoards(player1, player2, $"Player {CurrentPlayerNum} Shoot!");
            player1.Shoot(player2);
        }

        private bool IsAlive(Player player, int CurrentPlayerNum)
        {
            if (!player.IsAlive)
            {
                PressEnterMessages($"Player {CurrentPlayerNum} Has Won the Game!" + Environment.NewLine + "Press Enter To Continue!");
                return true;
            }

            PressEnterMessages("Press Enter to continue!");
            return false;
        }

        private void PressEnterMessages(string message)
        {
            _display.ClearConsole();
            _display.PrintMessage(message);
            _input.PressEnterToContinue();
        }

        private void DisplayBoards(Player player2, Player player1, string message)
        {
            _display.ClearConsole();
            _display.PrintMessage("Your Fleet");
            _display.PrintBoard(player2.Board.Ocean);
            _display.PrintMessage("Enemy Fleet");
            _display.PrintBoard(player1.Board.Ocean, true);
            _display.PrintMessage(message);
        }
    }
}