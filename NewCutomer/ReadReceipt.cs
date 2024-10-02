﻿using CashRegister.AdminFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.NewCutomer
{
    public class ReadReceipt
    {
        public static void DisplayReceipt(string path, int orderNumber)
        {
            Console.Clear();
            string searchOrderNumber = "ORDER NUMBER:\t" + orderNumber;
            bool isWithinReceipt = false;
            string receiptContent = string.Empty;

            try
            {
                // Read the file line by line
                foreach (var line in File.ReadLines(path))
                {

                    if (line.Contains("__________________________"))
                    {
                        if (isWithinReceipt)
                        {
                            // Check if the previous receipt contains the order number
                            if (receiptContent.Contains(searchOrderNumber))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(receiptContent);
                                break;
                            }
                            receiptContent = string.Empty;
                        }
                        isWithinReceipt = true;
                    }

                    if (isWithinReceipt)
                    {
                        receiptContent += line + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            Console.ResetColor();
            Console.Write("Press any key to return to menue...");
            Console.ReadKey();
            List<string> menue = new List<string>() { "New Customer", "Admin Tools", "Exit" };
            Menu.menu(menue, NewCustomer.Kassa, Admin.AdminMenue, Exit.Close);
        }
    }
}
