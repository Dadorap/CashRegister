using CashRegisterSystem.AdminFolder.Display;
using CashRegisterSystem.AdminFolder.EditProductFolder;
using CashRegisterSystem.Interface;
using CashRegisterSystem.MenuFolder;
using CashRegisterSystem.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.AdminFolder.EditProductFolder
{
    public class EditProductMenu 
    {
        public void EditProductsMenu()
        {
            Console.Clear();
            MainMenu mainMenu = new MainMenu();
            AddProduct addProduct = new AddProduct();
            NameChange nameChange = new NameChange();
            PriceChange priceChange = new PriceChange();
            DeleteProduct deleteProduct = new DeleteProduct();
            DisplayProdList displayProdList = new DisplayProdList();
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
                                addProduct.AddProductToList();
                                break;
                            case 2:
                                deleteProduct.DeleteProdcutFromList();                                
                                break;
                            case 3:
                                displayProdList.DisplayAllProd();
                                break;
                            case 4:
                                nameChange.ChangeProdName();
                                break;
                            case 5:
                                priceChange.AdjustPrice();                              
                                break;                            
                            case 6:
                                mainMenu.DisplayMenu();
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
