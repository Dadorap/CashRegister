using CashRegister.AdminFolder;
using CashRegister.NewCutomer;
using CashRegister;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.Product;

namespace CashRegister.MenuFolder
{
    public class MainMenu
    {
        public static void DisplayMenu()
        {
            ProdInfoReader.ReadProducts();
            List<string> menu = new List<string>() { "New Customer", "Admin Tools", "Exit" };
            Menu.menu(menu, NewCustomer.Kassa, Admin.AdminMenue, Exit.Close);
        }
    }
}
