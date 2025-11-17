using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Domain.Model;

namespace Data
{
    public class PlanRepository
    {
        private string GetConnectionString()
        {
            // Adjust this according to your actual configuration  
            return "Server=localhost\\SQLEXPRESS;Database=TPI;Trusted_Connection=true;TrustServerCertificate=True;MultipleActiveResultSets=true";
        }

        public void Add(Plan plan)
        {
            using var conn = new SqlConnection(GetConnectionString());
            using var cmd = new SqlCommand(
                "INSERT INTO Planes (Descripcion, EspecialidadId) OUTPUT INSERTED.Id VALUES (@desc, @espId)", conn);
            cmd.Parameters.AddWithValue("@desc", plan.Descripcion);
            cmd.Parameters.AddWithValue("@espId", plan.EspecialidadId);

            conn.Open();
            plan.Id = (int)cmd.ExecuteScalar();
        }

        public bool Delete(int id)
        {
            using var conn = new SqlConnection(GetConnectionString());
            using var cmd = new SqlCommand("DELETE FROM Planes WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public Plan? Get(int id)
        {
            using var conn = new SqlConnection(GetConnectionString());
            using var cmd = new SqlCommand("SELECT Id, Descripcion, EspecialidadId FROM Planes WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Plan
                {
                    Id = reader.GetInt32(0),
                    Descripcion = reader.GetString(1),
                    EspecialidadId = reader.GetInt32(2)
                };
            }
            return null;
        }

        public IEnumerable<Plan> GetAll()
        {
            var result = new List<Plan>();
            using var conn = new SqlConnection(GetConnectionString());
            using var cmd = new SqlCommand("SELECT Id, Descripcion, EspecialidadId FROM Planes", conn);

            conn.Open();
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Plan
                {
                    Id = reader.GetInt32(0),
                    Descripcion = reader.GetString(1),
                    EspecialidadId = reader.GetInt32(2)
                });
            }
            return result;
        }

        public bool Update(Plan plan)
        {
            using var conn = new SqlConnection(GetConnectionString());
            using var cmd = new SqlCommand(
                "UPDATE Planes SET Descripcion = @desc, EspecialidadId = @espId WHERE Id = @id", conn);
            cmd.Parameters.AddWithValue("@desc", plan.Descripcion);
            cmd.Parameters.AddWithValue("@espId", plan.EspecialidadId);
            cmd.Parameters.AddWithValue("@id", plan.Id);

            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }

        public bool DescripcionExists(string desc, int? excludeId = null)
        {
            using var conn = new SqlConnection(GetConnectionString());
            string sql = "SELECT COUNT(*) FROM Planes WHERE Descripcion = @desc";
            if (excludeId.HasValue)
                sql += " AND Id <> @excludeId";
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@desc", desc);
            if (excludeId.HasValue)
                cmd.Parameters.AddWithValue("@excludeId", excludeId.Value);

            conn.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }
    }
}