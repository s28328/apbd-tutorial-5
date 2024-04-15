using System.Data.SqlClient;
using System.Globalization;
using APBD_tutor_5.Model;
using Microsoft.Data.SqlClient;

namespace APBD_tutor_5.Repositories;

public class AnimalRepository:IAnimalRepository
{
    private IConfiguration _configuration;
    
    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public IEnumerable<Animal> GetAnimals()
    {
        try
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            using var conn = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
            conn.Open();
        

            using var cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "SELECT IdAnimal, Name, Category, Description, Area FROM Animal";
            var dr = cmd.ExecuteReader();
            var animals = new List<Animal>();
            while (dr.Read())
            {
                var animal = new Animal
                {
                    IdAnimal = (int)dr["IdAnimal"],
                    Name = dr["Name"].ToString(),
                    Category = dr["Category"].ToString(),
                    Description = dr["Description"].ToString(),
                    Area = dr["Area"].ToString()
                };
                animals.Add(animal);
            }
            return animals;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public int CreateAnimal(Animal animal)
    {
        using var conn = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        conn.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "INSERT INTO Animal(Name, Category, Description, Area) VALUES(@Name, @Category, @Description, @Area)";
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Category", animal.Category);
        cmd.Parameters.AddWithValue("@Description", animal.Description);
        cmd.Parameters.AddWithValue("@Area", animal.Area);
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public Animal GetAnimal(int id)
    {
        using var conn = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        conn.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT IdAnimal, Name, Category, Description, Area FROM Animal WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", id);

        var dr = cmd.ExecuteReader();
        if (!dr.Read()) return null;
        var animal = new Animal()
        {
            IdAnimal = (int)dr["IdAnimal"],
            Name = dr["Name"].ToString(),
            Category = dr["Category"].ToString(),
            Description = dr["Description"].ToString(),
            Area = dr["Area"].ToString()   
        };
        return animal;
    }

    public int UpdateAnimal(int id, Animal animal)
    {
        using var conn = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        conn.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "UPDATE Animal SET Name=@Name, Category=@Category, Description=@Description, Area=@Area WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal",id);
        cmd.Parameters.AddWithValue("@Name", animal.Name);
        cmd.Parameters.AddWithValue("@Category",animal.Category);
        cmd.Parameters.AddWithValue("@Description",animal.Description);
        cmd.Parameters.AddWithValue("@Area",animal.Area);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }

    public int DeleteAnimal(int id)
    {
        using var conn = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        conn.Open();
        
        using var cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "DELETE FROM Student WHERE IdAnimal = @IdAnimal";
        cmd.Parameters.AddWithValue("@IdAnimal", id);
        
        var affectedCount = cmd.ExecuteNonQuery();
        return affectedCount;
    }
}