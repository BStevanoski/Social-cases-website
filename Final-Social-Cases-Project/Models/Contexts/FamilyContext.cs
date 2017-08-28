using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Final_Social_Cases_Project.Models.Contexts {
    public class FamilyContext : DbContext {
        public DbSet<Family> Families { get; set; }

        public void AddFamily(Family family) {

            string connectionString = ConfigurationManager.ConnectionStrings["FamilyContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString)) {

                string sql_query = "INSERT INTO Families (Surname, Location, NumberOfPeople, PhoneNumber, NumberOfEmployedMembers)" +
                    " VALUES (@Surname, @Location, @NumberOfPeople, @PhoneNumber, @NumberOfEmployedMembers)";
                SqlCommand cmd = new SqlCommand(sql_query, con);

                cmd.Parameters.AddWithValue("@Surname", family.Surname);
                cmd.Parameters.AddWithValue("@Location", family.Location);
                cmd.Parameters.AddWithValue("@NumberOfPeople", family.NumberOfPeople);
                cmd.Parameters.AddWithValue("@PhoneNumber", family.PhoneNumber);
                cmd.Parameters.AddWithValue("@NumberOfEmployedMembers", family.NumberOfEmployedMembers);
                
                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
        public void EditFamily(Family family) {
            string connectionString = ConfigurationManager.ConnectionStrings["FamilyContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString)) {

                string sql_query = "UPDATE Families" +
                    " SET Surname=@Surname, Location=@Location, NumberOfPeople=@NumberOfPeople, PhoneNumber=@PhoneNumber," +
                    " NumberOfEmployedMembers=@NumberOfEmployedMembers WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql_query, con);

                cmd.Parameters.AddWithValue("@Surname", family.Surname);
                cmd.Parameters.AddWithValue("@Location", family.Location);
                cmd.Parameters.AddWithValue("@NumberOfPeople", family.NumberOfPeople);
                cmd.Parameters.AddWithValue("@PhoneNumber", family.PhoneNumber);
                cmd.Parameters.AddWithValue("@NumberOfEmployedMembers", family.NumberOfEmployedMembers);
                cmd.Parameters.AddWithValue("@ID", family.ID);

                con.Open();
                cmd.ExecuteNonQuery();
                //System.Diagnostics.Debug.WriteLine("OK!");
            }
        }
        public void DeleteFamily(int id) {
            string connectionString = ConfigurationManager.ConnectionStrings["FamilyContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString)) {

                string sql_query = "DELETE FROM Families" +
                    " WHERE ID=@ID";
                SqlCommand cmd = new SqlCommand(sql_query, con);

                cmd.Parameters.AddWithValue("@ID", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}