using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

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

            x = ConvertLetterToNum(shipStartingCords[0]);
            y = Convert.ToInt32(shipStartingCords.Substring(1));

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

        public int SelectMenu(List<string> options)
        {
            while (true)
            {
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());
                    if (input >= 0 && input < options.Count)
                        return input;
                }
                catch (Exception e)
                {
                }
            }
        }
    }
}
