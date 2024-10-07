using CashRegister.AdminFolder.EditProductFolder;
using CashRegister.AdminFolder.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.MenuFolder;

namespace CashRegister.AdminFolder.PromotionalFolder
{
    public class Promotional
    {

        public static void PromotionalMenue()
        {
            Console.Clear();


            List<string> menueList = new List<string>() { "Add campaign", "Remove campaign", "Return to main menu" };

            Menu.menu(menueList, AddProduct.AddPorductToList, GetReceipt.GetReceiptById, MainMenu.DisplayMenu);

            Console.ReadKey();
        }
    }
}
