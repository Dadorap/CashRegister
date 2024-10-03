using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Product
{
    public class ProdInfoReader
    {
        // Read and store procuts to Products class and return products list
        public static List<Products> ReadProducts()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            List<Products> products = new List<Products>();
            string filePath = "../../../Files/Products.txt";


            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(" ");

                int id = int.Parse(parts[0]);
                string name = parts[1];
                decimal price = decimal.Parse(parts[2]);
                string type = parts[3];

                Products product = new Products(id, name, price, type);
                products.Add(product);
            }
            Console.ResetColor();
            return products;
        }

    }
}
