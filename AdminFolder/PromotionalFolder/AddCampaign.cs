using CashRegisterSystem.AdminFolder.Display;
using CashRegisterSystem.CampaignFolder;
using CashRegisterSystem.Product;
using CashRegisterSystem.ErrorMesg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.AdminFolder.PromotionalFolder
{
    public class AddCampaign
    {
        public void CreateCampaign()
        {
            string campPath = "../../../Files/Campaign.txt";
            var campList = new GetCampaign().GetCamp();
            DisplayCampaignRight displayCampaignRight = new DisplayCampaignRight();
            DisplayProductRight displayProduct = new DisplayProductRight(36);
            Promotional promotional = new Promotional();
            var prodList = new ProdInfoReader().ReadProducts();
            ErrorMessage inputErr = new ErrorMessage("Invalid input. Please enter a 4-digit number.");
            ErrorMessage pluExistErr = new ErrorMessage("PLU does not exist! Try again");
            ErrorMessage formatErr = new ErrorMessage("Please use the correct format.");
            ErrorMessage disErr = new ErrorMessage("Please enter a number between 1-100.");
            ErrorMessage errFile = new ErrorMessage("Product file is empty/does not exist");


            bool fileExist = false;

            if (!File.Exists(campPath))
            {
                using (FileStream fs = File.Create(campPath))

                    fileExist = true;
            }

            if (prodList.Count > 0)
            {

                fileExist = true;
            }
            else
            {
                errFile.ErrorMsg();
                promotional.PromotionalMenue();
            }



            while (fileExist)
            {
                Console.Clear();
                displayCampaignRight.DisplayCampaign(60);
                displayProduct.DisplayProduct();
                try
                {


                    bool idExist = false;
                    bool pluExist = false;

                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Creat New Campaign");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Enter unique campaign ID (4-digit): ");
                    if (int.TryParse(Console.ReadLine(), out int campId) && Math.Abs(campId).ToString().Length == 4)
                    {
                        foreach (var camp in campList)
                        {
                            if (campId == camp.CampID)
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
                        Console.Write("Enter products plu: ");
                        if (int.TryParse(Console.ReadLine(), out int prodPlu) && Math.Abs(prodPlu).ToString().Length == 4)
                        {
                            foreach (var prod in prodList)
                            {
                                if (prodPlu == prod.PLU)
                                {
                                    pluExist = true;
                                    break;
                                }

                            }

                            if (!pluExist)
                            {
                                continue;
                            }


                            if (pluExist)
                            {
                                Console.Write("Enter disscount between (1-100): ");
                                if (int.TryParse(Console.ReadLine(), out int discount) && discount > 0 && discount <= 100)
                                {
                                    if (!idExist)
                                    {
                                        Console.WriteLine("Enter a starting date (yyyy-mm-dd): ");
                                        DateOnly startDate = DateOnly.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter a ending date (yyyy-mm-dd): ");
                                        DateOnly endDate = DateOnly.Parse(Console.ReadLine());

                                        string newCamp = $"{prodPlu} {discount} {startDate} {endDate} {campId}";
                                        using (StreamWriter sw = new StreamWriter(campPath, append: true))
                                        {
                                            sw.WriteLine(newCamp);
                                        }
                                        Console.Clear();
                                        Console.WriteLine("A new campaign has been added to the list.");
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.WriteLine(newCamp);
                                        Console.ResetColor();
                                        Console.Write("Press any key to return to campaigne menu...");
                                        Console.ReadKey();
                                        promotional.PromotionalMenue();
                                    }

                                }
                                else
                                {
                                    disErr.ErrorMsg();


                                }
                            }
                            else
                            {
                                pluExistErr.ErrorMsg();

                            }

                        }
                        else
                        {
                            inputErr.ErrorMsg();
                        }


                    }
                    else
                    {
                        inputErr.ErrorMsg();
                    }


                }
                catch (FormatException)
                {
                    formatErr.ErrorMsg("back");
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}
