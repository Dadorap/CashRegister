using _02CSharpInlämningsuppgift.AdminFolder.EditProductFolder;
using _02CSharpInlämningsuppgift.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02CSharpInlämningsuppgift.AdminFolder.EditProductFolder
{
    public class EditProduct
    {
        public static void EditProducts()
        {
            try
            {
                bool state = true;
                while (state)
                {

                    Console.Clear();


                    // menue list
                    List<string> menueList = new List<string>() {"Add Product", "Display productList", "Change productName", "Change productPrice", "Remove product" };

                    for (int i = 0; i < menueList.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"{i+1}. {menueList[i]}");
                        Console.ResetColor();
                        

                    }

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Make a selection: ");
                    int choice = int.Parse(Console.ReadLine());
                    Console.ResetColor();

                    switch (choice)
                    {
                        case 1:
                            AddProduct.AddPorductToList();
                            break;
                        case 2:
                            DisplayProdList.DisplayAllProd();
                            break;
                        case 3:
                            ChangeName.ChangeProdName();
                            break;
                        case 4:
                            PriceChange.AdjustPrice();
                            break;
                        case 5:
                            DeleteProduct.DeleteProdcutFromList();
                            break;
                        default:
                            break;
                    }


                }
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine(ex.Message);
            }
        }
    }
}
