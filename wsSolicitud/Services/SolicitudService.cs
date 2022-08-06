using wsSolicitud.Models;
using Dapper;

namespace wsSolicitud.Services {

  public class SolicitudService : ISolicitudService {

    private readonly SolicitudContext ctx;

    public SolicitudService(SolicitudContext ctx) {
      this.ctx = ctx; 
    }
    
    public async Task<IEnumerable<Solicitud>> GetByDay(string dayOfCapture) {
      dayOfCapture = dayOfCapture.Replace("-", "/");
      var query = $"SELECT * FROM Solicitud WHERE FCaptura = '{dayOfCapture}'";
      try {
        using var conn = ctx.CreateConnection();
        var solicitudes = await conn.QueryAsync<Solicitud>(query);
        return solicitudes.ToList();
      } catch (Exception ex) {
        throw new Exception(ex.Message);
      }
    }

    public void BulkInsert(SolicitudRequest solicitudRequest) {

      try {
        // using var db = new SolicitudContext();    
        // Todo: inser records into database
      } catch (Exception ex) {
        throw new Exception(ex.Message);
      }

    }

  }
    
}
