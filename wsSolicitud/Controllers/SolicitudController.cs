using Microsoft.AspNetCore.Mvc;
using wsSolicitud.Services;
using wsSolicitud.Models;

namespace wsSolicitud.Controllers {

  [ApiController]
  [Route("api/[controller]")]
  public class SolicitudController : ControllerBase {

    private readonly ISolicitudService solicitudService;
    public Response response;

    public SolicitudController(ISolicitudService solicitudService) {
      this.solicitudService = solicitudService; 
      this.response = new Response();
    }
    

    [HttpGet("{dayOfCapture}")]
    public async Task<IActionResult> GetSolicitudes(string dayOfCapture) {
      var message = "";
      try {
        var solicitudes = await solicitudService.GetByDay(dayOfCapture);
        var total = solicitudes?.Count();
        if (total == 0)  message = "Sin registros";
        else message = $"{solicitudes?.Count()} solicitudes encontradas";
        response.Success = 1;
        response.Data = solicitudes;
      } catch (Exception ex) {
        response.Success = 0;
        response.Message = ex.Message;
        return BadRequest(response);
      }
      return Ok(response);
    }




  }
}
