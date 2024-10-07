using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.ReceiptFolder
{
    public class AddReceipt
    {
        public static void AddReceipts(List<Receipt> receipt, decimal total)
        {
            int orderNumber = 4000;
            var receiptDate = DateTime.Now.ToShortDateString().Replace("-", "/");
            var time = DateTime.Now.ToString("HH:mm");
            var date = DateTime.Now.ToShortDateString().Split("-");
            var joinDate = string.Join("", date[0], date[1], date[2]);

            //paths
            string receiptPath = $"../../../Files/Receipts/RECEIPT_{joinDate}.txt";
            string orderPath = "../../../Files/OrderNumber.txt";



            // checks if the file exist if so read the file
            if (File.Exists(orderPath))
            {
                using (StreamReader readStream = new StreamReader(orderPath))
                {
                    string rLine;
                    List<int> orderNum = new List<int>();

                    while ((rLine = readStream.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(rLine))
                        {
                            orderNum.Add(int.Parse(rLine));
                        }
                    }

                    // if orderNum has entries, get the last order number and add 1 to it
                    if (orderNum.Count > 0)
                    {
                        orderNumber = orderNum[orderNum.Count - 1] + 1;
                    }
                }
            }

            // writes order numer to text file OrderNumber
            using (StreamWriter sw = new StreamWriter(orderPath, append: true))
            {
                sw.WriteLine(orderNumber);
            }




            string line = $"__________________________";
            string header = $"\n\tMAXEISAND\n     Tel:0611-525252\n\tHÄRNÖSAND\n-------------------------\nPRODUCTS\t PRICE\n";
            string footer = $"-------------------------\nTOTAL:\t\t{total}\nORDER NUMBER:\t{orderNumber}\n{receiptDate}\t{time}\n-------------------------\n    THANKS FOR THE VISIT\n\tWELCOME BACK";
            // Receipt Header
            using (StreamWriter myStream = new StreamWriter(receiptPath, append: true))
            {
                myStream.WriteLine(line);
                myStream.WriteLine($"{header}");
            }
            // Receipt Body
            foreach (Receipt receipts in receipt)
            {
                using (StreamWriter myStream = new StreamWriter(receiptPath, append: true))
                {

                    myStream.WriteLine($" {receipts.ProdName}\n  {receipts.Amount}{receipts.UnitType}*{receipts.ProdPrice}\t{receipts.Amount * receipts.ProdPrice}");
                }

            }
            // Receipt Footer
            using (StreamWriter myStream = new StreamWriter(receiptPath, append: true))
            {
                myStream.WriteLine($" {footer}");
                myStream.WriteLine(line);
            }

            ReadReceipt.DisplayReceipt(receiptPath, orderNumber);
        }
    }
}


