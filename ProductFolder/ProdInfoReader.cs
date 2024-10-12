using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CashRegisterSystem.Interface;

namespace CashRegisterSystem.Product
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
                // Split the line by spaces
                string[] parts = line.Split(" ");

                // Check if we have the expected number of parts (4 in this case: id, name, price, type)
                if (parts.Length == 4)
                {
                    // Try to parse the id
                    if (int.TryParse(parts[0], out int id) &&
                        decimal.TryParse(parts[2], out decimal price)) // Parse price
                    {
                        string name = parts[1];
                        UnitType unitType = (UnitType)Enum.Parse(typeof(UnitType), parts[3]);


                        // Create the product and add it to the list
                        Products product = new Products(id, name, price, unitType);
                        products.Add(product);
                    }
                    else
                    {
                        Console.WriteLine($"Error parsing line: {line}");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid format in line: {line}");
                }
            }

            Console.ResetColor();
            return products;
        }


    }
}
