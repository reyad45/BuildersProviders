using BPS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace BPS.Getway
{
    public class HireGetway
    {

        private string ConnectionString = WebConfigurationManager.ConnectionStrings["BPS"].ConnectionString;
       
        public int HireEng(HireEng aHireEng)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();

            string sqlQuery = "insert into HireEng (Sid, Eid, RequestText, RequestDate) values (@sid, @eid, @Request, '"+ DateTime.Now +"') ";
            SqlCommand com = new SqlCommand(sqlQuery, con);
            com.Parameters.Clear();
            com.Parameters.AddWithValue("sid", aHireEng.Sid);
            com.Parameters.AddWithValue("eid", aHireEng.Eid);
            com.Parameters.AddWithValue("Request", aHireEng.RequestText);
            
            int rowcount = com.ExecuteNonQuery();
            con.Close();
            return rowcount;
        }

        public bool isExistRequest(HireEng Request)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string sqlQuery = "select * from  HireEng where Eid=@EngId and Sid = @SupID";
            SqlCommand com = new SqlCommand(sqlQuery, con);
            com.Parameters.Clear();
            com.Parameters.AddWithValue("EngId", Request.Eid);
            com.Parameters.AddWithValue("supId", Request.Sid);
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
    }
}