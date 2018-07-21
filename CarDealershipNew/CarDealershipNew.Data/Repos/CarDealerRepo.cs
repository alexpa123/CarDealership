using CarDealershipNew.Data.Interfaces;
using CarDealershipNew.Models.EFModels;
using CarDealershipNew.Models.Helpers;
using CarDealershipNew.Models.Models;
using CarDealershipNew.Models.QueryObjects;
using CarDealershipNew.UI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipNew.Data.Repos
{
    public class CarDealerRepo : ICarDealerRepository
    {
        public IEnumerable<Car> GetFeaturedVehicles()
        {
            List<Car> featuredVehicles = new List<Car>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectFeaturedVehicles", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Car featuredVehicle = new Car();
                        featuredVehicle.Image = dr["Image"].ToString();
                        featuredVehicle.Make = dr["Make"].ToString();
                        featuredVehicle.Model = dr["Model"].ToString();
                        featuredVehicle.Price = (decimal)dr["Price"];
                        featuredVehicle.Year = (int)dr["Year"];
                        featuredVehicles.Add(featuredVehicle);
                    }
                }
            }
            return featuredVehicles;
        }

        public IEnumerable<Car> GetInventory(string sproc, VehicleSearch search)
        {

            List<Car> vehicles = new List<Car>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand(sproc, cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stringMakeModelOrYear", search.StringMakeModelOrYear);
                cmd.Parameters.AddWithValue("@minPrice", search.MinPrice);
                cmd.Parameters.AddWithValue("@maxPrice", search.MaxPrice);
                cmd.Parameters.AddWithValue("@minYear", search.MinYear);
                cmd.Parameters.AddWithValue("@maxYear", search.MaxYear);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Car vehicle = new Car();
                        vehicle.CarId = (int)dr["CarId"];
                        vehicle.Image = dr["Image"].ToString();
                        vehicle.Make = dr["Make"].ToString();
                        vehicle.Model = dr["Model"].ToString();
                        vehicle.BodyStyle = dr["BodyStyle"].ToString();
                        vehicle.Transmission = dr["Transmission"].ToString();
                        vehicle.ExteriorColor = dr["ExteriorColor"].ToString();
                        vehicle.InteriorColor = dr["InteriorColor"].ToString();
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.Price = (decimal)dr["Price"];
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.Year = (int)dr["Year"];
                        vehicles.Add(vehicle);
                    }
                }
            }
            return vehicles;
        }


        public IEnumerable<Special> Specials()
        {
            List<Special> specials = new List<Special>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("SelectSpecials", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Special special = new Special();
                        special.SpecialId = (int)dr["SpecialId"];
                        special.Title = dr["Title"].ToString();
                        special.Description = dr["Description"].ToString();
                        specials.Add(special);
                    }
                }
            }
            return specials;
        }

        public Car GetCarById(int carId)
        {
            Car vehicle = new Car();
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("GetCarById", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@carId", carId);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        vehicle.CarId = (int)dr["CarId"];
                        vehicle.Image = dr["Image"].ToString();
                        vehicle.Make = dr["Make"].ToString();
                        vehicle.Model = dr["Model"].ToString();
                        vehicle.BodyStyle = dr["BodyStyle"].ToString();
                        vehicle.Transmission = dr["Transmission"].ToString();
                        vehicle.ExteriorColor = dr["ExteriorColor"].ToString();
                        vehicle.InteriorColor = dr["InteriorColor"].ToString();
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.Price = (decimal)dr["Price"];
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.Year = (int)dr["Year"];
                        vehicle.Description = dr["Description"].ToString();

                    }
                }
            }
            return vehicle;

        }

        public IEnumerable<Car> GetSalesInventory(VehicleSearch search)
        {
            List<Car> vehicles = new List<Car>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("SalesVehicleSearch", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@stringMakeModelOrYear", search.StringMakeModelOrYear);
                cmd.Parameters.AddWithValue("@minPrice", search.MinPrice);
                cmd.Parameters.AddWithValue("@maxPrice", search.MaxPrice);
                cmd.Parameters.AddWithValue("@minYear", search.MinYear);
                cmd.Parameters.AddWithValue("@maxYear", search.MaxYear);

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Car vehicle = new Car();
                        vehicle.CarId = (int)dr["CarId"];
                        vehicle.Image = dr["Image"].ToString();
                        vehicle.Make = dr["Make"].ToString();
                        vehicle.Model = dr["Model"].ToString();
                        vehicle.BodyStyle = dr["BodyStyle"].ToString();
                        vehicle.Transmission = dr["Transmission"].ToString();
                        vehicle.ExteriorColor = dr["ExteriorColor"].ToString();
                        vehicle.InteriorColor = dr["InteriorColor"].ToString();
                        vehicle.Mileage = (int)dr["Mileage"];
                        vehicle.VIN = dr["VIN"].ToString();
                        vehicle.Price = (decimal)dr["Price"];
                        vehicle.MSRP = (decimal)dr["MSRP"];
                        vehicle.Year = (int)dr["Year"];
                        vehicles.Add(vehicle);
                    }
                }
            }
            return vehicles;
        }

        public void AddContact(Contact contact)
        {

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("AddContact", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", contact.Name);
                cmd.Parameters.AddWithValue("@email", contact.Email);
                cmd.Parameters.AddWithValue("@phone", contact.Phone);
                cmd.Parameters.AddWithValue("@message", contact.Message);

                cn.Open();
                cmd.ExecuteNonQuery();
            }

        }

        public void UpdateSale(Sale sale)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("UpdateSale", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@saleId", sale.SalesId);
                cmd.Parameters.AddWithValue("@userName", sale.UserName);
                cmd.Parameters.AddWithValue("@carId", sale.CarId);
                cmd.Parameters.AddWithValue("@purchaseType", sale.PurchaseType);
                cmd.Parameters.AddWithValue("@purchasePrice", sale.PurchasePrice);
                cmd.Parameters.AddWithValue("@name", sale.Name);
                cmd.Parameters.AddWithValue("@phone", sale.Phone);
                cmd.Parameters.AddWithValue("@email", sale.Email);
                cmd.Parameters.AddWithValue("@street1", sale.Street1);
                cmd.Parameters.AddWithValue("@street2", sale.Street2);
                cmd.Parameters.AddWithValue("@city", sale.City);
                cmd.Parameters.AddWithValue("@state", sale.State);
                cmd.Parameters.AddWithValue("@zipcode", sale.Zipcode);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddVehicle(Car car)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {

                SqlCommand cmd = new SqlCommand("AddVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@saleId", sale.SalesId);
                cmd.Parameters.AddWithValue("@make", car.Make);
                cmd.Parameters.AddWithValue("@model", car.Model);
                cmd.Parameters.AddWithValue("@type", car.Type);
                cmd.Parameters.AddWithValue("@bodyStyle", car.BodyStyle);
                cmd.Parameters.AddWithValue("@year", car.Year);
                cmd.Parameters.AddWithValue("@transmission", car.Transmission);
                cmd.Parameters.AddWithValue("@exteriorColor", car.ExteriorColor);
                cmd.Parameters.AddWithValue("@interiorColor", car.InteriorColor);
                cmd.Parameters.AddWithValue("@mileage", car.Mileage);
                cmd.Parameters.AddWithValue("@vin", car.VIN);
                cmd.Parameters.AddWithValue("@msrp", car.MSRP);
                cmd.Parameters.AddWithValue("@price", car.Price);
                cmd.Parameters.AddWithValue("@description", car.Description);
                cmd.Parameters.AddWithValue("@featured", car.Featured);
                cmd.Parameters.AddWithValue("@sold", car.Sold);
                cmd.Parameters.AddWithValue("@image", car.Image);


                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditVehicle(Car car)
        {

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("EditVehicle", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@carId", car.CarId);
                cmd.Parameters.AddWithValue("@make", car.Make);
                cmd.Parameters.AddWithValue("@model", car.Model);
                cmd.Parameters.AddWithValue("@type", car.Type);
                cmd.Parameters.AddWithValue("@bodyStyle", car.BodyStyle);
                cmd.Parameters.AddWithValue("@year", car.Year);
                cmd.Parameters.AddWithValue("@transmission", car.Transmission);
                cmd.Parameters.AddWithValue("@exteriorColor", car.ExteriorColor);
                cmd.Parameters.AddWithValue("@interiorColor", car.InteriorColor);
                cmd.Parameters.AddWithValue("@mileage", car.Mileage);
                cmd.Parameters.AddWithValue("@vin", car.VIN);
                cmd.Parameters.AddWithValue("@msrp", car.MSRP);
                cmd.Parameters.AddWithValue("@price", car.Price);
                cmd.Parameters.AddWithValue("@description", car.Description);
                cmd.Parameters.AddWithValue("@featured", car.Featured);
                cmd.Parameters.AddWithValue("@sold", car.Sold);
                cmd.Parameters.AddWithValue("@image", car.Image);

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddUser(UserVM user)
        {
            CarDealerDbContext context = new CarDealerDbContext();
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            var appuser = new AppUser();
            appuser.FirstName = user.FirstName;
            appuser.LastName = user.LastName;
            appuser.Email = user.Email;
            appuser.Role = user.Role;
            appuser.Password = user.Password;
            appuser.UserName = user.Email;


            userMgr.Create(appuser, appuser.Password);
            userMgr.AddToRole(appuser.Id, user.Role);

            context.Users.Add(appuser);

        }

        public IEnumerable<UserVM> GetUsers()
        {
            CarDealerDbContext context = new CarDealerDbContext();
            List<UserVM> users = new List<UserVM>();

            foreach (var user in context.Users)
            {
                UserVM newUser = new UserVM();
                newUser.Id = user.Id;
                newUser.FirstName = user.FirstName;
                newUser.LastName = user.LastName;
                newUser.Email = user.Email;
                newUser.Role = user.Role;
                users.Add(newUser);
            }

            return users;
        }

        public AppUser GetUser(string Id)
        {
            CarDealerDbContext context = new CarDealerDbContext();
            return context.Users.Find(Id);
        }

        public void EditUser(UserVM userVM)
        {
            CarDealerDbContext context = new CarDealerDbContext();
            var edit = context.Users.FirstOrDefault(u => u.Id == userVM.Id);
            if (edit != null)
            {
                edit.LastName = userVM.LastName;
                edit.FirstName = userVM.FirstName;
                edit.Email = userVM.Email;
                edit.Password = userVM.Password;
                edit.Role = userVM.Role;
                edit.UserName = userVM.Email;
            }
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            userMgr.AddToRole(edit.Id, edit.Role);
            context.SaveChanges();
        }
    }
}
