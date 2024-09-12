using _02CSharpInlämningsuppgift.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CSharpInlämningsuppgift.AdminFolder
{
    public class Admin
    {
        public static void Test()
        {
            Console.Clear();
            Console.WriteLine("You are in Admin class");



            List<Products> productsList = ProdInfoReader.ReadProducts();

            for (int y = 0; y < productsList.Count; y++)
            {
                Console.WriteLine(productsList[y]);
            }

            Console.WriteLine("hello");

            Console.ReadKey();
        }
    }
}
