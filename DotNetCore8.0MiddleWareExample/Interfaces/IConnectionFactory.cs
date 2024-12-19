using Microsoft.Data.SqlClient;

namespace DotNetCore8_MiddleWareExample
{
    public interface IConnectionFactory
    {
        SqlConnection HotelMgmt_SqlConnectionstring();
    }
}
