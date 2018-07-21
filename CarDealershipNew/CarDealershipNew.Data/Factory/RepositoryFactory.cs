using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using CarDealershipNew.Data.Interfaces;
using CarDealershipNew.Data.Repos;

namespace CarDealershipNew.Data.Factory
{
    public class RepositoryFactory
    {
        public static ICarDealerRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Prod":
                    return new CarDealerRepo();
                default: throw new Exception("Mode value in app config is not valid.");
            }
        }

        public static IDropDown CreateDropDowns()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "Prod":
                    return new DropDownOptionsRepo();
                default: throw new Exception("Mode value in app config is not valid.");
            }
        }
    }
}
