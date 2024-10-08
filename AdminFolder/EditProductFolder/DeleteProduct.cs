using CashRegister.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CashRegister.AdminFolder.Display;

namespace CashRegister.AdminFolder.EditProductFolder
{
    public class DeleteProduct
    {
        public static void DeleteProdcutFromList()
        {
            Console.Clear();
            string path = "../../../Files/Products.txt";
            // displays product list to the right of console
            DisplayProductRight.DisplayProduct();


            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("Enter PLU code: ");
            string pluCode = Console.ReadLine();
            string[] lines = File.ReadAllLines(path);
            var filteredLines = lines.Where(line => !line.Contains(pluCode)).ToArray();
            File.WriteAllLines(path, filteredLines);


            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Product with PLU code " + pluCode + " has been removed.");
            Console.ResetColor();
            Console.Write("Press any key to return...");
            Console.ReadKey();

            

        }

    }

}



