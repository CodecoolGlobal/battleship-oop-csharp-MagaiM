using System.Runtime.InteropServices;
using Codecool.Battleship.UI;

namespace Codecool.Battleship
{
    public class Battleship
    {
        private Display _display;
        private Input _input;
        private Game _game;

        public Battleship()
        {
            _display = new Display();
            _input = new Input();
            _game = new Game(_display, _input);
        }
        public static void Main()
        {
            new Battleship().MainMenu();
        }

        private void MainMenu()
        {
            //TODO: The Battleship class displays the main menu and allows the user to a start new game, display high scores, and exit.
            bool gameRunning = true;
            List<string> mainMenuOptions = new List<String>()
            {
                "Exit",
                "Start New Game",
                "Display High Scores"

            };
            List<string> gameModeOptions = new List<String>()
            {
                "Back",
                "Single Player",
                "Multi Player"
            };
            List<string> gameDifficultyOptions = new List<String>()
            {
                "Back",
                "Easy",
                "Medium",
                "Hard"
            };

            //bool valami = _input.IsAlpha('a');

            while (gameRunning)
            {
                _display.ShowMenu(mainMenuOptions);
                int option = _input.SelectMenu(mainMenuOptions.Count);
                switch (option)
                {
                    case 1:
                        //Start New Game
                        bool inGameMenu = true;
                        while (inGameMenu)
                        {
                            _display.ShowMenu(gameModeOptions);
                            option = _input.SelectMenu(gameModeOptions.Count);
                            switch (option)
                            {
                                case 1:
                                    //PVE
                                    _display.ShowMenu(gameDifficultyOptions);
                                    option = _input.SelectMenu(gameDifficultyOptions.Count);
                                    switch (option)
                                    {
                                        case 1:
                                            _game.Difficulty = AiDifficulty.Easy;

                                            //newGame.Run();// Run(SOLO / MULTI)
                                            inGameMenu = false;
                                            // restart ??? --- change dificulty inGameMenu = false??
                                            // quit to dekstop / main menu 
                                            //Easy PVE
                                            break;
                                        case 2:
                                            //Medium PVE
                                            _game.Run();
                                            //newGame.Run();// Run(SOLO / MULTI)
                                            inGameMenu = false;
                                            break;
                                        case 3:
                                            //Hard PVE
                                            //newGame.Run();// Run(SOLO / MULTI)
                                            inGameMenu = false;
                                            break;
                                    }

                                    break;
                                case 2:
                                    //PVP
                                    break;
                                case 0:
                                    //Back
                                    inGameMenu = false;
                                    break;
                            }
                        }
                        break;
                    case 2:
                        //Display High Scores
                        _display.PrintMessage("Not implemented yet! ¯\\_(ツ)_/¯");
                        Console.ReadLine();
                        break;
                    case 0:
                        //Exit
                        gameRunning = false;
                        break;
                }
            }
        }
    }
}