using System;
using _02CSharpInlämningsuppgift.MenuFolder;
using CashRegister.AdminFolder;
using CashRegister.NewCutomer;
using CashRegister.Product;

namespace CashRegister
{
    public class Program 
    {



        static void Main(string[] args)
        {
            MainMenu.DisplayMenu();
            ProdInfoReader.ReadProducts();

        }

    }

}


