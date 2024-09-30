using System;
using System.Security;
using _02CSharpInlämningsuppgift.AdminFolder;
using _02CSharpInlämningsuppgift.NewCutomer;


namespace _02CSharpInlämningsuppgift
{
    public class Menu 
    {
        public static void menu(List<string> menue, Action option1, Action option2, Action option3)
        {           
            int currentSelect = 0;

            while (true)
            {
                Console.Clear();
                Console.Write("Choose something from below and press Enter key to start \n");

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
                    currentSelect = (currentSelect < menue.Count - 1) ? currentSelect + 1 : 0;
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

