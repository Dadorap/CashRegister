﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegister.CampaignFolder
{
    public class GetCampaign
    {
        public static List<Campaign> GetCamp()
        {
            string path = "../../../Files/Campaign.txt";
            var campList = new List<Campaign>();

            foreach (var item in File.ReadAllLines(path))
            {
                string[] part = item.Split(" ");
                int prodPlu = int.Parse(part[0]);
                int prodDiscount = int.Parse(part[1]);
                DateOnly startDate = DateOnly.Parse(part[2]);
                DateOnly endDate = DateOnly.Parse(part[3]);

                Campaign campaign = new Campaign(prodPlu, prodDiscount, startDate, endDate);
                campList.Add(campaign);
            }

            return campList;
            
        }
    }
}
