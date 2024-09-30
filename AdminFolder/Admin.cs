using _02CSharpInlämningsuppgift.AdminFolder.EditProductFolder;
using _02CSharpInlämningsuppgift.AdminFolder.Receipt;
using _02CSharpInlämningsuppgift.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CSharpInlämningsuppgift.AdminFolder
{
    public class Admin
    {
        public static void AdminMenue()
        {

            Console.Clear();


            List<string> menueList = new List<string>() {"Add product", "Get Receipt", "Edit productList" };

            Menu.menu(menueList, AddProduct.AddPorductToList, GetReceipt.GetReceiptById, EditProduct.EditProducts);






            Console.ReadKey();
        }
    }
}
