using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipNew.Models.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string Image { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string BodyStyle { get; set; }
        public string Transmission { get; set; }
        public string ExteriorColor { get; set; }
        public string InteriorColor { get; set; }
        public int Mileage { get; set; }
        public string VIN { get; set; }
        public decimal Price { get; set; }
        public decimal MSRP { get; set; }
        public int Year { get; set; }
        public bool Sold { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool Featured { get; set; }
    }
}
