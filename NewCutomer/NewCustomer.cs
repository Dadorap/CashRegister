﻿using System;
using System.Collections.Generic;
using System.IO;
using CashRegister.AdminFolder;
using CashRegister.Product;

namespace CashRegister.NewCutomer
{
    public class NewCustomer
    {

        public static void Kassa()
        {
            List<Products> productsList = ProdInfoReader.ReadProducts();
            CustormerShopping cart = new CustormerShopping();

            while (true)
            {
                try
                {
                    Console.Clear();

                    DateTime currentDateTime = DateTime.Now;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"WELCOME");
                    Console.ResetColor();
                    // space between the two sides

                    decimal total = 0;

                    // this shows product name and its ID on the right side of the console
                    DisplayProductRight.DisplayProduct();


                    Console.SetCursorPosition(0, 1);
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("RECEIPT   " + currentDateTime);
                    List<Receipt> receipts = cart.GetReceipts();
                    foreach (Receipt receipt in receipts)
                    {
                        Console.WriteLine($"{receipt.ProdName} {receipt.Amount}{receipt.PordType} * {receipt.ProdPrice} = {receipt.Amount * receipt.ProdPrice}");
                        total += receipt.TotalSum;
                    }
                    Console.WriteLine($"TOTAL: {total}");

                    Console.ResetColor();
                    Console.Write("Commands: \n<ProdID> <Amount>\n<Pay>\n");
                    Console.Write("Commands: ");
                    string userInput = Console.ReadLine().ToLower();

                    if (userInput == "pay")
                    {
                        AddReceipt.AddReceipts(receipts, total);
                        //Console.WriteLine("Thank you come again!");
                        //Console.WriteLine("press any key to return to the menue...");
                        //Console.ReadKey();
                        //Menu.menu();
                        break;
                    }
                    else
                    {
                        cart.Addshopping(userInput);

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
