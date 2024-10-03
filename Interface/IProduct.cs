using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.Interface
{
    public interface IProduct
    {
        public string ProdName { get; set; }
        public decimal ProdPrice { get; set; }
        public string UnitType { get; set; }



    }
}
