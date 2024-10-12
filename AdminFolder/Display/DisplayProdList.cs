using CashRegisterSystem.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.AdminFolder.Display
{
    public class DisplayProdList
    {
        public void DisplayAllProd()
        {
            Console.Clear();
            List<Products> productsList = ProdInfoReader.ReadProducts();
            int i = 0;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Product list");
            Console.WriteLine("PLU-Name-Price-Unit");

            foreach (Products product in productsList)
            {
                if (i % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    i++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    i++;
                }

                Console.WriteLine(product);
            }
            Console.ResetColor();
            Console.Write("Press any key to return...");
        }
    }
}
