﻿using CashRegisterSystem.AdminFolder.Display;
using CashRegisterSystem.ErrorMesg;
using CashRegisterSystem.Interface;
using CashRegisterSystem.MenuFolder;
using CashRegisterSystem.Product;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.AdminFolder.EditProductFolder
{
    public class NameChange
    {
        public void ChangeProdName()
        {
            string path = "../../../Files/Products.txt";
            ErrorMessage errPlu = new ErrorMessage("The provided PLU was not found.\nPlease check the input and try again.");
            DisplayProductRight displayProduct = new DisplayProductRight(35);
            MainMenu mainMenu = new MainMenu();
            ErrorMessage errFile = new ErrorMessage("Product file is empty/does not exist");

            if (!File.Exists(path) || string.IsNullOrEmpty(File.ReadAllText(path)))
            {
                errFile.ErrorMsg();
                mainMenu.DisplayMenu();

            }


            while (true)
            {


                try
                {
                    string[] lines = File.ReadAllLines(path);
                    List<Products> newList = new List<Products>();
                    bool state = true;


                    while (state)
                    {
                        Console.Clear();
                        displayProduct.DisplayProduct();
                        Console.SetCursorPosition(0, 0);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Product Name Change");
                        Console.ForegroundColor = ConsoleColor.Blue;
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
                                        Console.Write($"{parts[1]} Will be changed.\nEnter new product name: ");
                                        string newProdName = Console.ReadLine();
                                        if (newProdName.Length > 2)
                                        {
                                            parts[1] = newProdName;
                                            state = false;
                                            break;

                                        }
                                        else
                                        {
                                            continue;
                                        }
                                    }
                                }
                                int plu = Convert.ToInt32(parts[0]);
                                string prodName = parts[1].Replace(" ", "").Trim();
                                decimal price = Convert.ToDecimal(parts[2]);
                                UnitType unitType = (UnitType)Enum.Parse(typeof(UnitType), parts[3]);


                                Products prodList = new Products(plu, prodName, price, unitType);
                                newList.Add(prodList);
                            }
                        }
                        else
                        {
                            errPlu.ErrorMsg("back");

                            continue;

                        }

                    }

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Updated list:");


                    // adds the new product list to the product.txt and print it to console
                    using (StreamWriter sw = new StreamWriter(path, append: false))
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        foreach (var item in newList)
                        {
                            Console.WriteLine(item.ToString());
                            sw.WriteLine(item.ToString());
                        }

                    }


                    Console.ResetColor();
                    Console.Write("Press any key to return to menu...");
                    Console.ReadKey();
                    mainMenu.DisplayMenu();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
