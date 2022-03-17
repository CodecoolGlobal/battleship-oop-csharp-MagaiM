using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        //public void Run()
        //{
        //    bool isTrue = true;
        //    while (isTrue)
        //    {
        //        Board board = new Board();
        //        _display.PrintBoard(board.Ocean);
        //        isTrue = false;
        //        Console.ReadLine();
        //        if (Difficulty == AiDifficulty.None)
        //        {
        //            //
        //            //ove
        //        }else
        //        {
        //            // aimove(difficulty)
        //        }

        //    }
        //}

        public void Multiplayer()
        {
            var player1 = new Player(_input);
            var player2 = new Player(_input);
            _boardFactory.ManualPlacement(player1);
            _boardFactory.ManualPlacement(player2);
            while (true)
            {
                // _display.PrintMessage();
                _display.ClearConsole();
                _display.PrintMessage("Your Fleet");
                _display.PrintBoard(player1.Board.Ocean);
                _display.PrintMessage("Enemy Fleet");
                _display.PrintBoard(player2.Board.Ocean, true);
                _display.PrintMessage("Player 1 Shoot");
                player1.Shoot(_display, player2);
                if (!player2.IsAlive)
                {
                    _display.ClearConsole();
                    _display.PrintMessage("Player 1 Has Won the Game!" + Environment.NewLine + "Press Enter To Continue!");
                    _input.PressEnterToContinue();
                    break;
                }
                _display.ClearConsole();
                _display.PrintMessage("Press Enter to continue!");
                _input.PressEnterToContinue();

                _display.ClearConsole();
                _display.PrintMessage("Your Fleet");
                _display.PrintBoard(player2.Board.Ocean);
                _display.PrintMessage("Enemy Fleet");
                _display.PrintBoard(player1.Board.Ocean, true);
                _display.PrintMessage("Player 2 Shoot");
                player2.Shoot(_display, player1);
                if (!player1.IsAlive)
                {
                    _display.ClearConsole();
                    _display.PrintMessage("Player 2 Has Won the Game!" + Environment.NewLine + "Press Enter To Continue!");
                    _input.PressEnterToContinue();
                    break;
                }
                _display.ClearConsole();
                _display.PrintMessage("Press Enter to continue!");
                _input.PressEnterToContinue();
            }

        }

        public void Singleplayer()
        {
            var player1 = new Player(_input);
            ComputerPlayer player2;
            switch (Difficulty)
            {
                case AiDifficulty.Easy:
                    player2 = new ComputerPlayerEasy();
                    break;
                case AiDifficulty.Normal:
                    player2 = new ComputerPlayerNormal();
                    break;
                case AiDifficulty.Hard:
                    player2 = new ComputerPlayerHard();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            _boardFactory.ManualPlacement(player1);
            _boardFactory.RandomPlacement(player2);
            while (true)
            {
                // _display.PrintMessage();
                _display.ClearConsole();
                _display.PrintMessage("Your Fleet");
                _display.PrintBoard(player1.Board.Ocean);
                _display.PrintMessage("Enemy Fleet");
                _display.PrintBoard(player2.Board.Ocean, true);
                _display.PrintMessage("Player 1 Shoot");
                player1.Shoot(_display, player2);
                if (!player2.IsAlive)
                {
                    _display.ClearConsole();
                    _display.PrintMessage("Player 1 Has Won the Game!" + Environment.NewLine + "Press Enter To Continue!");
                    _input.PressEnterToContinue();
                    break;
                }
                player2.Shoot(_display, player1);
                if (!player1.IsAlive)
                {
                    _display.ClearConsole();
                    _display.PrintMessage("You lost the Game!" + Environment.NewLine + "Press Enter To Continue!");
                    _input.PressEnterToContinue();
                    break;
                }
            }
        }
    }
}