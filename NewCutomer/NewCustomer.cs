using System;
using System.Collections.Generic;
using System.IO;

namespace _02CSharpInlämningsuppgift.NewCutomer
{
    public class NewCustomer
    {

        public static void Kassa()
        {
            List<Products> productsList = ProdInfoReader.ReadProducts();

            while (true)
            {

                Console.Clear();

                DateTime currentDateTime = DateTime.Now;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"KASSA");
                Console.ResetColor();
                // space between the two sides
                int horizantal = 30;
                int totalSum = 10;

                for (int y = 0; y < productsList.Count; y++)
                {
                    Console.SetCursorPosition(horizantal, y);
                    Console.WriteLine($"{productsList[y].Name} -> ProdID: {productsList[y].Id}");
                }

                Console.SetCursorPosition(0, 1);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("KVITTO   " + currentDateTime + $"\nTOTAL: {totalSum}");
                Console.ResetColor();
                Console.Write("Kommandon: \n<ProdID> <Amount>\n<Pay>\n");
                Console.Write("Kommando: ");
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "pay")
                {
                    
                    Console.WriteLine("thank come again!");
                }
                else
                {
                (int prodId, int amount) = InputSeparator.GetIdAmount(userInput);
                (string prodName, decimal prodPrice) = ProductLookup.GetProdInfo(prodId);
                }





                Console.ReadKey();
            }



        }


    }
}
