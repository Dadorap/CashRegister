﻿using CashRegisterSystem.AdminFolder.Display;
using CashRegisterSystem.CampaignFolder;
using CashRegisterSystem.ErrorMesg;
using CashRegisterSystem.MenuFolder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.AdminFolder.PromotionalFolder
{
    public class RemoveCampaign
    {
        public void DeleteCampaign()
        {
            string campPath = "../../../Files/Campaign.txt";
            var campList = new GetCampaign().GetCamp();
            ErrorMessage errId = new ErrorMessage("Invalid input.");
            ErrorMessage errFile = new ErrorMessage("File is empty/does not exist");
            DisplayCampaignRight displayCampaignRight = new DisplayCampaignRight();
            Promotional promotional = new Promotional();

            if (!File.Exists(campPath) || string.IsNullOrEmpty( File.ReadAllText(campPath)))
            {
                errFile.ErrorMsg();
                promotional.PromotionalMenue();
            }



            while (true)
            {
                Console.Clear();
                displayCampaignRight.DisplayCampaign(40);
                Console.SetCursorPosition(0, 0);
                bool idExist = false;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Remove a Campaign");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Enter campaign id: ");


                if (int.TryParse(Console.ReadLine(), out int inputId) && Math.Abs(inputId).ToString().Length == 4)
                {
                    foreach (var item in campList)
                    {
                        if (inputId == item.CampID)
                        {
                            idExist = true;
                            break;
                        }
                    }
                }

                if (idExist)
                {
                    string[] lines = File.ReadAllLines(campPath);
                    var filteredLines = lines.Where(line => !line.Contains(inputId.ToString())).ToArray();
                    File.WriteAllLines(campPath, filteredLines);
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"Campaign with ID number {inputId} has been removed");
                    Console.ResetColor();
                    Console.Write("Press any key to return to menu...");
                    Console.ReadKey();
                    promotional.PromotionalMenue();
                }

                if (!idExist)
                {
                    errId.ErrorMsg("back");
                }
            }
        }
    }
}
