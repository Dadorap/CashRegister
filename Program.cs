using System;
using _02CSharpInlämningsuppgift.AdminFolder;
using _02CSharpInlämningsuppgift.NewCutomer;
using _02CSharpInlämningsuppgift.Product;

namespace _02CSharpInlämningsuppgift
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


