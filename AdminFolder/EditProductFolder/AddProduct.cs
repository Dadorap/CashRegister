using CashRegisterSystem.AdminFolder.Display;
using CashRegisterSystem.ErrorMesg;
using CashRegisterSystem.Interface;
using CashRegisterSystem.MenuFolder;
using CashRegisterSystem.Product;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CashRegisterSystem.AdminFolder.EditProductFolder
{
    public class AddProduct
    {
        public void AddPorductToList()
        {
            string filePath = "../../../Files/Products.txt";
            var prodList = ProdInfoReader.ReadProducts();
            DisplayProductRight displayProduct = new DisplayProductRight(35);
            ErrorMessage errId = new ErrorMessage("Invalid input");
            EditProductMenu menu = new EditProductMenu();
            bool state = true;

            while (state)
            {
                try
                {



                    Console.Clear();
                    displayProduct.DisplayProduct();
                    Console.ForegroundColor = ConsoleColor.Green;
                    bool idExist = false;
                    bool isDigit = false;

                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Add new product");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("Enter the PLU code: ");
                    if (int.TryParse(Console.ReadLine(), out int prodId) && Math.Abs(prodId).ToString().Length == 3)
                    {
                        foreach (var item in prodList)
                        {
                            if (prodId == item.PLU)
                            {
                                Console.Clear();
                                idExist = true;
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.Write("ID already exists! Try again\nPress any key to return...");
                                Console.ReadKey();
                                break;
                            }
                        }

                        if (idExist)
                        {
                            continue;
                        }

                        if (!idExist)
                        {
                            Console.Write("Product name: ");
                            string prodName = Console.ReadLine();
                            if (int.TryParse(prodName, out int num) || prodName.Contains(" "))
                            {
                                isDigit = true;
                            }

                            if (isDigit)
                            {
                                continue;
                            }

                            if (!isDigit)
                            {
                                Console.Write("Product price: ");
                                var prodPrice = Math.Round(Math.Abs(Convert.ToDecimal(Console.ReadLine())), 2, MidpointRounding.ToZero);
                                Console.Write("Product unit type(pc/kg): ");
                                UnitType unitType = (UnitType)Enum.Parse(typeof(UnitType), Console.ReadLine().ToLower());


                                string prodInfo = $"{prodId} {prodName} {prodPrice} {unitType}";

                                using (StreamWriter mySteam = new StreamWriter(filePath, append: true))
                                {
                                    mySteam.WriteLine(prodInfo);
                                }
                            }
                        }
                        Console.ResetColor();
                        Console.Write("Press any key to return to edit menu...");
                        Console.ReadKey();
                        menu.EditProductsMenu();
                    }
                    else
                    {
                        errId.ErrorMsg();
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }

        }
    }
}
