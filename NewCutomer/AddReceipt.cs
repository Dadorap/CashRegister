using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CSharpInlämningsuppgift.NewCutomer
{
    public class AddReceipt
    {
        public static void AddReceipts(List<Receipt> receipt, decimal total)
        {
            var receiptDate = DateTime.Now.ToShortDateString().Replace("-", "/");
            var time = DateTime.Now.ToString("HH:mm");
            var date = DateTime.Now.ToShortDateString().Split("-");
            var joinDate = string.Join("", date[0], date[1], date[2]);
            string line = $"__________________________";
            string header = $"\n\t\tMAXEISAND\n\tTel: 0611-525252\n\t\tHÄRNÖSAND\n-------------------------\n";
            string footer = $"-------------------------\nTOTAL:\t\t\t\t{total}\nORDER NUMBER:\t\t645\n{receiptDate}\t\t\t{time}\n-------------------------\nTHANKS FOR THE VISIT\n\tWELCOME BACK";

            // header
            using (StreamWriter myStream = new StreamWriter($"../../../Files/Receipts/RECEIPT_{joinDate}.txt", append: true))
            {
                myStream.WriteLine(line);
                myStream.WriteLine($"{header}");
            }

            // body
            foreach (Receipt receipts in receipt)
            {
                using (StreamWriter myStream = new StreamWriter($"../../../Files/Receipts/RECEIPT_{joinDate}.txt", append: true))
                {

                    myStream.WriteLine($"{receipts.ProdName}\n\t{receipts.Amount}*{receipts.ProdPrice}\t\t\t{receipts.Amount * receipts.ProdPrice}");
                }

            }
            // footer
            using (StreamWriter myStream = new StreamWriter($"../../../Files/Receipts/RECEIPT_{joinDate}.txt", append: true))
            {
                myStream.WriteLine($"{footer}");
                myStream.WriteLine(line);
            }
        }
    }
}


