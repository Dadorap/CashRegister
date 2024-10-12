using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.Interface
{
    public enum UnitType
    {
        pc,
        kg
    }
    public interface IProduct
    {
        string ProdName { get; set; }
        decimal ProdPrice { get; set; }
        UnitType UnitType { get; set; }



    }
}
