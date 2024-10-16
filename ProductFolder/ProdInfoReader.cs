using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using CashRegisterSystem.Interface;
using CashRegisterSystem.ErrorMesg;
using CashRegisterSystem.MenuFolder;
using System.Diagnostics;
using System.Xml.Linq;

namespace CashRegisterSystem.Product
{
    public class ProdInfoReader
    {
        // Read and store procuts to Products class and return products list
        public List<Products> ReadProducts()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            var products = new List<Products>();
            string filePath = "../../../Files/Products.txt";


            if (File.Exists(filePath))
            {

                foreach (string line in File.ReadLines(filePath))
                {
                    // Split the line by spaces
                    string[] parts = line.Split(" ");

                    if (parts.Length == 4)
                    {
                        if (int.TryParse(parts[0], out int id) &&
                            decimal.TryParse(parts[2], out decimal price))
                        {
                            string name = parts[1];
                            UnitType unitType = (UnitType)Enum.Parse(typeof(UnitType), parts[3]);


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
            }

            Console.ResetColor();
            return products;
        }


    }
}
