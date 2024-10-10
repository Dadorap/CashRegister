using CashRegister.AdminFolder.Display;
using CashRegister.CampaignFolder;
using CashRegister.ErrorMesg;
using CashRegister.MenuFolder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.AdminFolder.PromotionalFolder
{
    public class RemoveCampaign
    {
        public void DeleteCampaign()
        {
            string campPath = "../../../Files/Campaign.txt";
            ErrorMessage errId = new ErrorMessage("Invalid input.");
            DisplayCampaignRight displayCampaignRight = new DisplayCampaignRight();
            var campList = GetCampaign.GetCamp();
           


            while (true)
            {
                Console.Clear();
                displayCampaignRight.DisplayCampaign(40);
                Console.SetCursorPosition(0, 0);
                bool idExist = false;

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
                    MainMenu.DisplayMenu();
                }

                if (!idExist)
                {
                    errId.ErrorMsg();
                }
            }
        }
    }
}
