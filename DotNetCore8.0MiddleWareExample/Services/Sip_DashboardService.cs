  using Serilog;
 namespace DotNetCore8_MiddleWareExample
{
    public class Sip_DashboardService:ISipDashboardService
    {
        public readonly ISipDashboardRepository _sipDashboardRepository;
        public Sip_DashboardService(ISipDashboardRepository sipDashboardRepository)

        {
            _sipDashboardRepository = sipDashboardRepository;
        }
        public async Task<bool> AddSip_dashboard(Sip_DashboardDTO sip_dashboarddetail)
        {
            Log.Information($"Sip_DashboardServices.AddSip_dashboard method  started");
            Sip_Dashboard obj = new Sip_Dashboard();
            obj.name = sip_dashboarddetail.name;
            obj.weight = sip_dashboarddetail.weight;
            obj.symbol = sip_dashboarddetail.symbol;
            obj.location = sip_dashboarddetail.location;
            Log.Information($"Sip_DashboardController.AddSip_dashboard method ended");
            await _sipDashboardRepository.AddSip_dashboard(obj);
            return true;
        }

        public async Task<bool> DeleteSip_dashboard(int position)
        {
            Log.Information($"Sip_DashboardServices.DeleteSip_dashboard method started");
            await _sipDashboardRepository.DeleteSip_dashboard(position);
            Log.Information($"Sip_DashboardServices.DeleteSip_dashboard method ended");
            return true;
        }

        public async Task<List<Sip_DashboardDTO>> GetSip_dashboard()
        {
            Log.Information($"Sip_DashboardServices_GetSip_dashboard method started");
            List<Sip_DashboardDTO> lstsip = new List<Sip_DashboardDTO>();
            var result = await _sipDashboardRepository.GetSip_dashboard();
            foreach (Sip_Dashboard sip in result)
            {
                Sip_DashboardDTO sipdto = new Sip_DashboardDTO();
                sipdto.position = sip.position;
                sipdto.weight = sip.weight;
                sipdto.symbol = sip.symbol;
                sipdto.name = sip.name;
                sipdto.location = sip.location;
                lstsip.Add(sipdto);
            }
            Log.Information($"Sip_DashboardServices.GetSip_dashboard method ended");
            return lstsip;
        } 
        public async Task<Sip_DashboardDTO> GetSip_dashboardByPosition(int position)
        {
            Log.Information($"Sip_DashboardServices.GetSip_dashboard method started");
            var result = await _sipDashboardRepository.GetSip_dashboardByPosition(position);

            Sip_DashboardDTO sipdto = new Sip_DashboardDTO();
            sipdto.position = result.position;
            sipdto.weight = result.weight;
            sipdto.symbol = result.symbol;
            sipdto.name = result.name;
            sipdto.location = result.location;
            Log.Information($"Sip_DashboardServices.GetSip_dashboard method ended");
            return sipdto;
        } 
        public async Task<bool> UpdateSip_dashboard(Sip_DashboardDTO sip_dashboarddetail)
        {
            Log.Information($"Sip_DashboardServices.GetSip_dashboard method started");
            Sip_Dashboard sipobj = new Sip_Dashboard();
            sipobj.position = sip_dashboarddetail.position;
            sipobj.weight = sip_dashboarddetail.weight;
            sipobj.symbol = sip_dashboarddetail.symbol;
            sipobj.name = sip_dashboarddetail.name;
            sipobj.location = sip_dashboarddetail.location;
            Log.Information($"Sip_DashboardServices.GetSip_dashboard method ended");
            await _sipDashboardRepository.UpdateSip_dashboard(sipobj);
            return true;
        }

    }
}

