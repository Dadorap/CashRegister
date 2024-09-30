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
            Console.Write("Hello, choose a number from list below to start: ");
            int input = int.Parse(Console.ReadLine());

            bool choice = true;
            while (choice)
            {
                if (input >= 1 && input <= 10)
                {
                    choice = false;
                }
                else
                {
                Console.WriteLine("Please enter a number between 1-10");
                input = int.Parse(Console.ReadLine());
                }
            }

            switch (input)
            {
                case 1:
                    AddProduct.AddPorductToList();
                    break; 
                case 2:
                    GetReceipt.GetReceiptById();
                    break;                
                case 3:
                    DeleteProduct.DeleteProdcutFromList();
                    break;
                default:
                    break;
            }




            Console.ReadKey();
        }
    }
}

            //List<Products> productsList = ProdInfoReader.ReadProducts();

            //for (int y = 0; y < productsList.Count; y++)
            //{
            //    Console.WriteLine(productsList[y]);
            //}

            //Console.WriteLine("hello");