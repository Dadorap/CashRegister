﻿using CashRegister.AdminFolder.EditProductFolder;
using CashRegister.AdminFolder.Receipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashRegister.MenuFolder;

namespace CashRegister.AdminFolder.PromotionalFolder
{
    public class Promotional
    {

        public void PromotionalMenue()
        {
            Console.Clear();

            RemoveCampaign removeCampaign = new RemoveCampaign();
            
            List<string> menueList = new List<string>() { "Add campaign", "Remove campaign", "Return to main menu" };

            AddCampaign addCampaign = new AddCampaign();

            Menu.menu(menueList, addCampaign.CreateCampaign, removeCampaign.DeleteCampaign, MainMenu.DisplayMenu);

            Console.ReadKey();
        }
    }
}
