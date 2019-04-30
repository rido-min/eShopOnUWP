using eShop.Providers;
using eShop.UWP;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDB
{
    class Program
    {
        static string SqlConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=eShopDb;Integrated Security=SSPI";

        static async Task  Main(string[] args)
        {
            var result = SqlCatalogProvider.DatabaseExists(SqlConnectionString);
            if (result.IsOk)
            {
                

                SqlConnection.ClearAllPools();

                var createResult = await SqlCatalogProvider.CreateDatabaseAsync(SqlConnectionString);
                if (createResult.IsOk)
                {
                    await SqlCatalogProvider.FillDatabase(SqlConnectionString);
                    Console.WriteLine("Database created successfully.");
                }
            }
            else
            {
                Console.WriteLine(result.Exception);
            }
        }
    }
    
}
