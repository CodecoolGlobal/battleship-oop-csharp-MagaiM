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
            var playerOne = new Player();
            var playerTwo = new Player();
            //--print
            //playerOne Placement()

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