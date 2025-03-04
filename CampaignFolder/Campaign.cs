﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.CampaignFolder
{
    public class Campaign
    {
        public int ProdPLU { get; set; }
        public decimal Discount { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public int CampID { get; set; }

        public Campaign(int _prodPLU, decimal _discount, DateOnly _startDate, DateOnly _endDate, int _campId)
        {
            ProdPLU = _prodPLU;
            Discount = _discount;
            StartDate = _startDate;
            EndDate = _endDate;
            CampID = _campId;
        }

    }
}
