using CashRegisterSystem.ErrorMesg;
using CashRegisterSystem.ReceiptFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.AdminFolder.Receipt
{
    public class GetReceipt
    {
        public void GetReceiptById()
        {
            ErrorMessage recErr = new ErrorMessage("Invalid receipt number. \nPlease enter a 4-digit number.");
            ErrorMessage idErr = new ErrorMessage("Receipt number not found. \nPlease verify the number and try again.");
            FindReceipt readReceipt = new FindReceipt();
            while (true)
            {
                Console.Clear();
                try
                {
                    int horizantal = 40;
                    string path = "../../../Files/OrderNumber.txt";
                    List<string> list = new List<string>();
                    List<int> campId = new List<int>();


                    Console.SetCursorPosition(horizantal, 0);
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("ReceiptNumber - Date");

                    foreach (var item in File.ReadAllLines(path))
                    {
                        list.Add(item);
                    }
                    for (int i = 0; i < list.Count; i++)
                    {
                        string[] parts = list[i].Split(" ");
                        campId.Add(int.Parse(parts[0]));
                        Console.SetCursorPosition(horizantal, i + 1);
                        if (i % 2 == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                        }
                        Console.WriteLine(list[i]);
                    }
                    Console.ResetColor();
                    Console.SetCursorPosition(0, 0);

                    Console.Write("Enter receipt number (4 digits): ");

                    if (int.TryParse(Console.ReadLine(), out int idInput) && Math.Abs(idInput).ToString().Length == 4)
                    {
                        bool validDate = true;
                        bool idFound = false;

                        foreach (var id in campId)
                        {
                            if (id == idInput)
                            {
                                idFound = true;
                                break;
                            }
                        }
                        if (idFound)
                        {
                            while (validDate)
                            {
                                Console.WriteLine("Enter date as so YYYYMMDD: ");


                                if (int.TryParse(Console.ReadLine(), out int receiptDate) && Math.Abs(receiptDate).ToString().Length == 8)
                                {
                                    string receiptPath = $"../../../Files/Receipts/RECEIPT_{receiptDate}.txt";

                                    readReceipt.DisplayReceipt(receiptPath, idInput);
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

                        if (!idFound)
                        {
                            idErr.ErrorMsg();
                            continue;
                        }


                    }
                    else
                    {
                        recErr.ErrorMsg();
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


