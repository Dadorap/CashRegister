using CashRegister.ReceiptFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.AdminFolder.Receipt
{
    public class GetReceipt
    {
        public static void GetReceiptById()
        {
            while (true)
            {
                Console.Clear();
                try
                {
                    int horizantal = 40;
                    string path = "../../../Files/OrderNumber.txt";
                    List<string> list = new List<string>();

                    Console.SetCursorPosition(horizantal, 0);
                    Console.WriteLine("ReceiptNumber - Date");
                    // Read all order numbers from the file and add them to the list
                    foreach (var item in File.ReadAllLines(path))
                    {
                        list.Add(item);
                    }

                    // Display the order numbers on the console
                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.SetCursorPosition(horizantal, i + 1);
                        Console.WriteLine(list[i]);
                    }

                    // Ask for the receipt number
                    Console.SetCursorPosition(0, 0);
                    Console.Write("Enter receipt number (4 digits): ");

                    if (int.TryParse(Console.ReadLine(), out int idInput) && Math.Abs(idInput).ToString().Length == 4)
                    {
                        bool validDate = true;

                        // Loop for entering the date until it's valid
                        while (validDate)
                        {
                            Console.WriteLine("Enter date as so YYYYMMDD: ");


                            // Ensure the date is in the correct format (8 digits)
                            if (int.TryParse(Console.ReadLine(), out int receiptDate) && Math.Abs(receiptDate).ToString().Length == 8)
                            {
                                string receiptPath = $"../../../Files/Receipts/RECEIPT_{receiptDate}.txt";

                                ReadReceipt.DisplayReceipt(receiptPath, idInput);
                                validDate = false;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid date input. Try again.");
                                Console.ResetColor();
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid receipt number. Please enter a 4-digit number.");
                        Console.ResetColor();
                        Console.Write("Enter any key to return...");
                        Console.ReadKey();
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}


