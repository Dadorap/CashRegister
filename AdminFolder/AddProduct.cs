using _02CSharpInlämningsuppgift.Product;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _02CSharpInlämningsuppgift.AdminFolder
{
    public class AddProduct
    {
       public static void AddPorductToList()
        {
            string filePath = "../../../Files/Products.txt";

            Console.Write("Product code: ");
            string prodId = Console.ReadLine();
            Console.Write("Product name: ");
            string prodName = Console.ReadLine();
            Console.Write("Product price: ");
            string prodPrice = Console.ReadLine();
            Console.Write("Product type: ");
            string prodType = Console.ReadLine();

            string prodInfo = $"{prodId} {prodName} {prodPrice} {prodType}";
            
            using(StreamWriter mySteam = new StreamWriter(filePath, append: true))
            {
                mySteam.WriteLine(prodInfo);
            }

        }
    }
}
