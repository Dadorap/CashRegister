using _02CSharpInlämningsuppgift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CSharpInlämningsuppgift.NewCutomer
{
    public class GetProdInfo
    {
        //a tuple that does string manipulation and also convert string to int and return id and amount as integer of user input
        public static (string prodName, decimal prodPrice, int prodId, int amount) getProdInfo(string userInput)
        {
            List<Products> productsList = ProdInfoReader.ReadProducts();
            string[] userParts = userInput.Split(" ");

            int prodId = int.Parse(userParts[0]);
            int amount = int.Parse(userParts[1]);
            string prodName = "";
            decimal prodPrice = 0;

            bool prodFound= false;

            for (int i = 0; i < productsList.Count; i++)
            {
                if (productsList[i].Id == prodId)
                {
                    prodName = productsList[i].Name;
                    prodPrice = productsList[i].Price;
                    prodFound = true;
                    break;
                }
            }
            if (!prodFound)
            {
                throw new Exception("product not found");
            }

            return (prodName, prodPrice, prodId, amount);
        }
    }
}



