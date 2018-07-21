using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipNew.Models.QueryObjects
{
    public class VehicleSearch
    {
        public string StringMakeModelOrYear { get; set; }
        public int? IntMakeModelOrYear { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public int? MinYear { get; set; }
        public int? MaxYear { get; set; }
    }
}
