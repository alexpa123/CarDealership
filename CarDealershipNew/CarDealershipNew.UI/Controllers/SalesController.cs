using CarDealershipNew.Data.Factory;
using CarDealershipNew.Data.Interfaces;
using CarDealershipNew.Models.Models;
using CarDealershipNew.Models.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipNew.UI.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        [Authorize(Roles = "admin, sales")]
        public ActionResult Index()
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            VehicleSearch search = new VehicleSearch();
            return View(search);
        }

        [Route("Sales/Purchase/{id}")]
        [Authorize(Roles = "admin, sales")]
        [HttpGet]
        public ActionResult Purchase(int id)
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            purchaseViewModel.Car = _repo.GetCarById(id);
            return View(purchaseViewModel);

        }

        [Authorize(Roles = "admin, sales")]
        [HttpPost]
        public ActionResult Purchase(PurchaseViewModel model)
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            if (ModelState.IsValid)
            {
                Sale sale = new Sale();
                sale.CarId = model.Car.CarId;
                sale.UserName = "alexpa123";
                sale.PurchaseType = model.PurchaseType;
                sale.PurchasePrice = model.PurchasePrice;
                sale.Name = model.Name;
                sale.Phone = model.Phone;
                sale.Email = model.Email;
                sale.Street1 = model.Street1;
                sale.Street2 = model.Street2;
                sale.City = model.City;
                sale.State = model.State;
                sale.Zipcode = model.Zipcode;
                _repo.UpdateSale(sale);
                return RedirectToAction("Index", "Home", null);
            }
            PurchaseViewModel empty = new PurchaseViewModel();
            empty.Car = _repo.GetCarById(model.Car.CarId);
            return View(empty);

        }
    }
}