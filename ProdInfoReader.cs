using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CSharpInlämningsuppgift
{
    public class ProdInfoReader
    {
        // Read and store procuts to Products class
        public static List<Products> ReadProducts()
        {
            List<Products> products = new List<Products>();
            string filePath = "D:\\02CSharpInl-mningsuppgift\\Files\\Producs.txt";


            foreach (string line in File.ReadLines(filePath))
            {
                string[] parts = line.Split(' ');

                int id = int.Parse(parts[0]);
                string name = parts[1];
                decimal price = decimal.Parse(parts[2]);
                string type = parts[3];

                Products product = new Products(id, name, price, type);
                products.Add(product);
            }

            return products;
        }

    }
}
