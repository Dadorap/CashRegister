using CashRegisterSystem.AdminFolder.Display;
using CashRegisterSystem.ErrorMesg;
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
    public class PriceChange
    {
        public void AdjustPrice()
        {
            string path = "../../../Files/Products.txt";
            ErrorMessage errInput = new ErrorMessage("Invalid input. Try again.");
            ErrorMessage errFormat = new ErrorMessage("The input format is invalid.");
            ErrorMessage errOvFlow = new ErrorMessage("Value is too large.");
            DisplayProductRight displayProduct = new DisplayProductRight(40);
            EditProductMenu menu = new EditProductMenu();
            int minPrice = 0;
            int maxPrice = 100000;


            while (true)
            {

                try
                {
                    List<Products> newList = new List<Products>();
                    bool state = true;
                    while (state)
                    {


                        Console.Clear();
                        displayProduct.DisplayProduct();

                        // sets every thing below to the left side 
                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Product Price Change");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        string[] lines = File.ReadAllLines(path);
                        Console.Write("Enter PLU code: ");
                        string pluCode = Console.ReadLine();
                        // check to see if the plu exist and plu more then 2 digits
                        if (lines.Any(line => line.Contains(pluCode)) && pluCode.Length > 2)
                        {

                            // reads the file
                            foreach (var item in File.ReadLines(path))
                            {
                                string[] parts = item.Split(" ");
                                // checks for plu nr
                                if (parts[0] == pluCode)
                                {
                                    while (state)
                                    {
                                        Console.Write($"{parts[2]} Will be changed.\nEnter new product price(00,00): ");

                                        if (decimal.TryParse(Console.ReadLine(), out decimal newProdPrice) && newProdPrice > minPrice && newProdPrice < maxPrice)
                                        {


                                            parts[2] = newProdPrice.ToString();
                                            state = false;

                                        }

                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Invalid input try again...");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.WriteLine();
                                            continue;
                                        }
                                    }
                                }
                                int plu = Convert.ToInt32(parts[0]);
                                string prodName = parts[1];
                                decimal price = Math.Round(Convert.ToDecimal(parts[2]), 2, MidpointRounding.ToZero);
                                UnitType unitType = (UnitType)Enum.Parse(typeof(UnitType), parts[3]);


                                Products prodList = new Products(plu, prodName, price, unitType);
                                newList.Add(prodList);
                            }
                        }
                        else
                        {
                            errInput.ErrorMsg();
                            continue;

                        }

                    }

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Updated list:");
                    Console.ForegroundColor = ConsoleColor.Yellow;


                    // adds the new product list to the product.txt and print it to console
                    using (StreamWriter sw = new StreamWriter(path, append: false))
                    {
                        foreach (var item in newList)
                        {
                            Console.WriteLine(item.ToString());
                            sw.WriteLine(item.ToString());
                        }
                    }
                    Console.ResetColor();
                    Console.Write("Press any key to return to edit menu...");
                    Console.ReadKey();
                    menu.EditProductsMenu();

                }
                catch (OverflowException)
                {
                    errOvFlow.ErrorMsg();
                }
                catch (FormatException)
                {
                    errFormat.ErrorMsg();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
