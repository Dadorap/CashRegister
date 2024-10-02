using CashRegister.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.AdminFolder
{
    internal class DisplayProdList
    {
        public static void DisplayAllProd()
        {
            Console.Clear();
            List<Products> productsList = ProdInfoReader.ReadProducts();

            foreach (Products product in productsList)
            {
                Console.WriteLine(product);
            }
            Console.Write("Press any key to return...");
            Console.ReadKey();
        }
    }
}
