using CashRegister.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CashRegister.AdminFolder.Display;
using CashRegister.ErrorMesg;
using CashRegister.MenuFolder;

namespace CashRegister.AdminFolder.EditProductFolder
{
    public class DeleteProduct
    {
        public void DeleteProdcutFromList()
        {
            string path = "../../../Files/Products.txt";
            var prodList = ProdInfoReader.ReadProducts();
            ErrorMessage errPlu = new ErrorMessage("The provided PLU was not found.\nPlease check the input and try again.");

            while (true)
            {
                Console.Clear();

                // displays product list to the right of console
                DisplayProductRight.DisplayProduct();


                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Add new product");
                Console.ForegroundColor = ConsoleColor.Blue;



                Console.Write("Enter PLU code: ");
                string pluCode = Console.ReadLine();
                if (int.TryParse(pluCode, out int plu) && Math.Abs(plu).ToString().Length == 3)
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
                        Console.Write("Press any key to return...");
                        Console.ReadKey();
                        MainMenu.DisplayMenu();
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



