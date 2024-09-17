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
            var date = DateTime.Now.ToShortDateString().Split("-");
            var joinDate = string.Join("", date[0], date[1], date[2]);

            string x = $"\t\tKVITTO \n";
         

            foreach (Receipt receipts in receipt)
            {
                using (StreamWriter myStream = new StreamWriter($"../../../Files/Receipts/RECEIPT_{joinDate}.txt", append: true)){

                myStream.WriteLine($"{x} {receipts.ProdName} {receipts.Amount} * {receipts.ProdPrice} = {receipts.Amount * receipts.ProdPrice}");
                }
                
            }
        }
    }
}


//var country = "Sweden";
//var date = DateTime.Now.ToShortDateString();

//using (StreamWriter myStream =
//  new StreamWriter($"../../../Files/Report-{country}-{date}.txt", append: false))
//{
//    myStream.Write("Sweden Rocks!");
//}