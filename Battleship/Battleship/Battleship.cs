using Codecool.Battleship.UI;

namespace Codecool.Battleship
{
    public class Battleship
    {
        private static Display _display = new(); // WTF
        private static Input _input = new();     // WTF

        public static void Main()
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
                int option = _input.SelectMenu(mainMenuOptions);
                switch (option)
                {
                    case 1:
                        //Start New Game
                        bool inGameMenu = true;
                        while (inGameMenu)
                        {
                            _display.ShowMenu(gameModeOptions);
                            option = _input.SelectMenu(gameModeOptions);
                            switch (option)
                            {
                                case 1:
                                    //PVE
                                    _display.ShowMenu(gameDifficultyOptions);
                                    option = _input.SelectMenu(gameDifficultyOptions);
                                    switch (option)
                                    {
                                        case 1:
                                            //Easy PVE
                                            break;
                                        case 2:
                                            //Medium PVE
                                            break;
                                        case 3:
                                            //Hard PVE
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