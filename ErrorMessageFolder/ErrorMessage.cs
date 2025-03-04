﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.ErrorMesg
{
    public class ErrorMessage
    {
        public string ErrMsg {  get; set; }

        public ErrorMessage(string _msg)
        {
            ErrMsg = _msg;
        }

        public void ErrorMsg(string msg = "menu")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ErrMsg);
            Console.ResetColor();
            Console.Write($"Press any key to return {msg}...");
            Console.ReadKey();
        }
    }
}
