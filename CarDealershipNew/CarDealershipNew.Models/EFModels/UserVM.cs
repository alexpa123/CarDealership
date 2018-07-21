using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CarDealershipNew.Models.EFModels
{
    public class UserVM
    {
        public string Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }

        public List<SelectListItem> VMRoles { get; set; }

        public UserVM()
        {
            VMRoles = new List<SelectListItem>();
        }

        public void SetRoles(IEnumerable<AppRole> roles)
        {
            foreach (var role in roles)
            {
                VMRoles.Add(
                    new SelectListItem()
                    {
                        Value = role.Name,
                        Text = role.Name
                    });
            }
        }
    }
}
