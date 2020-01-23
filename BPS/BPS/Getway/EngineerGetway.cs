using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using BPS.Models;
using BRS.Models;

namespace BPS.Getway
{
      

    public class EngineerGetway

    {
        private string ConnectionString = WebConfigurationManager.ConnectionStrings["BPS"].ConnectionString;
        UserLogin aUserlogin = new UserLogin();
        public int saveEngProfile(Engineer aEngineer)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string sqlQuery = "insert into Engineer (engName, engEmail, engContact, engAbout, engAdress, engCountry, engGender,  engDetails, engExperience, engEntryBy, engEntryDate) values (@engName, @engEmail, @engContact, @engAbout, @engAdress, @engCountry, @engGender,  @engDetails, @engExperience, '" + aEngineer.UserName + "','"+ DateTime.Now +"') ";
            SqlCommand com = new SqlCommand(sqlQuery, con);
            com.Parameters.Clear();
            com.Parameters.AddWithValue("engName", aEngineer.engName);
            com.Parameters.AddWithValue("engEmail", aEngineer.engEmail);
            com.Parameters.AddWithValue("engContact", aEngineer.engContact);
            com.Parameters.AddWithValue("engAbout", aEngineer.engAbout);
            com.Parameters.AddWithValue("engAdress", aEngineer.engAdress);
            com.Parameters.AddWithValue("engCountry", aEngineer.engCountry);
            com.Parameters.AddWithValue("engGender", aEngineer.engGender);
            com.Parameters.AddWithValue("engDetails", aEngineer.engDetails);
            com.Parameters.AddWithValue("engExperience", aEngineer.engExperience);


            int rowcount = com.ExecuteNonQuery();
            con.Close();
            return rowcount;
        }


        public List<Engineer> EngineerViewGetway()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sql ="SELECT      id,  engName, engEmail, engContact, engAbout, engAdress, engCountry, engGender, engPicture, engDetails, engProfile, engExperience FROM     Engineer";
            SqlCommand cmd= new SqlCommand(sql, con);
            cmd.Parameters.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Engineer> engineers = new List<Engineer>();
            while (reader.Read())
            {
                Engineer aEngineer = new Engineer();
                aEngineer.id = Convert.ToInt32(reader["Id"]);
                aEngineer.engName = reader["engname"].ToString();
                aEngineer.engEmail = reader["EngEmail"].ToString();
                aEngineer.engContact = reader["EngContact"].ToString();
                aEngineer.engAbout = reader["EngAbout"].ToString();
                aEngineer.engAdress = reader["EngAdress"].ToString();
                aEngineer.engContact = reader["EngCountry"].ToString();
                aEngineer.engDetails = reader["EngDetails"].ToString();
                aEngineer.engExperience = reader["engExperience"].ToString();
                engineers.Add(aEngineer);

            }
            reader.Close();
            con.Close();
            return engineers;
        }
        public int CreateEngUser(Engineer aProfile)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sqlQuery = "insert into [User] (userName, password, userRole) values (@uName, @uPassword, @uRole);";
            SqlCommand com = new SqlCommand(sqlQuery, con);
            com.Parameters.Clear();
            com.Parameters.AddWithValue("uName", aProfile.UserName);
            com.Parameters.AddWithValue("uPassword", aProfile.Password);
            com.Parameters.AddWithValue("uRole", 2);
            int rowcount = com.ExecuteNonQuery();
            con.Close();
            return rowcount;
        }


    }
}