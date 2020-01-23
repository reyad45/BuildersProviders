using BRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace BRS.Getway
{
    public class UserGetway
    {
        private string ConnectionString = WebConfigurationManager.ConnectionStrings["BPS"].ConnectionString;
        UserLogin aUserlogin = new UserLogin();
        public int saveReg(RegisterView auserlogin)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sqlQuery = "insert into [User] (userName, password, userRole) values (@uName, @uPassword, @uRole);";
            SqlCommand com = new SqlCommand(sqlQuery, con);
            com.Parameters.Clear();
            com.Parameters.AddWithValue("uName", auserlogin.UserName);
            com.Parameters.AddWithValue("uPassword", auserlogin.Password);
            com.Parameters.AddWithValue("uRole", auserlogin.Id);
            int rowcount = com.ExecuteNonQuery();
            con.Close();
            return rowcount;
        }
        public bool isExistUser(string userName)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sqlQuery = "select * from  [User] where UserName=@uName";
            SqlCommand com = new SqlCommand(sqlQuery, con);
            com.Parameters.Clear();
            com.Parameters.AddWithValue("uName", userName);
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public List<UserLogin> Getusers()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select * from  [User]";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<UserLogin> users = new List<UserLogin>();
            while (reader.Read())
            {
                UserLogin auser = new UserLogin();
                auser.userName = reader["UserName"].ToString();
                auser.userRole = (int)reader["UserRole"];
                users.Add(auser);
            }
            reader.Close();
            con.Close();
            return users;
        }
        public List<UserLogin> GetUserRole()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string SqlQuery = "SELECT Id, Role FROM UserRole";
            SqlCommand command = new SqlCommand(SqlQuery, con);
            command.Parameters.Clear();
            SqlDataReader reader = command.ExecuteReader();
            List<UserLogin> Userlogins = new List<UserLogin>();
            while (reader.Read())
            {
                UserLogin auserLong = new UserLogin();
                auserLong.id = Convert.ToInt16(reader["id"].ToString());
                auserLong.RoleName = reader["Role"].ToString();
                Userlogins.Add(auserLong);
            }
            reader.Close();
            con.Close();
            return Userlogins;

        }
    }
}