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
        public void DisplayMenu()
        {
            Menu menu = new Menu();
            NewCustomer newCustomer = new NewCustomer();
            Admin adminMenu = new Admin();
            Exit exit = new Exit();
            List<string> menuList = new List<string>() { "New Customer", "Admin Tools", "Exit" };
            menu.DisplayMenu(menuList, newCustomer.CashRegister, adminMenu.AdminMenu, exit.Close);
        }
    }
}
