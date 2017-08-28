using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final_Social_Cases_Project.Models.Contexts {
    public class RefugeeContext : DbContext {
        public DbSet<Refugee> Refugees { get; set; }

        public void AddRefugee(Refugee refugee) {

            string connectionString = ConfigurationManager.ConnectionStrings["RefugeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString)) {

                string sql_query = "INSERT INTO Refugees (Surname, Location, Name, Nationality)" +
                    " VALUES (@Surname, @Location, @Name, @Nationality)";
                SqlCommand cmd = new SqlCommand(sql_query, con);

                cmd.Parameters.AddWithValue("@Surname", refugee.Surname);
                cmd.Parameters.AddWithValue("@Location", refugee.Location);
                cmd.Parameters.AddWithValue("@Name", refugee.Name);
                cmd.Parameters.AddWithValue("@Nationality", refugee.Nationality);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditRefugee(Refugee refugee) {
            string connectionString = ConfigurationManager.ConnectionStrings["RefugeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString)) {

                string sql_query = "UPDATE Refugees" +
                    " SET Surname=@Surname, Location=@Location, Name=@Name, Nationality=@Nationality" +
                    " WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql_query, con);

                cmd.Parameters.AddWithValue("@Surname", refugee.Surname);
                cmd.Parameters.AddWithValue("@Location", refugee.Location);
                cmd.Parameters.AddWithValue("@Name", refugee.Name);
                cmd.Parameters.AddWithValue("@Nationality", refugee.Nationality);
                cmd.Parameters.AddWithValue("@ID", refugee.ID);

                con.Open();
                cmd.ExecuteNonQuery();
                //System.Diagnostics.Debug.WriteLine("OK!");
            }
        }

        public void DeleteRefugee(int id) {
            string connectionString = ConfigurationManager.ConnectionStrings["RefugeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString)) {

                string sql_query = "DELETE FROM Refugees" +
                    " WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql_query, con);

                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}