using CashRegister.AdminFolder.PromotionalFolder;
using CashRegister.MenuFolder;
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

            EditProduct editProduct = new EditProduct();
            Promotional promotional = new Promotional();
            GetReceipt getReceipt = new GetReceipt();

            List<string> menueList = new List<string>() { "Get Receipt","promotional prices", "Edit productList" };

            Menu.menu(menueList, getReceipt.GetReceiptById, promotional.PromotionalMenue ,editProduct.EditProducts);

            Console.ReadKey();
        }
    }
}
