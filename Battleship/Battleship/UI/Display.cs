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

        public void PrintBoard()
        {
        }

        public void PrintResult()
        {
        }
    }
}
