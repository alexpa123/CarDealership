using CarDealershipNew.Data.Interfaces;
using CarDealershipNew.Models.EFModels;
using CarDealershipNew.Models.Helpers;
using CarDealershipNew.Models.Models;
using CarDealershipNew.UI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealershipNew.Data.Repos
{
    public class DropDownOptionsRepo : IDropDown
    {


        public IEnumerable<MakeModel> MakeDropdown()
        {
            List<MakeModel> makes = new List<MakeModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeDropdown", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        MakeModel make = new MakeModel();
                        make.MakeId = (int)dr["MakeId"];
                        make.Make = dr["Make"].ToString();
                        makes.Add(make);
                    }
                }
            }
            return makes;
        }

        public IEnumerable<ModelModel> ModelDropdown()
        {
            List<ModelModel> models = new List<ModelModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ModelDropdown", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ModelModel model = new ModelModel();
                        model.ModelId = (int)dr["ModelId"];
                        model.MakeId = (int)dr["MakeId"];
                        model.Model = dr["Model"].ToString();
                        models.Add(model);
                    }
                }
            }
            return models;
        }

        public IEnumerable<TypeModel> TypeDropdown()
        {
            List<TypeModel> types = new List<TypeModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TypeDropdown", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TypeModel type = new TypeModel();
                        type.TypeId = (int)dr["TypeId"];
                        type.Type = dr["Type"].ToString();
                        types.Add(type);
                    }
                }
            }
            return types;
        }

        public IEnumerable<BodyStyleModel> BodyStyleDropdown()
        {
            List<BodyStyleModel> bodyStyles = new List<BodyStyleModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("BodyStyleDropDown", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        BodyStyleModel bodyStyle = new BodyStyleModel();
                        bodyStyle.BodyStyleId = (int)dr["BodyStyleId"];
                        bodyStyle.BodyStyle = dr["BodyStyle"].ToString();
                        bodyStyles.Add(bodyStyle);
                    }
                }
            }
            return bodyStyles;
        }

        public IEnumerable<TransmissionModel> TransmissionDropdown()
        {
            List<TransmissionModel> transmissions = new List<TransmissionModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("TransmissionDropDown", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        TransmissionModel transmission = new TransmissionModel();
                        transmission.TransmissionId = (int)dr["TransmissionId"];
                        transmission.Transmission = dr["Transmission"].ToString();
                        transmissions.Add(transmission);
                    }
                }
            }
            return transmissions;
        }

        public IEnumerable<ExteriorColorModel> ExteriorColorDropdown()
        {
            List<ExteriorColorModel> exteriorColors = new List<ExteriorColorModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("ExteriorColorDropDown", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ExteriorColorModel color = new ExteriorColorModel();
                        color.ExteriorColorId = (int)dr["ExteriorColorId"];
                        color.Color = dr["Color"].ToString();
                        exteriorColors.Add(color);

                    }
                }
            }
            return exteriorColors;
        }

        public IEnumerable<InteriorColorModel> InteriorColorDropdown()
        {
            List<InteriorColorModel> interiorColors = new List<InteriorColorModel>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("InteriorColorDropDown", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        InteriorColorModel color = new InteriorColorModel();
                        color.InteriorColorId = (int)dr["InteriorColorId"];
                        color.Color = dr["Color"].ToString();
                        interiorColors.Add(color);

                    }
                }
            }
            return interiorColors;
        }

        public IEnumerable<AppRole> RolesDropDown()
        {
            CarDealerDbContext context = new CarDealerDbContext();
            return context.DBRoles.ToList();

        }
    }
}
