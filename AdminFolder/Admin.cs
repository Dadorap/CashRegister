using _02CSharpInlämningsuppgift.AdminFolder.PromotionalFolder;
using _02CSharpInlämningsuppgift.MenuFolder;
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


            List<string> menueList = new List<string>() { "Get Receipt","promotional prices", "Edit productList" };

            Menu.menu(menueList,  GetReceipt.GetReceiptById, Promotional.PromotionalMenue ,EditProduct.EditProducts);

            Console.ReadKey();
        }
    }
}
