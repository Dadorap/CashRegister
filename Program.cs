using System;
using CashRegister.AdminFolder;
using CashRegister.NewCutomer;
using CashRegister.Product;

namespace CashRegister
{
    public class Program 
    {



        static void Main(string[] args)
        {
            List<string> menue = new List<string>() { "New Customer", "Admin Tools", "Exit" };
            Menu.menu(menue, NewCustomer.Kassa, Admin.AdminMenue, Exit.Close);
            ProdInfoReader.ReadProducts();

        }

    }

}


