using System;

namespace _02CSharpInlämningsuppgift
{
    internal class Program 
    {
        // Read and store procuts to Products class
        public List<Products> ReadProducts()
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


        static void Main(string[] args)
        {
            Menu.menu();

        }

    }

}


