using Microsoft.Data.SqlClient;

namespace EShop.Repository;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

public class DatabaseHelper
{
    private readonly string _connectionString = "Server=tcp:landofdreamsappserver.database.windows.net,1433;Initial Catalog=LandOfDreamsAppDatabase;Persist Security Info=False;User ID=kikis;Password=land333Dreams;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public async Task<List<Dictionary<string, object>>> GetDataAsync(string query)
    {
        var results = new List<Dictionary<string, object>>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            await connection.OpenAsync();
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var row = new Dictionary<string, object>();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            row[reader.GetName(i)] = reader.GetValue(i);
                        }
                        results.Add(row);
                    }
                }
            }
        }
        return results;
    }
}