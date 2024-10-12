using CashRegisterSystem.MenuFolder;
using CashRegisterSystem.AdminFolder;
using CashRegisterSystem.NewCutomer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.ReceiptFolder
{
    public class FindReceipt
    {
        public void DisplayReceipt(string path, int orderNumber)
        {
            Console.Clear();
            MainMenu mainMenu = new MainMenu();
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
            catch (FileNotFoundException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Could not find file");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            Console.ResetColor();
            Console.Write("Press any key to return to menue...");
            Console.ReadKey();
            mainMenu.DisplayMenu();

        }
    }
}
