using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CashRegisterSystem
{
    class Exit
    {
        public void Close()
        {
            Console.Clear();
            Console.WriteLine("Press any key to close the console...");
            Console.ReadKey();
            Environment.Exit(0);
        }
    }
}
