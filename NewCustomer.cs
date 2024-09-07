using System;
using System.Collections.Generic;
using System.IO;

namespace _02CSharpInlämningsuppgift
{
    public class NewCustomer 
    {

    public static void Kassa()
        {
            Console.Clear();
            Program prodDisplay = new Program();
            List<Products> productsList = prodDisplay.ReadProducts();

            DateTime currentDateTime = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{currentDateTime}\nKASSA");
            Console.ResetColor();

            for (int y = 0; y < productsList.Count; y++)
            {
                Console.SetCursorPosition(30, y);
                Console.WriteLine($"{productsList[y].Name} -> ProdID: {productsList[y].Id}");
            }

            Console.SetCursorPosition(0, 2);
            Console.Write("Enter a code: ");
            string userInput = Console.ReadLine();




            Console.ReadKey();
        }


    }
}
