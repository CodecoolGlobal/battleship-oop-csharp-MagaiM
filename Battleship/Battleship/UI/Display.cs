﻿using System.Text;

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
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"({i + 1}). {options[i]}");
            }
        }

        public void PrintBoard(Square[,] Ocean)
        {
            Console.Clear();
            PrintNums(Ocean.GetLength(0));
            Console.WriteLine();
            for (int y = 0; y < Ocean.GetLength(0); y++)
            {
                Console.Write(NumberToAlpha(y) + "  ");
                for (int x = 0; x < Ocean.GetLength(1); x++)
                {
                    Console.Write(Ocean[y, x].GetCharacter() + "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


        private string NumberToAlpha(long number, bool isLower = false)
        {
            string returnVal = "";
            char c = isLower ? 'a' : 'A';
            while (number >= 0)
            {
                returnVal = (char)(c + number % 26) + returnVal;
                number /= 26;
                number--;
            }
            return returnVal;
        }

        private void PrintNums(int BoardSize)
        {
            for (int i = 1; i <= BoardSize; i++)
            {
                if (i == 1)
                {
                    Console.Write("   ");
                }

                if (i < 10)
                {
                    Console.Write(i + "  ");
                }
                else
                {
                    Console.Write(i + " ");
                }
            }
        }

        public void PrintResult()
            {
            }
        }
}
