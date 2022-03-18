using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Codecool.Battleship.Enums;

namespace Codecool.Battleship.UI
{
    internal class Input
    {
        public (int, int) GetCords()
        {
            int x;
            int y;
            string shipStartingCords = "";
            while (!IsValidCordFormat(shipStartingCords))
            {
                shipStartingCords = Console.ReadLine();
            }

            y = ConvertLetterToNum(shipStartingCords[0]);
            x = Convert.ToInt32(shipStartingCords.Substring(1)) - 1;

            return (x, y);
        }

        private int ConvertLetterToNum(char row)
        {
            return (int)Char.ToLower(row) - (int)'a';
        }

        private bool IsValidCordFormat(string cords)
        {

            return Regex.IsMatch(cords, @"^[a-zA-Z]{1}\d+$");
        }

        public int SelectMenu(int optionNum)
        {
            while (true)
            {
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    if (input >= 0 && input < optionNum)
                        return input;
                }
                catch (Exception)
                {
                }
            }
        }

        public int GetDirectionSelect(int optionNum)
        {
            while (true)
            {
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    if (input > 0 && input <= optionNum)
                        return input;
                }
                catch (Exception)
                {
                }
            }
        }

        public Direction GetDirection(int optionNum)
        {
            int option = GetDirectionSelect(optionNum);

            switch (option)
            {
                case 1:
                    return Direction.Up;
                case 2:
                    return Direction.Down;
                case 3:
                    return Direction.Left;
                case 4:
                    return Direction.Right;
                default:
                    return Direction.Up;
            }
        }

        internal void PressEnterToContinue()
        {
            Console.ReadLine();
        }
    }
}
