using CashRegisterSystem.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CashRegisterSystem.Product
{




    public class Products : IProduct
    {
        public string ProdName { get; set; }
        public decimal ProdPrice { get; set; }
        public UnitType UnitType { get; set; }
        public int PLU { get; set; }

        public Products(int plu, string name, decimal price, UnitType type)
        {
            PLU = plu;
            ProdName = name;
            ProdPrice = price;
            UnitType = type;
        }



        public override string ToString()
        {
            return $"{PLU} {ProdName} {ProdPrice} {UnitType}";
        }

    }
}
