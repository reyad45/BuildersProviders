using BPS.Models;
using BRS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BPS.Getway
{
    public class SupplierGetway
    {
        private string ConnectionString = WebConfigurationManager.ConnectionStrings["BPS"].ConnectionString;
        UserLogin aUserlogin = new UserLogin();
        public int saveSupProfile(Supplier aSupplier)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string sqlQuery = "insert into Supplier (SupName, SupEmail, SupContact, SupAbout, SupAdress, SupCountry, SupGender,  SupDetails,  SupExperience) values (@SupName, @SupEmail, @SupContact, @SupAbout, @SupAdress, @SupCountry, @SupGender,  @SupDetails, @SupExperience) ";
            SqlCommand com = new SqlCommand(sqlQuery, con);
            com.Parameters.Clear();
            com.Parameters.AddWithValue("SupName", aSupplier.SupName);
            com.Parameters.AddWithValue("SupEmail", aSupplier.supEmail);
            com.Parameters.AddWithValue("SupContact", aSupplier.supContact);
            com.Parameters.AddWithValue("SupAbout", aSupplier.supAbout);
            com.Parameters.AddWithValue("SupAdress", aSupplier.supAdress);
            com.Parameters.AddWithValue("SupCountry", aSupplier.supCountry);
            com.Parameters.AddWithValue("SupGender", aSupplier.supGender);
            com.Parameters.AddWithValue("SupDetails", aSupplier.supDetails);
            com.Parameters.AddWithValue("SupExperience", aSupplier.supExperience);


            int rowcount = com.ExecuteNonQuery();
            con.Close();
            return rowcount;
        }


        public List<Supplier> GetSuppliers()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sql = "SELECT      id,  SupName, SupEmail, SupContact, SupAbout, SupAdress, SupCountry, SupGender, SupPicture, SupDetails, SupProfile, SupExperience FROM     Suppliers";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Supplier> Suppliers = new List<Supplier>();
            while (reader.Read())
            {
                Supplier aSupplier = new Supplier();
                aSupplier.id = Convert.ToInt32(reader["Id"]);
                aSupplier.SupName = reader["SupName"].ToString();
                aSupplier.supEmail = reader["SupEmail"].ToString();
                aSupplier.supContact = reader["supContact"].ToString();
                aSupplier.supAbout = reader["SupAbout"].ToString();
                aSupplier.supAdress = reader["SupAdress"].ToString();
                aSupplier.supCountry = reader["supCountry"].ToString();
                aSupplier.supDetails = reader["supDetails"].ToString();
                aSupplier.supExperience = reader["supExperience"].ToString();
                Suppliers.Add(aSupplier);

            }
            reader.Close();
            con.Close();
            return Suppliers;
        }
        public int CreateSupUser(Supplier aProfile)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sqlQuery = "insert into [User] (userName, password, userRole) values (@uName, @uPassword, @uRole);";
            SqlCommand com = new SqlCommand(sqlQuery, con);
            com.Parameters.Clear();
            com.Parameters.AddWithValue("uName", aProfile.UserName);
            com.Parameters.AddWithValue("uPassword", aProfile.Password);
            com.Parameters.AddWithValue("uRole", 3);
            int rowcount = com.ExecuteNonQuery();
            con.Close();
            return rowcount;
        }


    }
}