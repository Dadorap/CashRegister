using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CashRegister.NewCutomer
{
    public class Receipt
    {
        public string ProdName { get; set; }
        public int Amount { get; set; }
        public decimal ProdPrice { get; set; }
        public string PordType { get; set; }
        public decimal TotalSum { get; set; }


        public Receipt(string prodName, int amount, decimal prodPrice, string prodType, decimal totalSum)
        {
            ProdName = prodName;
            Amount = amount;
            ProdPrice = prodPrice;
            PordType = prodType;
            TotalSum = totalSum;
        }

    }
}
