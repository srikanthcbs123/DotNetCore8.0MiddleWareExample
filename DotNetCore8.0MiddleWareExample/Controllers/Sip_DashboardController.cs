using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DotNetCore8_MiddleWareExample
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sip_DashboardController : ControllerBase
    {
        public readonly ISipDashboardService _sipdashboardservice;
        public Sip_DashboardController(ISipDashboardService sipdashboardservice)
        {
            this._sipdashboardservice = _sipdashboardservice;
        }
        //  [HttpPost]
        // [Route ("AddSip_dashboard")]
        [HttpPost(Name = "AddSip_dashboard")]//Single line route and Httpmethod represention like this in newversion of dotnetcore.
        public async Task<IActionResult> Post([FromBody] Sip_DashboardDTO sipdashboarddtoobj)
        {
            Log.Information($"Sip_DashboardController.AddSip_dashboard method Excecution started");
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var sipdata = await _sipdashboardservice.AddSip_dashboard(sipdashboarddtoobj);
                Log.Information($"Sip_DashboardController.AddSip_dashboard method Excecution ended");
                return StatusCode(StatusCodes.Status200OK, "record added sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server error");
            }

        }
        [HttpDelete(Name = "DeleteSip_dashboardByPosition/{position}")]
        //        [HttpDelete]
        // [Route("DeleteBookingDetilsById/{id}")]

        public async Task<IActionResult> Delete(int position)
        {
            Log.Information($"Sip_DashboardController.DeleteSip_dashboardByPosition method started");
            if (position < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var sipdashdata = await _sipdashboardservice.DeleteSip_dashboard(position);
                Log.Information($"Sip_DashboardController.DeleteSip_dashboardByPosition method ended");
                if (sipdashdata == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "position not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status204NoContent, "position is deleted succesfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpGet(Name = "GetSip_dashboard")]
        public async Task<IActionResult> GetSip_dashboard()
        {
            throw new ArgumentOutOfRangeException();
            //throw new Exception();//explict way of raising the error message.
            Log.Information($"Sip_DashboardController.GetSip_dashboard method started");
            try
            {
                var sipdata = await _sipdashboardservice.GetSip_dashboard();
                Log.Information($"Sip_DashboardController.GetSip_dashboard method ended");
                if (sipdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "bad request");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, sipdata);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        // [HttpGet(Name = "GetSipdashboardByPosition/{position}")]
        //        [Route("GetBookingDetailsById/{id}")]
        [HttpGet]
        [Route("GetSip_dashboardByPosition/{position}")]

        public async Task<IActionResult> Get(int position)
        {
            Log.Information($"Sip_DashboardController.GetSip_dashboardByPosition method started");
            if (position < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad request");
            }
            try
            {
                var getsip = await _sipdashboardservice.GetSip_dashboardByPosition(position);
                Log.Information($"Sip_DashboardController.GetSip_dashboardByPosition method ended");
                if (getsip == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "sip position not found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, getsip);
                }
            }
            catch (Exception ex)

            {
                return StatusCode(StatusCodes.Status500InternalServerError, "server not found");
            }
        }
        [HttpPut(Name = "UpdateSip_dashboard")]
        public async Task<IActionResult> Put([FromBody] Sip_DashboardDTO sipdashboardobj)
        {
            Log.Information($"Sip_DashboardController.UpdateSip_dashboard method started");
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                var countryData = await _sipdashboardservice.UpdateSip_dashboard(sipdashboardobj);
                Log.Information($"Sip_DashboardController.UpdateSip_dashboard method ended");
                return StatusCode(StatusCodes.Status201Created, "sipdashboard Details Updated Succesfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "System or Server Error");
            }
        }
    }
}
