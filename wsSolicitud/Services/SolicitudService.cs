using wsSolicitud.Models;
using Dapper;
using System.Text;

namespace wsSolicitud.Services {

  public class SolicitudService : ISolicitudService {

    private readonly SolicitudContext ctx;

    public SolicitudService(SolicitudContext ctx) {
      this.ctx = ctx; 
    }
    
    public async Task<IEnumerable<Solicitud>> GetByDay(string dayOfCapture) {
      dayOfCapture = dayOfCapture.Replace("-", "/");
      var query = @"SELECT * 
                    FROM Solicitud 
                    WHERE FCaptura = @FCaptura";
      try {
        using var conn = ctx.CreateConnection();
        var solicitudes = await conn.QueryAsync<Solicitud>(query, new { FCaptura = dayOfCapture });
        return solicitudes.ToList();
      } catch (Exception ex) {
        throw new Exception(ex.Message);
      }
    }

    public void Add(Solicitud[] Solicitudes) {
      if (Solicitudes.Count() == 0) return;
      var query = new StringBuilder("INSERT INTO Solicitud VALUES ");
      foreach (var solicitud in Solicitudes) {
        query.Append(@$"(
                        {solicitud.Folio},
                        {solicitud.TipoPersona},
                        {solicitud.TipoProyecto},
                        {solicitud.CP},
                        {solicitud.Calle},
                        {solicitud.Ciudad},
                        {solicitud.Colonia},
                        {solicitud.Estado},
                        {solicitud.FCaptura},
                        {solicitud.Modalidad},
                        {solicitud.Municipio},
                        {solicitud.NoExterior},
                        {solicitud.NoInterior},
                        {solicitud.NombreCompleto},
                        {solicitud.NumeroAsignado},
                        {solicitud.RFC},
                        {solicitud.RefNom1},
                        {solicitud.RefNom2},
                        {solicitud.RefNom3},
                        {solicitud.TTramite},
                        {solicitud.Telefono},
                        {solicitud.TelefonoNom20},
                        {solicitud.Urgente},
                        {solicitud.fechaAsignacion},
                        {solicitud.fechaVigencia},
                        {solicitud.refTel},
                        {solicitud.refTel2},
                        {solicitud.refTel3},
                        {solicitud.fechaContestado},
                        {solicitud.TelefonoRep},
                        {solicitud.RepPaterno},
                        {solicitud.obsFV},
                        {solicitud.obsTelcel}
                        ),");
      }
      try {
        using var conn = ctx.CreateConnection();
        var total = conn.Execute(query.ToString());
      } catch (Exception ex) {
        throw new Exception(ex.Message);
      }

    }

  }
    
}
