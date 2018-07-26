using CarDealershipNew.Data.Factory;
using CarDealershipNew.Data.Interfaces;
using CarDealershipNew.Models.Models;
using CarDealershipNew.Models.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealershipNew.UI.Controllers
{
    public class CarDealershipAPIController : ApiController
    {
        [Route("API/New")]
        [AcceptVerbs("POST")]
        public IHttpActionResult New(VehicleSearch search)
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            IEnumerable<Car> newInventory = _repo.GetInventory("NewVehicleSearch", search);
            return Ok(newInventory);

        }

        [Route("API/Used")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Used(VehicleSearch search)
        {

            ICarDealerRepository _repo = RepositoryFactory.Create();
            IEnumerable<Car> usedInventory = _repo.GetInventory("UsedVehicleSearch", search);
            return Ok(usedInventory);

        }

        [Route("API/Sales")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Sales(VehicleSearch search)
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();

            IEnumerable<Car> salesInventory = _repo.GetInventory("SelectAllUnsoldVehicles", search);
            return Ok(salesInventory);
        }

        [Route("API/Sales/{carId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult PurchaseVehicles(int carId)
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();

            Car car = _repo.GetCarById(carId);
            return Ok(car);
        }

        [Route("API/Admin")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Admin(VehicleSearch search)
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();

            IEnumerable<Car> salesInventory = _repo.GetInventory("AdminVehicleSearch", search);
            return Ok(salesInventory);
        }

        //[Route("API/GetDetails/{carId}")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult GetDetails(int carId)
        //{
        //    ICarDealerRepository _repo = RepositoryFactory.Create();
        //    LoanCarViewModel model = new LoanCarViewModel();
        //    model.Car = new Car();
        //    model.Car = _repo.GetCarById(carId);
        //    return Ok(model);
        //}
    }
}
