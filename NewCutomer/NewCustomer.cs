using System;
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
            var prodList = new ProdInfoReader().ReadProducts();
            DisplayProductRight displayProduct = new DisplayProductRight(35);
            CustomerShopping cart = new CustomerShopping();
            ErrorMessage errFormat = new ErrorMessage("The input format is invalid.");
            ErrorMessage errOvFlow = new ErrorMessage("Value is too large.");
            ReceiptManager addReceipt = new ReceiptManager();
            MainMenu mainMenu = new MainMenu();

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
                    var receipts = cart.GetReceipt();
                    foreach (var receipt in receipts)
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
                        addReceipt.AddReceipt(receipts, total);
                        break;
                    }
                    else if (userInput == "cancel")
                    {
                        mainMenu.DisplayMenu();
                    }
                    else
                    {
                        cart.AddShopping(userInput);

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
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine(ex.Message);
                    Console.Write("Press any key to return...");
                    Console.ReadKey();
                }
            }

        }
    }
}
