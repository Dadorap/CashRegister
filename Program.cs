global using CashRegisterSystem.AdminFolder;
using System;
using CashRegisterSystem.MenuFolder;
using CashRegisterSystem.NewCutomer;
using CashRegisterSystem.Product;
using CashRegisterSystem.CampaignFolder;
using CashRegisterSystem.AdminFolder.Display;
using CashRegisterSystem.AdminFolder.PromotionalFolder;
using CashRegisterSystem.AdminFolder.EditProductFolder;
using CashRegisterSystem.AdminFolder.Receipt;



namespace CashRegisterSystem
{
    public class Program
    {



        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.DisplayMenu();
        }

    }

}


