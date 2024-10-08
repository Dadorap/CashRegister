using CashRegister.CampaignFolder;
using CashRegister.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.AdminFolder.Display
{
    public class DisplayCampaignRight
    {
        public void DisplayCampaign(int xOffset)
        {
            List<string> campList = new List<string>();
            string path = "../../../Files/Campaign.txt";
            int horiz = xOffset;

            Console.SetCursorPosition(horiz, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PLUs-discount-startDate-endDate-ID");
            // display list of all product
            foreach (string item in File.ReadAllLines(path))
            {
                campList.Add(item);
            }

            for (int i = 0; i < campList.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                }
                Console.SetCursorPosition(horiz, i + 1);
                Console.WriteLine(campList[i]);
            }

            Console.ResetColor();
        }
    }
}
