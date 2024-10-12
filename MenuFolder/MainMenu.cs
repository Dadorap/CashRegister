using CashRegisterSystem.AdminFolder;
using CashRegisterSystem.NewCutomer;
using CashRegisterSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegisterSystem.Product;

namespace CashRegisterSystem.MenuFolder
{
    public class MainMenu
    {
        public static void DisplayMenu()
        {
           NewCustomer newCustomer = new NewCustomer();
            Admin adminMenu = new Admin();
            Exit exit = new Exit();

            ProdInfoReader.ReadProducts();
            List<string> menu = new List<string>() { "New Customer", "Admin Tools", "Exit" };
            Menu.DisplayMenu(menu, newCustomer.CashRegister, adminMenu.AdminMenue, exit.Close);
        }
    }
}
