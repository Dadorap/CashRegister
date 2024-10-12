using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.CampaignFolder
{
    public class CampaignChecker
    {
        public decimal GetPrice(int plu)
        {
            var campList = GetCampaign.GetCamp();
            var date = DateOnly.Parse(DateTime.Now.ToString("yyyy-MM-dd"));

            foreach (var camp in campList)
            {
                if (plu == camp.ProdPLU)
                {
                    if (date >= camp.StartDate && date <= camp.EndDate)
                    {
                        decimal discount = 1 - (camp.Discount / 100m);
                        return discount;
                    }
                }
            }

            return 1;
        }

    }
}
