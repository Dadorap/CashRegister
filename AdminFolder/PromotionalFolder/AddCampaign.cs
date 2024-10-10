using CashRegister.AdminFolder.Display;
using CashRegister.CampaignFolder;
using CashRegister.Product;
using CashRegister.ErrorMesg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.AdminFolder.PromotionalFolder
{
    public class AddCampaign
    {
        public void CreateCampaign()
        {
            string campPath = "../../../Files/Campaign.txt";
            DisplayCampaignRight displayCampaignRight = new DisplayCampaignRight();
            Promotional promotional = new Promotional();
            var campList = GetCampaign.GetCamp();
            var prodList = ProdInfoReader.ReadProducts();
            ErrorMessage campErr = new ErrorMessage("Invalid input. Please enter a 4-digit number.");
            ErrorMessage pluErr = new ErrorMessage("Invalid input. Please enter a 3-digit number.");
            ErrorMessage pluExistErr = new ErrorMessage("PLU does not exist! Try again");
            ErrorMessage formatErr = new ErrorMessage("Please use the correct format.");
            ErrorMessage disErr = new ErrorMessage("Please enter a number between 1-100.");


            while (true)
            {
                Console.Clear();
                displayCampaignRight.DisplayCampaign(60);
                DisplayProductRight.DisplayProduct();
                try
                {


                    bool idExist = false;
                    bool pluExist = false;

                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Creat New Campaign");
                    Console.ResetColor();
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
                        if (int.TryParse(Console.ReadLine(), out int prodPlu) && Math.Abs(prodPlu).ToString().Length == 3)
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
                            pluErr.ErrorMsg();
                        }


                    }
                    else
                    {
                        campErr.ErrorMsg();                       
                    }


                }
                catch (FormatException)
                {
                    formatErr.ErrorMsg();
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            }
        }
    }
}
