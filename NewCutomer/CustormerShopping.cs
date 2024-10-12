using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegisterSystem.ReceiptFolder;
using CashRegisterSystem.Product;
using CashRegisterSystem.CampaignFolder;

namespace CashRegisterSystem.NewCutomer
{
    public class CustormerShopping
    {

        private List<Receipt> prodRec = new List<Receipt>();
        public void Addshopping(string userInput)
        {
            var prodList = new ProdInfoReader().ReadProducts();
            string campPath = "../../../Files/Campaign.txt";
            string[] userInputParts = userInput.Split(" ");
            CampaignChecker campaignChecker = new CampaignChecker();


            int prodId = int.Parse(userInputParts[0]);
            int prodAmount = int.Parse(userInputParts[1]);


            // gets the discount amount in Percent
            decimal priceDiscount = campaignChecker.GetPrice(prodId);



            for (int i = 0; i < prodList.Count; i++)
            {
                if (prodList[i].PLU == prodId)
                {
                    decimal price = prodList[i].ProdPrice * priceDiscount;
                    decimal total =Math.Round(prodAmount * price, 2);
                    Receipt receipt = new Receipt(prodList[i].ProdName, prodAmount, Math.Round(price,2), prodList[i].UnitType, total);
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
