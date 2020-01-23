using BPS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BPS.Getway
{
    public class ClientGetway
    {
        private String ConnectionString = WebConfigurationManager.ConnectionStrings["BPS"].ConnectionString;


        public int CreateClientUser(ClientProfile aProfile)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sqlQuery = "insert into [User] (userName, password, userRole) values (@uName, @uPassword, @uRole);";
            SqlCommand com = new SqlCommand(sqlQuery, con);
            com.Parameters.Clear();
            com.Parameters.AddWithValue("uName", aProfile.UserName);
            com.Parameters.AddWithValue("uPassword", aProfile.Password);
            com.Parameters.AddWithValue("uRole", 4 );
            int rowcount = com.ExecuteNonQuery();
            con.Close();
            return rowcount;
        }
        public int ProfileSave(ClientProfile aprofile)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string Sqlquery = "Insert into Client (Name, Email, Phone, Adress) values(@Cname, @Cemail, @Cphone, @Caddress)";
            SqlCommand cmd = new SqlCommand(Sqlquery, con);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("Cname", aprofile.Name);
            cmd.Parameters.AddWithValue("Cemail", aprofile.Email);
            cmd.Parameters.AddWithValue("Cphone", aprofile.Phone);
            cmd.Parameters.AddWithValue("Caddress", aprofile.Address);
            int rowcount = cmd.ExecuteNonQuery();
            con.Close();
            return rowcount;


        }
        public List<ClientProfile> GetProfile()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "select * from  Client";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            List<ClientProfile> Profiles = new List<ClientProfile>();
            while (reader.Read())
            {
                ClientProfile aClient = new ClientProfile();
                aClient.Name = reader["name"].ToString();
                aClient.Email = reader["email"].ToString();
                aClient.Phone = reader["phone"].ToString();
                aClient.Address= reader["Adress"].ToString();
                aClient.id = (int)reader["id"];

                Profiles.Add(aClient);
            }
            reader.Close();
            con.Close();
            return Profiles;
        }
        

    }
}