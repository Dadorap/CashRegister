using CashRegister.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.AdminFolder.EditProductFolder
{
    public class ChangeName
    {
        public static void ChangeProdName()
        {
            Console.Clear();
            string path = "../../../Files/Products.txt";
            // displays product list to the right of console
            DisplayProductRight.DisplayProduct();

            Console.SetCursorPosition(0, 0);
            Console.Write("Enter PLU code: ");
            string pluCode = Console.ReadLine();


            List<Products> newList = new List<Products>();


            // reads the file
            foreach (var item in File.ReadLines(path))
            {
                string[] parts = item.Split(" ");
                // checks for plu nr
                if (parts[0] == pluCode)
                {
                    Console.Write($"{parts[1]} Will be changed.\nEnter new product name: ");
                    string newProdName = Console.ReadLine();
                    parts[1] = newProdName;
                }
                int plu = Convert.ToInt32(parts[0]);
                string prodName = parts[1];
                decimal price = Convert.ToDecimal(parts[2]);
                string unitType = parts[3];

                Products prodList = new Products(plu, prodName, price, unitType);
                newList.Add(prodList);
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("Updated list:");
            Console.ForegroundColor = ConsoleColor.Yellow;

            using (StreamWriter sw = new StreamWriter(path, append: false))
            {
                foreach (var item in newList)
                {                
                    Console.WriteLine(item.ToString());
                    sw.WriteLine(item.ToString());
                }
            }

            Console.ResetColor();

            Console.Write("Press any key to return...");
            Console.ReadKey();
        }
    }
}
