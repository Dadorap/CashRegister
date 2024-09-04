﻿using System;
using System.Collections.Generic;

namespace _02CSharpInlämningsuppgift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>() { "New Customer", "Admin", "Close The Program" };
            DateTime currentDateTime = DateTime.Now;

            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{currentDateTime}\nKASSA");

            Console.ForegroundColor = originalColor;


            for (int i = 0; i < list.Count; i++)
            {
                int displyNum = i == 0 ? 1 : i == 1 ? 2 : 0;
                Console.WriteLine($"{displyNum}. {list[i]}");
            }
            Console.Write("Choose a number from the menue listed above: ");
            int userChoice;



            while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 0 || userChoice > 2)
            {
                Console.Write("Invalid input try again: ");
            }






            Console.ReadKey();
        }



    }
}
