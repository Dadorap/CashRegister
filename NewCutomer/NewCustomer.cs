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
            CustormerShopping cart = new CustormerShopping();

            while (true)
            {

                Console.Clear();

                DateTime currentDateTime = DateTime.Now;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"WELCOME");
                Console.ResetColor();
                // space between the two sides
                int horizantal = 30;
                decimal total = 0;

                for (int y = 0; y < productsList.Count; y++)
                {
                    Console.SetCursorPosition(horizantal, y);
                    Console.WriteLine($"{productsList[y].Name} -> ProdID: {productsList[y].Id}");
                }

                Console.SetCursorPosition(0, 1);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("RECEIPT   " + currentDateTime);
                List<Receipt> receipts = cart.GetReceipts();
                foreach (Receipt receipt in receipts)
                {
                    Console.WriteLine($"{receipt.ProdName} {receipt.Amount} * {receipt.ProdPrice} = {receipt.Amount * receipt.ProdPrice}");
                    total += receipt.TotalSum;
                }
                Console.WriteLine($"TOTAL: {total}");

                Console.ResetColor();
                Console.Write("Commands: \n<ProdID> <Amount>\n<Pay>\n");
                Console.Write("Commands: ");
                string userInput = Console.ReadLine().ToLower();

                if (userInput == "pay")
                {

                    Console.WriteLine("thank come again!");
                    break;
                }
                else
                {
                    cart.Addshopping(userInput);

                }
            }

        }
    }
}
