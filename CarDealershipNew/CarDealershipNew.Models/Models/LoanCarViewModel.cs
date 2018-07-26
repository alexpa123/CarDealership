﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipNew.Models.Models
{
    public class LoanCarViewModel
    {
        public decimal LoanAmount { get; set; }
        public decimal Interest { get; set; }
        public int Term { get; set; }
        public decimal MonthlyPayment { get; set; }
        public Car Car { get; set; }
    }
}