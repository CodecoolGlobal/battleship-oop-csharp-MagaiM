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
            var player1 = new Player();
            var player2 = new Player();
            _boardFactory.ManualPlacement(player1);
            _boardFactory.ManualPlacement(player2);
            while(true)
            {
                // _display.PrintMessage();
                _display.PrintBoard(player2.Board.Ocean);
                player1.Shoot();
                if (!player2.IsAlive)
                {
                    _display.PrintMessage("Player1 Has Won the Game!" + Environment.NewLine + "Press Enter To Continue!");
                    _input.PressEnterToContinue();
                    break;
                }

                _display.PrintBoard(player1.Board.Ocean);
                player2.Shoot();
                if (!player1.IsAlive)
                {
                    _display.PrintMessage("Player2 Has Won the Game!" + Environment.NewLine + "Press Enter To Continue!");
                    _input.PressEnterToContinue();
                    break;
                }
            }

        }



        public void Run()
        {
            switch (Difficulty)
            {
                case AiDifficulty.None:
                    Multiplayer();
                    break;
                case AiDifficulty.Easy:
                    
                    break;
                case AiDifficulty.Medium:

                    break;
                case AiDifficulty.Hard:

                    break;
            }
        }
    }
}