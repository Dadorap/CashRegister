using CashRegister.AdminFolder.EditProductFolder;
using CashRegister.AdminFolder.Receipt;
using CashRegister.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.AdminFolder
{
    public class Admin
    {
        public static void AdminMenue()
        {

            Console.Clear();


            List<string> menueList = new List<string>() {"Add product", "Get Receipt", "Edit productList" };

            Menu.menu(menueList, AddProduct.AddPorductToList, GetReceipt.GetReceiptById, EditProduct.EditProducts);






            Console.ReadKey();
        }
    }
}
