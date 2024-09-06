using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CSharpInlämningsuppgift
{
    public class NewCustomer
    {
        protected void displayProducts (int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine("right side to disply product name and code");
        }
        public static void Kassa()
        {
            Console.Clear();
            NewCustomer prodDisply = new NewCustomer();

            DateTime currentDateTime = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{currentDateTime}\nKASSA");
            Console.ResetColor();

            prodDisply.displayProducts(30, 0);

            Console.ReadKey();
        }
    }
}
