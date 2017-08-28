using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final_Social_Cases_Project.Models.Contexts {
    public class OrphanContext : DbContext {
        public DbSet<Orphan> Orphans { get; set; }


        public void AddOrphan(Orphan orphan) {

            string connectionString = ConfigurationManager.ConnectionStrings["OrphanContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString)) {

                string sql_query = "INSERT INTO Orphans (Name, Years, Surname, Location, Gender)" +
                    " VALUES (@Name, @Years, @Surname, @Location, @Gender)";
                SqlCommand cmd = new SqlCommand(sql_query, con);

                cmd.Parameters.AddWithValue("@Name", orphan.Name);
                cmd.Parameters.AddWithValue("@Years", orphan.Years);
                cmd.Parameters.AddWithValue("@Surname", orphan.Surname);
                cmd.Parameters.AddWithValue("@Location", orphan.Location);
                cmd.Parameters.AddWithValue("@Gender", orphan.Gender);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditOrphan(Orphan orphan) {
            string connectionString = ConfigurationManager.ConnectionStrings["OrphanContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString)) {

                string sql_query = "UPDATE Orphans" + 
                    " SET Name=@Name, Years=@Years, Surname=@Surname, Location=@Location, Gender=@Gender" +
                    " WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql_query, con);

                cmd.Parameters.AddWithValue("@Name", orphan.Name);
                cmd.Parameters.AddWithValue("@Years", orphan.Years);
                cmd.Parameters.AddWithValue("@Surname", orphan.Surname);
                cmd.Parameters.AddWithValue("@Location", orphan.Location);
                cmd.Parameters.AddWithValue("@Gender", orphan.Gender);
                cmd.Parameters.AddWithValue("@ID", orphan.ID);

                con.Open();
                cmd.ExecuteNonQuery();
                //System.Diagnostics.Debug.WriteLine("OK!");
            }
        }

        public void DeleteOrphan(int id) {
            string connectionString = ConfigurationManager.ConnectionStrings["OrphanContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString)) {

                string sql_query = "DELETE FROM Orphans" +
                    " WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql_query, con);

                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


    }
}