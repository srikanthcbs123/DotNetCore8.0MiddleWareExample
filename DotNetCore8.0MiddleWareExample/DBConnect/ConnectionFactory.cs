using Microsoft.Data.SqlClient;

namespace DotNetCore8_MiddleWareExample
{
    public class ConnectionFactory : IConnectionFactory
    {
        IConfiguration configuration;
        public ConnectionFactory(IConfiguration _configuration)
        {
            configuration = _configuration; 
        }
        public SqlConnection HotelMgmt_SqlConnectionstring()
        {
            SqlConnection sqlConnection = new SqlConnection(configuration.GetConnectionString("Hotelmgmt_DBSqlConnectionString"));
            return sqlConnection;
        }
    }
}
