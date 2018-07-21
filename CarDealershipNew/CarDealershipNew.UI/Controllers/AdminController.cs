using CarDealershipNew.Data.Factory;
using CarDealershipNew.Data.Interfaces;
using CarDealershipNew.Models.EFModels;
using CarDealershipNew.Models.Models;
using CarDealershipNew.Models.QueryObjects;
using CarDealershipNew.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealershipNew.UI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        [Authorize(Roles = "admin")]
        public ActionResult Vehicles()
        {
            ViewBag.ReturnUrl = "/Admin/Vehicles";
            ICarDealerRepository _repo = RepositoryFactory.Create();
            VehicleSearch search = new VehicleSearch();
            return View(search);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Add()
        {
            IDropDown _dropdownrepo = RepositoryFactory.CreateDropDowns();
            CarViewModel carVM = new CarViewModel();
            carVM.Car = new Car();
            carVM.SetMakes(_dropdownrepo.MakeDropdown());
            carVM.SetModels(_dropdownrepo.ModelDropdown());
            carVM.SetTypes(_dropdownrepo.TypeDropdown());
            carVM.SetBodyStyles(_dropdownrepo.BodyStyleDropdown());
            carVM.SetTransmissions(_dropdownrepo.TransmissionDropdown());
            carVM.SetExteriorColor(_dropdownrepo.ExteriorColorDropdown());
            carVM.SetInteriorColor(_dropdownrepo.InteriorColorDropdown());
            return View(carVM);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Add(CarViewModel carVM)
        {
            if (ModelState.IsValid)
            {
                ICarDealerRepository _repo = RepositoryFactory.Create();
                _repo.AddVehicle(carVM.Car);
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            IDropDown _dropdownrepo = RepositoryFactory.CreateDropDowns();
            CarViewModel carVM = new CarViewModel();
            carVM.Car = _repo.GetCarById(id);
            carVM.SetMakes(_dropdownrepo.MakeDropdown());
            carVM.SetModels(_dropdownrepo.ModelDropdown());
            carVM.SetTypes(_dropdownrepo.TypeDropdown());
            carVM.SetBodyStyles(_dropdownrepo.BodyStyleDropdown());
            carVM.SetTransmissions(_dropdownrepo.TransmissionDropdown());
            carVM.SetExteriorColor(_dropdownrepo.ExteriorColorDropdown());
            carVM.SetInteriorColor(_dropdownrepo.InteriorColorDropdown());
            return View(carVM);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(Car car)
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            if (ModelState.IsValid)
            {
                _repo.EditVehicle(car);
            }
            return RedirectToAction("Vehicles", "Admin");
        }


        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginViewModel();

            return View(model);
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            // attempt to load the user with this password
            AppUser user = userManager.Find(model.UserName, model.Password);

            // user will be null if the password or user name is bad
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }
            else
            {
                // successful login, set up their cookies and send them on their way
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Login");
            }
        }

        [Authorize(Roles = "admin")]
        public ActionResult Users()
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            return View(_repo.GetUsers());
        }

        [Authorize(Roles = "admin")]
        public ActionResult AddUser()
        {
            IDropDown dropDownRepo = RepositoryFactory.CreateDropDowns();
            UserVM userVM = new UserVM();
            userVM.SetRoles(dropDownRepo.RolesDropDown());
            return View(userVM);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddUser(UserVM userVM)
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            if (ModelState.IsValid && (userVM.Password == userVM.ConfirmPassword))
            {
                _repo.AddUser(userVM);

            }
            return View(userVM);
        }

        [Authorize(Roles = "admin")]
        public ActionResult EditUser(string Id)
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            IDropDown dropDownRepo = RepositoryFactory.CreateDropDowns();
            UserVM editVM = new UserVM();
            AppUser user = _repo.GetUser(Id);
            editVM.LastName = user.LastName;
            editVM.FirstName = user.FirstName;
            editVM.Email = user.Email;
            editVM.Role = user.Role;
            editVM.Password = user.Password;
            editVM.SetRoles(dropDownRepo.RolesDropDown());
            return View(editVM);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditUser(UserVM editVM)
        {
            ICarDealerRepository _repo = RepositoryFactory.Create();
            if (ModelState.IsValid && (editVM.Password == editVM.ConfirmPassword))
            {
                _repo.EditUser(editVM);
                return RedirectToAction("Users", "Admin", null);
            }
            return View(editVM);

        }

        


    }
}