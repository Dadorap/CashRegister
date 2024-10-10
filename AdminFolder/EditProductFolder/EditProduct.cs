using CashRegister.AdminFolder.Display;
using CashRegister.AdminFolder.EditProductFolder;
using CashRegister.Interface;
using CashRegister.MenuFolder;
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
        public void EditProducts()
        {
            Console.Clear();
            AddProduct addProduct = new AddProduct();
            DeleteProduct deleteProduct = new DeleteProduct();
            NameChange nameChange = new NameChange();
            PriceChange priceChange = new PriceChange();
            // menue list
            List<string> menueList = new List<string>() { "Add Product", "Remove product", "Display productList", "Change productName", "Change productPrice", "Return to main menu" };

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
                    if (int.TryParse(choice,out int result) && result > 0 && result <= 6) 
                    {
                        switch (result)
                        {
                            case 1:
                                addProduct.AddPorductToList();
                                break;
                            case 2:
                                deleteProduct.DeleteProdcutFromList();                                
                                break;
                            case 3:
                                DisplayProdList.DisplayAllProd();
                                break;
                            case 4:
                                nameChange.ChangeProdName();
                                break;
                            case 5:
                                priceChange.AdjustPrice();                              
                                break;                            
                            case 6:
                                MainMenu.DisplayMenu();
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
