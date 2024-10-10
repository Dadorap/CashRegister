using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.ErrorMesg
{
    public class ErrorMessage
    {
        public string ErrMsg {  get; set; }

        public ErrorMessage(string _msg)
        {
            ErrMsg = _msg;
        }

        public void ErrorMsg()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ErrMsg);
            Console.ResetColor();
            Console.Write("Press any key to return...");
            Console.ReadKey();
        }
    }
}
