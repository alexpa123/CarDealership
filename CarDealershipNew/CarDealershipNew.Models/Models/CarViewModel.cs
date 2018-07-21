using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace CarDealershipNew.Models.Models
{
    public class CarViewModel
    {
        public Car Car { get; set; }

        public List<SelectListItem> Makes { get; set; }
        public List<SelectListItem> Models { get; set; }
        public List<SelectListItem> Types { get; set; }
        public List<SelectListItem> BodyStyles { get; set; }
        public List<SelectListItem> Transmissions { get; set; }
        public List<SelectListItem> ExteriorColors { get; set; }
        public List<SelectListItem> InteriorColors { get; set; }

        public CarViewModel()
        {
            Car = new Car();
            Makes = new List<SelectListItem>();
            Models = new List<SelectListItem>();
            Types = new List<SelectListItem>();
            BodyStyles = new List<SelectListItem>();
            Transmissions = new List<SelectListItem>();
            ExteriorColors = new List<SelectListItem>();
            InteriorColors = new List<SelectListItem>();

        }

        public void SetMakes(IEnumerable<MakeModel> makes)
        {
            foreach (var make in makes)
            {
                Makes.Add(new SelectListItem()
                {
                    Value = make.Make,
                    Text = make.Make
                });
            }
        }

        public void SetModels(IEnumerable<ModelModel> models)
        {
            foreach (var model in models)
            {
                Models.Add(new SelectListItem()
                {
                    Value = model.Model,
                    Text = model.Model
                });
            }
        }

        public void SetTypes(IEnumerable<TypeModel> types)
        {
            foreach (var type in types)
            {
                Types.Add(new SelectListItem()
                {
                    Value = type.Type,
                    Text = type.Type
                });
            }
        }

        public void SetBodyStyles(IEnumerable<BodyStyleModel> bodyStyles)
        {
            foreach (var bodystyle in bodyStyles)
            {
                BodyStyles.Add(new SelectListItem()
                {
                    Value = bodystyle.BodyStyle,
                    Text = bodystyle.BodyStyle
                });
            }
        }

        public void SetTransmissions(IEnumerable<TransmissionModel> transmissions)
        {
            foreach (var transmission in transmissions)
            {
                Transmissions.Add(new SelectListItem()
                {
                    Value = transmission.Transmission,
                    Text = transmission.Transmission
                });
            }
        }

        public void SetExteriorColor(IEnumerable<ExteriorColorModel> exteriorColors)
        {
            foreach (var color in exteriorColors)
            {
                ExteriorColors.Add(new SelectListItem()
                {
                    Value = color.Color,
                    Text = color.Color
                });
            }
        }

        public void SetInteriorColor(IEnumerable<InteriorColorModel> interiorColors)
        {
            foreach (var color in interiorColors)
            {
                InteriorColors.Add(new SelectListItem()
                {
                    Value = color.Color,
                    Text = color.Color
                });
            }
        }

    }
}
