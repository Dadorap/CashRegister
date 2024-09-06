using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CSharpInlämningsuppgift
{
    public class Customer
    {
        public static void Kassa()
        {
            Console.Clear();
            DateTime currentDateTime = DateTime.Now;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{currentDateTime}\nKASSA");
            Console.ResetColor();
            
        }
    }
}
