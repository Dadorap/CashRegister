using CashRegisterSystem.AdminFolder.PromotionalFolder;
using CashRegisterSystem.MenuFolder;
using CashRegisterSystem.AdminFolder.EditProductFolder;
using CashRegisterSystem.AdminFolder.Receipt;
using CashRegisterSystem.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.AdminFolder
{
    public class Admin
    {
        public void AdminMenue()
        {

            Console.Clear();

            EditProductMenu editProduct = new EditProductMenu();
            Promotional promotional = new Promotional();
            GetReceipt getReceipt = new GetReceipt();

            List<string> menueList = new List<string>() { "Get Receipt","promotional prices", "Edit productList" };

            Menu.DisplayMenu(menueList, getReceipt.GetReceiptById, promotional.PromotionalMenue ,editProduct.EditProductsMenu);

            Console.ReadKey();
        }
    }
}
