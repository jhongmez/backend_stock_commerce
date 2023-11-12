using StockCommerce.Transversal.Interface;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace StockCommerce.Infraestructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration) 
        { 
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sql_connection = new SqlConnection();
                if (sql_connection == null) return null;

                sql_connection.ConnectionString = _configuration.GetConnectionString("connection_db");
                sql_connection.Open();
                return sql_connection;
                
            }
        }
    }
}
