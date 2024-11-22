using AplicacionTestMVC.Models;
using System.Data.SqlClient;

namespace AplicacionTestMVC.DAL
{
    public class AnimalDAL
    {
        private string connectionString = "";

        public List<Animal> GetAll()
        {
            List<Animal> animales = new List<Animal>();
            TipoAnimalDAL tipoAnimal = new TipoAnimalDAL();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Animal";
                SqlCommand cmd = new SqlCommand(sqlQuery, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    Animal animal = new Animal
                    {
                        IdAnimal = Convert.ToInt32(reader["IdAnimal"]),
                        NombreAnimal = reader["NombreAnimal"].ToString(),
                        Raza = reader["Raza"]?.ToString(),
                        RIdTipoAnimal = Convert.ToInt32(reader["RIdTipoAnimal"]),
                        FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["FechaNacimiento"]),
                        TipoDeAnimal = tipoAnimal.GetById(Convert.ToInt32(reader["RIdTipoAnimal"]))
                    };
                }
            }

            return animales;
        }
    }
}
