using System;
using System.Collections.Generic;
using System.IO;

namespace _02CSharpInlämningsuppgift
{
    public class NewCustomer
    {
        protected void DisplayProducts(int x)
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

            for (int y = 0; y < products.Count; y++)
            {
                Console.SetCursorPosition(x, y); 
                Console.WriteLine(products[y]);
            }
        }

        public static void Kassa()
        {
            Console.Clear();
            NewCustomer prodDisplay = new NewCustomer();

            DateTime currentDateTime = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{currentDateTime}\nKASSA");
            Console.ResetColor();
            prodDisplay.DisplayProducts(30);

            Console.SetCursorPosition(0, 2);
            Console.Write("Enter a code: ");
            string userInput = Console.ReadLine();



            Console.ReadKey();
        }
    }
}
