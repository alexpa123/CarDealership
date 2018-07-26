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
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            IEnumerable<Car> featuredVehicles = _repo.GetFeaturedVehicles();
            return View(featuredVehicles.ToList());
        }

        [HttpGet]
        public ActionResult GetNewInventory()
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            VehicleSearch search = new VehicleSearch();
            return View(search);
        }

        [HttpGet]
        public ActionResult GetUsedInventory()
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            VehicleSearch search = new VehicleSearch();
            return View(search);
        }

        [HttpGet]
        public ActionResult Specials()
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            IEnumerable<Special> specials = _repo.Specials();
            return View(specials.ToList());
        }

        [HttpGet]
        public ActionResult Contact(string VIN)
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            Contact contact = new Contact();
            if (VIN == null)
            {
                contact.Message = "";
            }
            else
            {
                contact.Message = "I would like more information on VIN #" + VIN;
            }
            ViewBag.Message = "";
            return View(contact);
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Message has been sent.";
                _repo.AddContact(contact);
                Contact emptyContact = new Contact();
                return View(emptyContact);
            }
            else
            {
                ViewBag.Message = "Please correct submission.";
            }

            return View(contact);
        }

        [HttpGet]
        public ActionResult Calculate(int? id)
        {
            Loan loan = new Loan();
            return View(loan);
        }

        [Route("API/GetDetails/{carId}")]
        [AcceptVerbs("GET")]
        public ActionResult GetDetails(int id)
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            LoanCarViewModel model = new LoanCarViewModel();
            model.Car = new Car();
            model.Car = _repo.GetCarById(id);
            model.LoanAmount = model.Car.Price;
            model.Term = 5;
            model.Interest = 3.5m;
            return View(model);
        }
    }
}