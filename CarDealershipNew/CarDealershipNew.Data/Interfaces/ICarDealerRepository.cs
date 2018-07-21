using CarDealershipNew.Data.Repos;
using CarDealershipNew.Models.EFModels;
using CarDealershipNew.Models.Models;
using CarDealershipNew.Models.QueryObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipNew.Data.Interfaces
{
    public interface ICarDealerRepository
    {
        IEnumerable<Car> GetFeaturedVehicles();
        IEnumerable<Special> Specials();
        IEnumerable<Car> GetInventory(string sproc, VehicleSearch search);
        Car GetCarById(int carId);
        void AddContact(Contact contact);
        void UpdateSale(Sale sale);
        void AddVehicle(Car car);
        void EditVehicle(Car car);
        void AddUser(UserVM userVM);
        void EditUser(UserVM userVM);
        IEnumerable<UserVM> GetUsers();
        AppUser GetUser(string Id);

    }
}
