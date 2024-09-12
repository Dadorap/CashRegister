using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _02CSharpInlämningsuppgift.Product;

namespace _02CSharpInlämningsuppgift.NewCutomer
{
    public class CustormerShopping
    {
        private List<Receipt> prodRec = new List<Receipt>();

        public void Addshopping(string userInput)
        {
            List<Products> productsList = ProdInfoReader.ReadProducts();
            string[] userInputParts = userInput.Split(" ");

            int prodId = int.Parse(userInputParts[0]);
            int prodAmount = int.Parse(userInputParts[1]);

            bool prodFound = false;
            for (int i = 0; i < productsList.Count; i++)
            {
                if (productsList[i].Id == prodId)
                {
                    decimal total = prodAmount * productsList[i].Price;
                    Receipt receipt = new Receipt(productsList[i].Name, prodAmount, productsList[i].Price, total);
                    prodRec.Add(receipt);
                    prodFound = true;
                }
            }

            if (!prodFound)
            {
                throw new Exception("product not found");
            }

        }

        public List<Receipt> GetReceipts()
        {
            return prodRec;
        }
    }
}
