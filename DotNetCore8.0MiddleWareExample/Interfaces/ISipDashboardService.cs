namespace DotNetCore8_MiddleWareExample
{
    public interface ISipDashboardService
    {
        Task<List<Sip_DashboardDTO>> GetSip_dashboard();
        Task<Sip_DashboardDTO> GetSip_dashboardByPosition(int position);
        Task<bool> AddSip_dashboard(Sip_DashboardDTO sip_dashboarddetail);
        Task<bool> UpdateSip_dashboard(Sip_DashboardDTO sip_dashboarddetail);
        Task<bool> DeleteSip_dashboard(int position);
    }
}
