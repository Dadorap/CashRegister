using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace _02CSharpInlämningsuppgift.Product
{
    public class Products
    {
        public int PLU { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string UnitType { get; set; }

        public Products(int plu, string name, decimal price, string type)
        {
            PLU = plu;
            Name = name;
            Price = price;
            UnitType = type;
        }



        public override string ToString()
        {
            return $"{PLU} - {Name} - {Price}/{UnitType}";
        }

    }
}
