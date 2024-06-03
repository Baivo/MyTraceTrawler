using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WooliesScraper.Helpers
{
    public class AzureSqlHelper
    {
        private string _connectionString { get; set; }
        public AzureSqlHelper(string connectionString)
        {
            _connectionString = connectionString;
        }
        public AzureSqlHelper()
        {
            _connectionString = "Server=tcp:mytrace.database.windows.net,1433;" +
                    "Initial Catalog=MyTrace;" +
                    "Persist Security Info=False;" +
                    "User ID=mytrace;" +
                    "Password=John8:32;" +
                    "MultipleActiveResultSets=False;" +
                    "Encrypt=True;" +
                    "TrustServerCertificate=False;" +
                    "Connection Timeout=30;";
        }

        public void QueryDataExample()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    Console.WriteLine("\nQuery data example:");
                    Console.WriteLine("=========================================\n");

                    String sql = "SELECT TOP 20 pc.Name as CategoryName, p.name as ProductName " +
                        "FROM SalesLT.ProductCategory pc " +
                        "JOIN SalesLT.Product p " +
                        "ON pc.productcategoryid = p.productcategoryid;";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();
        }

        public void SetDataExample(string query)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            StringBuilder stringBuilder = new StringBuilder();
                            for (int i = 0; i < reader.FieldCount; i++) 
                            {
                                stringBuilder.Append(reader.GetString(i));
                            }
                            Console.WriteLine(stringBuilder.ToString());
                        }
                    }
                }
            }
        }
    }
}
