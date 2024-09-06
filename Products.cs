using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CSharpInlämningsuppgift
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }

        public Products(int id, string name, decimal price, string type)
        {
            Id = id;
            Name = name;
            Price = price;
            Type = type;
        }







    }
}
