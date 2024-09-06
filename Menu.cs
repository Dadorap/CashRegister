using System;
using System.Security;

namespace _02CSharpInlämningsuppgift
{
    public class Menu
    {
        public static void menu()
        {
            string[] list = { "New Customer", "Admin", "Exit" };
            int currentSelect = 0;

            while (true)
            {
                Console.Clear();
                Console.Write("Choose something from below and press Enter key to start \n");

                for (int i = 0; i < list.Length; i++)
                {
                    if (i == currentSelect)
                    {
                        if (currentSelect == 2)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        Console.WriteLine($"-> {list[i]}");
                    }
                    else
                    {
                        Console.WriteLine($">>{list[i]}<<");
                    }
                    Console.ResetColor();
                }

                ConsoleKey keyPressed = Console.ReadKey(true).Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    currentSelect = currentSelect > 0 ? currentSelect - 1 : list.Length - 1;
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    currentSelect = (currentSelect < list.Length - 1) ? currentSelect + 1 : 0;
                }
                else if (keyPressed == ConsoleKey.Enter)
                {
                    switch (currentSelect)
                    {
                        case 0:
                            NewCustomer.Kassa();
                            return;
                        case 1:
                            Console.WriteLine("Admin selected.");
                            break;
                        case 2:
                            Exit.Close();
                            return; 
                    }
                }
            }
        }
    }
}
