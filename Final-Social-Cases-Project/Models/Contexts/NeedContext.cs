using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final_Social_Cases_Project.Models.Contexts {
    public class NeedContext :DbContext {
        public DbSet<Need> Needs { get; set; }

        public void AddNeed(Need need) {

            string connectionString = ConfigurationManager.ConnectionStrings["NeedContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString)) {

                string sql_query = "INSERT INTO Needs (NeedName)" +
                    " VALUES (@NeedName)";
                SqlCommand cmd = new SqlCommand(sql_query, con);

                cmd.Parameters.AddWithValue("@NeedName", need.NeedName);
                

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditNeed(Need need) {
            string connectionString = ConfigurationManager.ConnectionStrings["NeedContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString)) {

                string sql_query = "UPDATE Needs" +
                    " SET NeedName=@NeedName" +
                    " WHERE NeedID=@NeedID";
                SqlCommand cmd = new SqlCommand(sql_query, con);

                cmd.Parameters.AddWithValue("@NeedName", need.NeedName);
                cmd.Parameters.AddWithValue("@NeedID", need.NeedID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteNeed(int id) {
            string connectionString = ConfigurationManager.ConnectionStrings["NeedContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString)) {

                string sql_query = "DELETE FROM Needs" +
                    " WHERE NeedID=@NeedID";
                SqlCommand cmd = new SqlCommand(sql_query, con);

                cmd.Parameters.AddWithValue("@NeedID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}