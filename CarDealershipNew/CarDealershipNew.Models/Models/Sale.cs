using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipNew.Models.Models
{
    public class Sale
    {
        public int SalesId { get; set; }

        [Required]
        public string UserName { get; set; }
        public int CarId { get; set; }
        public string PurchaseType { get; set; }
        public decimal PurchasePrice { get; set; }

        [Required]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
    }
}
