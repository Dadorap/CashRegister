using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace _02CSharpInlämningsuppgift.NewCutomer
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
                        orderNum.Add(int.Parse(rLine));
                    }
                   
                    // gets the last order number from the list and add 1 to it
                    orderNumber = orderNum[orderNum.Count - 1] + 1;
                }
            }

            // writes order numer to text file OrderNumber
            using (StreamWriter sw = new StreamWriter(orderPath, append: true))
            {
                sw.WriteLine(orderNumber);
            }




            string line = $"__________________________";
            string header = $"\n\t\tMAXEISAND\n\tTel: 0611-525252\n\t\tHÄRNÖSAND\n-------------------------\n";
            string footer = $"-------------------------\nTOTAL:\t\t\t\t{total}\nORDER NUMBER:\t\t{orderNumber}\n{receiptDate}\t\t\t{time}\n-------------------------\nTHANKS FOR THE VISIT\n\tWELCOME BACK";
            // header
            using (StreamWriter myStream = new StreamWriter(receiptPath, append: true))
            {
                myStream.WriteLine(line);
                myStream.WriteLine($"{header}");
            }
            // body
            foreach (Receipt receipts in receipt)
            {
                using (StreamWriter myStream = new StreamWriter(receiptPath, append: true))
                {

                    myStream.WriteLine($"{receipts.ProdName}\n\t{receipts.Amount}{receipts.PordType}*{receipts.ProdPrice}\t\t\t{receipts.Amount * receipts.ProdPrice}");
                }

            }
            // footer
            using (StreamWriter myStream = new StreamWriter(receiptPath, append: true))
            {
                myStream.WriteLine($"{footer}");
                myStream.WriteLine(line);
            }
        }
    }
}


