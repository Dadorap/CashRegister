using CashRegister.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.AdminFolder
{
    public class DisplayProductRight
    {
        public static void DisplayProduct()
        {
            List<Products> productsList = ProdInfoReader.ReadProducts();
            List<string> list = new List<string>();
            string path = "../../../Files/Products.txt";
            int horiz = 35;

            Console.SetCursorPosition(horiz, 0);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("PLUs- Product - Price");
            // display list of all product
            foreach (string item in File.ReadAllLines(path))
            {
                list.Add(item);
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (i % 2 == 0)
                {             
                Console.ForegroundColor = ConsoleColor.Cyan;
                }
                else
                {
                    Console.ForegroundColor= ConsoleColor.DarkMagenta;
                }
                Console.SetCursorPosition(horiz, i + 1);
                Console.WriteLine(list[i]);
            }

            Console.ResetColor();
        }
    }
}
