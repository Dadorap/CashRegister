using System;
using System.Security;
using CashRegisterSystem.AdminFolder;
using CashRegisterSystem.NewCutomer;


namespace CashRegisterSystem.MenuFolder
{
    public class Menu
    {
        public static void DisplayMenu(List<string> menue, Action option1, Action option2, Action option3)
        {
            int currentSelect = 0;

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("Choose an option and press Enter:\n");
                Console.ResetColor();
                for (int i = 0; i < menue.Count; i++)
                {
                    if (i == currentSelect)
                    {
                        if (menue[i].ToLower() == "exit")
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine($"-> {menue[i]}");
                    }
                    else
                    {
                        Console.WriteLine($">>{menue[i]}<<");
                    }
                    Console.ResetColor();
                }

                ConsoleKey keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    currentSelect = currentSelect > 0 ? currentSelect - 1 : menue.Count - 1;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    currentSelect = currentSelect < menue.Count - 1 ? currentSelect + 1 : 0;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (currentSelect)
                    {
                        case 0:
                            option1();
                            return;
                        case 1:
                            option2();
                            break;
                        case 2:
                            option3();
                            return;
                    }
                }
            }
        }
    }
}

