using CashRegister.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CashRegister.ReceiptFolder
{
    public class Receipt : IProduct
    {
        public string ProdName { get; set; }
        public decimal ProdPrice { get; set; }
        public string UnitType { get; set; }
        public int Amount { get; set; }
        public decimal TotalSum { get; set; }


        public Receipt(string prodName, int amount, decimal prodPrice, string prodType, decimal totalSum)
        {
            ProdName = prodName;
            Amount = amount;
            ProdPrice = prodPrice;
            UnitType = prodType;
            TotalSum = totalSum;
        }

    }
}
