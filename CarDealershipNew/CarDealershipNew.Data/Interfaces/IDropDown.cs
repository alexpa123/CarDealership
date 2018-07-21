using CarDealershipNew.Models.EFModels;
using CarDealershipNew.Models.Models;
using CarDealershipNew.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipNew.Data.Interfaces
{
    public interface IDropDown
    {
        IEnumerable<MakeModel> MakeDropdown();
        IEnumerable<ModelModel> ModelDropdown();
        IEnumerable<TypeModel> TypeDropdown();
        IEnumerable<BodyStyleModel> BodyStyleDropdown();
        IEnumerable<TransmissionModel> TransmissionDropdown();
        IEnumerable<ExteriorColorModel> ExteriorColorDropdown();
        IEnumerable<InteriorColorModel> InteriorColorDropdown();
        IEnumerable<AppRole> RolesDropDown();
    }
}
