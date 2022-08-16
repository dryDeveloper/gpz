using Microsoft.AspNetCore.Mvc;
using wsSolicitud.Services;
using wsSolicitud.Models;
using System.Text;

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
    
    public IActionResult GetAllFolios() {
      try {
        var folios = solicitudService.GetAll();
        response.Success = 1;
        response.Data = folios;
      } catch (Exception ex) {
        response.Success = 0;
        response.Message = ex.Message;
        return BadRequest(response);
      }
      return Ok(response);
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


    [HttpPost]
    public IActionResult AddSolicitudes(List<Solicitud> Solicitudes) {
      var currentFolios = solicitudService.GetAll();
      var repeatedFolios = new List<string>();
      var filteredSolicitudes = new List<Solicitud>();
      var message = new StringBuilder("");

      foreach (var solicitud in Solicitudes) {
        foreach (var folio in currentFolios) {
          if (solicitud.Folio == folio) { 
            repeatedFolios.Add(solicitud.Folio);
          }
        }
      }

      if (repeatedFolios.Count > 0) { 
        filteredSolicitudes = Solicitudes
                                    .Where(s => repeatedFolios
                                      .All(f => s.Folio != f))
                                    .ToList();

        if (filteredSolicitudes.Count == 0) {
          message.Append("0 nuevos folios fueron importados, porfavor revise que no este importando el mismo archivo...");
          response.Message = message.ToString();
          response.Success = 3;
          return Ok(response);
        } else {
          message.Append($"{filteredSolicitudes.Count} nuevos folios fueron importados exitosamente. Los siguientes folios ya se encuentran en la base de datos: ");
          foreach (var item in repeatedFolios) {
            message.Append($"{item}, ");
          }
          message.Append("y no fueron importados...");
        }

        response.Message = message.ToString();

      } else filteredSolicitudes = Solicitudes;
      
      try {
        solicitudService.Add(filteredSolicitudes.ToArray());
        response.Success = 1;
        response.Message = message.Append($"{filteredSolicitudes.Count} nuevas solicitudes importadas exitosamente...").ToString();
      } catch (Exception ex) {
        response.Message = ex.Message;
        response.Success = 0;
        return BadRequest(response);
      }
      return Ok(response);
    }


  }
}
