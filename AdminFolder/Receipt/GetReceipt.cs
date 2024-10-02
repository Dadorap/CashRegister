using CashRegister.NewCutomer;
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
            Console.Clear();
            while (true)
            {
                try
                {
                    int horizantal = 30;
                    string path = "../../../Files/OrderNumber.txt";
                    List<string> list = new List<string>();

                    foreach (var item in File.ReadAllLines(path))
                    {
                        list.Add(item);

                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        Console.SetCursorPosition(horizantal, i);
                        Console.WriteLine(list[i]);

                    }




                    Console.SetCursorPosition(0, 0);
                    Console.Write("Enter recept number: ");
                    int idInput = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter date as so YYYYMMDD: ");
                    string receiptDate = Console.ReadLine();

                    string receiptPath = $"../../../Files/Receipts/RECEIPT_{receiptDate}.txt";


                    ReadReceipt.DisplayReceipt(receiptPath, idInput);
                }
                catch (Exception ex)
                {

                    Console.WriteLine("The date or the receipt number does not exist");
                }

            }
        }
    }
}