using Microsoft.Data.SqlClient;
using Serilog;
using System.Data;

namespace DotNetCore8_MiddleWareExample
{
    public class SIP_DashBoardRepository : ISipDashboardRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public SIP_DashBoardRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<bool> AddSip_dashboard(Sip_Dashboard sip_dashboarddetail)
        {
            Log.Information($"Sip_DasboradRepositiore.AddSip_dashboard method started");
            Log.Information($"Sip_DasboradRepositiore.AddSip_dashboard method Sip_Dashboard.name={sip_dashboarddetail.name}");
            Log.Information($"Sip_DasboradRepositiore.AddSip_dashboard method Sip_Dashboard.weight={sip_dashboarddetail.weight}");
            using (SqlCommand cmd = new SqlCommand("Usp_AddSipDashboard", _connectionFactory.HotelMgmt_SqlConnectionstring()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", sip_dashboarddetail.name);
                cmd.Parameters.AddWithValue("@weight", sip_dashboarddetail.weight);
                cmd.Parameters.AddWithValue("@symbol", sip_dashboarddetail.symbol);
                cmd.Parameters.AddWithValue("@location", sip_dashboarddetail.location);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Sip_Dashboard");
                Log.Information($"Sip_DasboradRepositiore.AddSip_dashboard method ended");
                return true;
            } 
        }
        public async Task<bool> DeleteSip_dashboard(int position)
        {
            Log.Information($"Sip_DasboradRepositiore.DeleteSip_dashboard method started");
            Log.Information($"Sip_DasboradRepositiore.DeleteSip_dashboard method position={position}");
              using(SqlCommand cmd = new SqlCommand("Usp_deleteSipDashboard", _connectionFactory.HotelMgmt_SqlConnectionstring()))
                { 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@position", position);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Sip_Dashboard");
             Log.Information($"Sip_DasboradRepositiore.DeleteSip_dashboard method ended");
            return true;
        }
        } 
        public async Task<List<Sip_Dashboard>> GetSip_dashboard()
        {
            Log.Information($"Sip_DasboradRepositiore.GetSip_dashboard method started");
            List<Sip_Dashboard> lstdashboard = new List<Sip_Dashboard>();
            using (SqlDataAdapter da = new SqlDataAdapter("Usp_GetSipDashboard", _connectionFactory.HotelMgmt_SqlConnectionstring()))
            {                
                DataSet ds = new DataSet();
                da.Fill(ds, "Sip_Dashboard");  
                foreach (DataRow row in ds.Tables["Sip_Dashboard"].Rows)
                  {
                    Sip_Dashboard objsip = new Sip_Dashboard();
                    objsip.name = Convert.ToString(row["Name"]);
                    objsip.position = Convert.ToInt16(row["position"]);
                    objsip.symbol = Convert.ToString(row["symbol"]);
                    objsip.weight = Convert.ToDecimal(row["weight"]);
                    objsip.location = Convert.ToString(row["location"]);
                    lstdashboard.Add(objsip);
                }
                Log.Information($"Sip_DasboradRepositiore.GetSip_dashboard method ended");
                return lstdashboard;
            }
        }

        public async Task<Sip_Dashboard> GetSip_dashboardByPosition(int position)
        {
            Log.Information($"Sip_DasboradRepositiore.GetSip_dashboardByPosition method started");
            Log.Information($"Sip_DasboradRepositiore.GetSip_dashboardByPosition method position={position}");

            Sip_Dashboard sipobj = new Sip_Dashboard();
            using (SqlCommand cmd = new SqlCommand("Usp_GetSipDashboardByPosition", _connectionFactory.HotelMgmt_SqlConnectionstring()))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@position", position);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Sip_Dashboard");
                foreach (DataRow row in ds.Tables["Sip_Dashboard"].Rows)
                {
                    sipobj.name = Convert.ToString(row["name"]);
                    sipobj.position = Convert.ToInt16(row["position"]);
                    sipobj.weight = Convert.ToDecimal(row["weight"]);
                    sipobj.symbol = Convert.ToString(row["symbol"]);
                    sipobj.location = Convert.ToString(row["location"]);
                } 
            Log.Information($"Sip_DasboradRepositiore.GetSip_dashboardByPosition method ended");
            return sipobj;
        }
        }
        public async Task<bool> UpdateSip_dashboard(Sip_Dashboard sip_dashboarddetail)
        {
            Log.Information($"Sip_DasboradRepositiore.UpdateSip_dashboard method started");
            Log.Information($"Sip_DasboradRepositiore.UpdateSip_dashboard method Sip_Dashboard.position={sip_dashboarddetail.position}");
            Log.Information($"Sip_DasboradRepositiore.UpdateSip_dashboard method Sip_Dashboard.name={sip_dashboarddetail.name}");
            Log.Information($"Sip_DasboradRepositiore.UpdateSip_dashboard method Sip_Dashboard.weight={sip_dashboarddetail.weight}");
            using (SqlCommand cmd = new SqlCommand("Usp_UpdateSipDashboard",_connectionFactory.HotelMgmt_SqlConnectionstring()))
            {   
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@position", sip_dashboarddetail.position);
                cmd.Parameters.AddWithValue("@name", sip_dashboarddetail.name);
                cmd.Parameters.AddWithValue("@weight", sip_dashboarddetail.weight);
                cmd.Parameters.AddWithValue("@location", sip_dashboarddetail.location);
                cmd.Parameters.AddWithValue("@symbol", sip_dashboarddetail.symbol); 
                SqlDataAdapter da =  new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Sip_Dashboard"); 
            Log.Information($"Sip_DasboradRepositiore.UpdateSip_dashboard method ended");
            return true;
        }
        } 
    }
}
 