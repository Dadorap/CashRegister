using _02CSharpInlämningsuppgift.Product;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _02CSharpInlämningsuppgift.AdminFolder.EditProductFolder
{
    public class AddProduct
    {
        public static void AddPorductToList()
        {
            Console.Clear();
            DisplayProductRight.DisplayProduct();
            string filePath = "../../../Files/Products.txt";


            Console.SetCursorPosition(0,0);
            Console.Write("Enter the PLU code: ");
            string prodId = Console.ReadLine();
            Console.Write("Product name: ");
            string prodName = Console.ReadLine();
            Console.Write("Product price: ");
            string prodPrice = Console.ReadLine();
            Console.Write("Product unit type: ");
            string UnitType = Console.ReadLine();

            string prodInfo = $"{prodId} {prodName} {prodPrice} {UnitType}";

            using (StreamWriter mySteam = new StreamWriter(filePath, append: true))
            {
                mySteam.WriteLine(prodInfo);
            }

            Console.Write("Press any key to return...");
            Console.ReadKey();

        }
    }
}
