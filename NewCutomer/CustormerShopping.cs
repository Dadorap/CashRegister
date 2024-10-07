using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.ReceiptFolder;
using CashRegister.Product;
using CashRegister.CampaignFolder;

namespace CashRegister.NewCutomer
{
    public class CustormerShopping
    {
        private List<Receipt> prodRec = new List<Receipt>();

        public void Addshopping(string userInput)
        {
            List<Products> productsList = ProdInfoReader.ReadProducts();
            string campPath = "../../../Files/Campaign.txt";
            string[] userInputParts = userInput.Split(" ");


            int prodId = int.Parse(userInputParts[0]);
            int prodAmount = int.Parse(userInputParts[1]);


            // gets the discount amount in Percent
            decimal priceDiscount = CampaignChecker.GetPrice(prodId);



            for (int i = 0; i < productsList.Count; i++)
            {
                if (productsList[i].PLU == prodId)
                {
                    decimal price = productsList[i].ProdPrice * priceDiscount;
                    decimal total =Math.Round(prodAmount * price, 2);
                    Receipt receipt = new Receipt(productsList[i].ProdName, prodAmount, Math.Round(price,2), productsList[i].UnitType, total);
                    prodRec.Add(receipt);

                }
            }



        }

        public List<Receipt> GetReceipts()
        {
            return prodRec;
        }
    }
}
