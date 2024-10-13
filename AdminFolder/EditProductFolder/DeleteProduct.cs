using CashRegisterSystem.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CashRegisterSystem.AdminFolder.Display;
using CashRegisterSystem.ErrorMesg;
using CashRegisterSystem.MenuFolder;

namespace CashRegisterSystem.AdminFolder.EditProductFolder
{
    public class DeleteProduct
    {
        public void DeleteProdcutFromList()
        {
            string path = "../../../Files/Products.txt";
            var prodList = new ProdInfoReader().ReadProducts();
            EditProductMenu menu = new EditProductMenu();
            ErrorMessage errPlu = new ErrorMessage("The provided PLU was not found.\nPlease check the input and try again.");
            DisplayProductRight displayProduct = new DisplayProductRight(35);


            while (true)
            {
                Console.Clear();

                // displays product list to the right of console
                displayProduct.DisplayProduct();


                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("== Remove Product from the List ==");
                Console.ForegroundColor = ConsoleColor.Blue;



                Console.Write("Enter PLU code: ");
                string pluCode = Console.ReadLine();
                if (int.TryParse(pluCode, out int plu) && Math.Abs(plu).ToString().Length == 4)
                {
                    bool pluFound = false;
                    foreach (var p in prodList)
                    {
                        if (plu == p.PLU)
                        {
                            pluFound = true;
                            break;
                        }
                    }

                    if (!pluFound)
                    {
                        errPlu.ErrorMsg();
                    }


                    if (pluFound)
                    {

                        string[] lines = File.ReadAllLines(path);
                        var filteredLines = lines.Where(line => !line.Contains(pluCode)).ToArray();
                        File.WriteAllLines(path, filteredLines);
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Product with PLU code " + pluCode + " has been removed.");
                        Console.ResetColor();
                        Console.Write("Press any key to return to edit menu...");
                        Console.ReadKey();
                        menu.EditProductsMenu();
                    }

                }
                else
                {
                    errPlu.ErrorMsg();
                    continue;
                }

            }



        }

    }

}



