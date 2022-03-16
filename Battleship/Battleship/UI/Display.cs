using System.Text;

namespace Codecool.Battleship.UI
{
    internal class Display
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowMenu(List<string> options)
        {
            Console.Clear();
            //Console.OutputEncoding = Encoding.UTF8;
            for (int i = 1; i < options.Count; i++)
            {
                Console.WriteLine($"({i}). {options[i]}");
            }

            Console.WriteLine($"(0). {options[0]}" + Environment.NewLine);
        }

        public void ShowMenuWithoutBackOption(List<string> options)
        {
            Console.Clear();
            //Console.OutputEncoding = Encoding.UTF8;
            for (int i = 1; i < options.Count; i++)
            {
                Console.WriteLine($"({i + 1}). {options[i]}");
            }
        }

        public void PrintBoard(Square[,] Ocean)
        {
            foreach (var square in Ocean)
            {
                Console.Write((char)square.SquareStatus);
            }
        }

        public void PrintResult()
            {
            }
        }
}
