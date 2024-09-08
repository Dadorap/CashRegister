using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CSharpInlämningsuppgift.NewCutomer
{
    public class CustormerShopping
    {
        private List<Receipt> prodRec = new List<Receipt>();
        public void AddShooping(string userInput)
        {
            (string prodName, decimal prodPrice, int prodId, int amount) = GetProdInfo.getProdInfo(userInput);

            string productName = prodName;
            int prodAmount = amount;
            decimal price = prodPrice;
            decimal total = amount * prodPrice;

            Receipt receipt = new Receipt(productName, prodAmount, price, total);
            prodRec.Add(receipt);

        }

        public List<Receipt> GetReceipts()
        {
            return prodRec;
        }
    }
}
