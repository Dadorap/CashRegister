using CashRegisterSystem.AdminFolder.EditProductFolder;
using CashRegisterSystem.AdminFolder.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegisterSystem.MenuFolder;

namespace CashRegisterSystem.AdminFolder.PromotionalFolder
{
    public class Promotional
    {

        public void PromotionalMenue()
        {
            Console.Clear();
            Menu menu = new Menu();
            MainMenu mainMenu = new MainMenu();
            AddCampaign addCampaign = new AddCampaign();
            RemoveCampaign removeCampaign = new RemoveCampaign();    
            
            List<string> menueList = new List<string>() { "Add campaign", "Remove campaign", "Return to main menu" };

            menu.DisplayMenu(menueList, addCampaign.CreateCampaign, removeCampaign.DeleteCampaign, mainMenu.DisplayMenu);

            Console.ReadKey();
        }
    }
}
