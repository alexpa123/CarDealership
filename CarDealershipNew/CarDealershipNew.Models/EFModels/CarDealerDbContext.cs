using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipNew.Models.EFModels
{
    public class CarDealerDbContext : IdentityDbContext<AppUser>
    {
        public CarDealerDbContext() : base("DefaultConnection")
        {
            
        }

        //public DbSet<AppUser> DBUsers { get; set; }
        public DbSet<AppRole> DBRoles { get; set; }
    }
}
