﻿using System;
using System.Collections.Generic;
using System.IO;
using CashRegisterSystem.ReceiptFolder;
using CashRegisterSystem.Product;
using CashRegisterSystem.MenuFolder;
using CashRegisterSystem.AdminFolder.Display;
using CashRegisterSystem.ErrorMesg;


namespace CashRegisterSystem.NewCutomer
{
    public class NewCustomer
    {

        public void CashRegister()
        {
            DisplayProductRight displayProduct = new DisplayProductRight(35);
            List<Products> productsList = ProdInfoReader.ReadProducts();
            CustormerShopping cart = new CustormerShopping();
            ErrorMessage errFormat = new ErrorMessage("The input format is invalid.");
            ErrorMessage errOvFlow = new ErrorMessage("Value is too large.");
            AddReceipt addReceipt = new AddReceipt();

            while (true)
            {
                try
                {
                    Console.Clear();

                    DateTime currentDateTime = DateTime.Now;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Cash Register");
                    Console.ResetColor();
                    // space between the two sides

                    decimal total = 0;

                    // this shows product name and its ID on the right side of the console
                    displayProduct.DisplayProduct();


                    Console.SetCursorPosition(0, 1);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("RECEIPT   " + currentDateTime);
                    List<Receipt> receipts = cart.GetReceipts();
                    foreach (Receipt receipt in receipts)
                    {
                        if (receipt.Amount == 0)
                        {
                            continue;
                        }
                        Console.WriteLine($"{receipt.ProdName} {receipt.Amount}{receipt.UnitType} * {receipt.ProdPrice} = {receipt.Amount * receipt.ProdPrice}");
                        total += receipt.TotalSum;
                    }
                    Console.WriteLine($"TOTAL: {total}");

                    Console.ResetColor();
                    Console.Write("Commands: \n<ProdID> <Amount>\n<Pay> <Cancel>\n");
                    Console.Write("Commands: ");
                    string userInput = Console.ReadLine().ToLower();

                    if (userInput == "pay" && receipts.Count > 0)
                    {
                        addReceipt.AddReceipts(receipts, total);
                        //Console.WriteLine("Thank you come again!");
                        //Console.WriteLine("press any key to return to the menue...");
                        //Console.ReadKey();
                        //Menu.menu();
                        break;
                    }else if (userInput == "cancel")
                    {
                        MainMenu.DisplayMenu();
                    }
                    else
                    {
                        cart.Addshopping(userInput);

                    }
                }
                catch (FormatException)
                {
                    errFormat.ErrorMsg();
                }
                catch (OverflowException)
                {
                    errOvFlow.ErrorMsg();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor= ConsoleColor.DarkRed;
                    Console.WriteLine(ex.Message);
                    Console.Write("Press any key to return...");
                    Console.ReadKey();
                }
            }

        }
    }
}
