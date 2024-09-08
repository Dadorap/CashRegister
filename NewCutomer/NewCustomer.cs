using System;
using System.Collections.Generic;
using System.IO;

namespace _02CSharpInlämningsuppgift.NewCutomer
{
    public class NewCustomer
    {

        public static void Kassa()
        {
            Console.Clear();
            List<Products> productsList = ProdInfoReader.ReadProducts();

            DateTime currentDateTime = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{currentDateTime}\nKASSA");
            Console.ResetColor();
            // space between the two sides
            int horizantal = 30;

            for (int y = 0; y < productsList.Count; y++)
            {
                Console.SetCursorPosition(horizantal, y);
                Console.WriteLine($"{productsList[y].Name} -> ProdID: {productsList[y].Id}");
            }

            Console.SetCursorPosition(0, 2);
            Console.Write("Kommandon: \n<ProdID> <Amount>\n<Pay>\n");
            Console.Write("Kommando: ");
            string userInput = Console.ReadLine();

            (int prodId, int amount) = InputSeparator.GetIdAmount(userInput);
            (string prodName, decimal prodPrice) = ProductLookup.GetProdInfo(prodId);





            Console.ReadKey();
        }





    }
}
