using CashRegister.AdminFolder.EditProductFolder;
using CashRegister.Interface;
using CashRegister.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.AdminFolder.EditProductFolder
{
    public class EditProduct 
    {
        public static void EditProducts()
        {
            Console.Clear();
            // menue list
            List<string> menueList = new List<string>() { "Add Product", "Display productList", "Change productName", "Change productPrice", "Remove product" };

            for (int i = 0; i < menueList.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"{i + 1}. {menueList[i]}");
                Console.ResetColor();

            }
            try
            {
                bool state = true;

                while (state)
                {
                Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Make a selection: ");
                    string choice = Console.ReadLine();
                   
                    Console.ResetColor();
                    if (int.TryParse(choice,out int result) && result > 0 && result < 6) 
                    {
                        switch (result)
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
                        state = false;
                    }
                    else
                    {
                        Console.ForegroundColor= ConsoleColor.Red;
                        Console.WriteLine("Invalid input try again..");
                        Console.ResetColor();
                        continue;
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
