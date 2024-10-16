using CashRegisterSystem.Interface;
using CashRegisterSystem.MenuFolder;
using CashRegisterSystem.Product;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.AdminFolder
{
    public class DisplayProductRight
    {
        public int XOffset { get; set; }
        public DisplayProductRight(int _xOffset)
        {
            XOffset = _xOffset;
        }
        public void DisplayProduct()
        {
            List<string> list = new List<string>();
            string filePath = "../../../Files/Products.txt";

            IMainMenu mainMenu = new MainMenu();
            try
            {
                if (File.Exists(filePath))
                {


                    Console.SetCursorPosition(XOffset, 0);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("PLUs- Product - Price");
                    // display list of all product
                    foreach (string item in File.ReadAllLines(filePath))
                    {
                        list.Add(item);
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (i % 2 == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        }
                        Console.SetCursorPosition(XOffset, i + 1);
                        Console.WriteLine(list[i]);
                    }

                    Console.ResetColor();
                }

            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.ForegroundColor= ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.Write("Press any key to return to menu...");
                Console.ReadKey();
                mainMenu.DisplayMenu();
            }

        }
    }
}
