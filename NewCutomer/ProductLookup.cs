using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CSharpInlämningsuppgift.NewCutomer
{
    public class ProductLookup
    {
        public static (string prodName, decimal prodPrice) GetProdInfo(int prodId)
        {
            List<Products> productsList = ProdInfoReader.ReadProducts();

            for (int i = 0; i < productsList.Count; i++)
            {
                if (productsList[i].Id == prodId)
                {
                    return (productsList[i].Name , productsList[i].Price);
                }
               
            }
            throw new Exception($"{prodId} was not found in the list");

        }
    }
}
