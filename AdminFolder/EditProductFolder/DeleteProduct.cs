using CashRegister.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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


            Console.Write("Enter PLU code: ");
            string pluCode = Console.ReadLine();
            string[] lines = File.ReadAllLines(path);
            var filteredLines = lines.Where(line => !line.Contains(pluCode)).ToArray();
            File.WriteAllLines(path, filteredLines);


            Console.Clear();
            Console.WriteLine("Product with PLU code " + pluCode + " has been removed or edited.");

            Console.Write("Press any key to return...");
            Console.ReadKey();

            

        }

    }

}



