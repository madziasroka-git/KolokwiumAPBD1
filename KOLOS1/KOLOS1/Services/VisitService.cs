using KOLOS1.DTOs;
using Microsoft.Data.SqlClient;

namespace KOLOS1.Services;

public class VisitService: IVisitService
{
    private readonly IConfiguration _configuration;

    public VisitService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task<bool> DoesVisitExist(int id)
    {
        var query = "SELECT 1 FROM Visit WHERE visit_id = @ID";
        
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await using SqlCommand command = new SqlCommand();
        
        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@ID", id);
        
        await connection.OpenAsync();
        var reader = await command.ExecuteScalarAsync();
        
        return reader is not null;
    }

    public async Task<bool> DoesClientExist(int id)
    {
        var query = "SELECT 1 FROM Client WHERE client_id = @ID";
        
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await using SqlCommand command = new SqlCommand();
        
        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@ID", id);
        
        await connection.OpenAsync();
        var reader = await command.ExecuteScalarAsync();
        
        return reader is not null;
    }

    public async Task<bool> DoesMechanicExist(int id)
    {
        var query = "SELECT 1 FROM Mechanic WHERE client_id = @ID";
        
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await using SqlCommand command = new SqlCommand();
        
        command.Connection = connection;
        command.CommandText = query;
        command.Parameters.AddWithValue("@ID", id);
        
        await connection.OpenAsync();
        var reader = await command.ExecuteScalarAsync();
        
        return reader is not null;
    }

    public async Task<ReturnVisitTPO> GetVisitById(int id)
    {
        var query = @"SELECT v.visit_id, v.date, c.first_name, c.last_name,c.date_of_birth, m.mechanic_id, m.licence_number, s.name, s.base_fee
                      FROM Visit v 
                      JOIN Client c ON c.client_id = v.client_id
                      JOIN Mechanic m ON m.mechanic_id = v.mechanic_id
                      JOIN Visit_Service vs ON vs.visit_id = v.visit_id
                      JOIN Service s ON s.service_id = vs.service_id
                      WHERE id = @ID";
        
        
        await using SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        await using SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = query;
        
        command.Parameters.AddWithValue("@ID", id);
        await connection.OpenAsync();
        var reader = await command.ExecuteReaderAsync();

        ReturnVisitTPO returnVisit = null;
        
        while (await reader.ReadAsync())
        {
            if (returnVisit is null)
            {
                returnVisit = new ReturnVisitTPO
                {
                    Date = (DateTime)reader["date"],
                    Client = new ClientTPO
                    {
                        FirstName = (string)reader["first_name"],
                        LastName = (string)reader["last_name"],
                        DateOfBirth = (DateTime)reader["date_of_birth"],
                    },
                    Mechanic = new MechanicTPO
                    {
                        MechanicId = (int)reader["mechanic_id"],
                        LicenceNumber = (string)reader["licence_number"]
                    },
                    Services = new List<ServiceTPO>()
                };
            }
            
            returnVisit.Services.Add(new ServiceTPO
            {
                Name = (string)reader["name"],
                ServiceFee = (decimal)reader["base_fee"]
            });
        }

        
        if (returnVisit is null)
        {
            Console.WriteLine(" not found");
        }

        return returnVisit;
    }

  
}