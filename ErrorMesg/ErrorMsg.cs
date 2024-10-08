using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.ErrorMesg
{
    public class ErrorMsg
    {
        public string ErrorMesg {  get; set; }

        public ErrorMsg(string _msg)
        {
            ErrorMesg = _msg;
        }

        public void ErrorMessage()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ErrorMesg);
            Console.ResetColor();
            Console.Write("Enter any key to return...");
            Console.ReadKey();
        }
    }
}
