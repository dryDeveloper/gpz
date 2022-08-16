using wsSolicitud.Models;
using Dapper;
using System.Text;

namespace wsSolicitud.Services {

  public class SolicitudService : ISolicitudService {

    private readonly SolicitudContext ctx;

    public SolicitudService(SolicitudContext ctx) {
      this.ctx = ctx; 
    }

    public IEnumerable<string> GetAll() {
      var query = "SELECT Folio FROM Solicitud";
      try {
        using var conn = ctx.CreateConnection();
        var solicitudes = conn.Query<string>(query);
        return solicitudes;
      } catch (Exception ex) {
          throw new Exception(ex.Message);
      }
    }
    
    public async Task<IEnumerable<Solicitud>> GetByDay(string dayOfCapture) {
      dayOfCapture = dayOfCapture.Replace("-", "/");
      var query = @"SELECT * 
                    FROM Solicitud 
                    WHERE FCaptura LIKE @FCaptura";
      try {
        using var conn = ctx.CreateConnection();
        var solicitudes = await conn.QueryAsync<Solicitud>(query, 
            new { FCaptura = dayOfCapture + "%" });
        return solicitudes.ToList();
      } catch (Exception ex) {
        throw new Exception(ex.Message);
      }
    }

    public void Add(Solicitud[] Solicitudes) {

      var query = new StringBuilder("INSERT INTO Solicitud VALUES ");

      for (var i = 0; i < Solicitudes.Length; i++) {

        query.Append($"('{Solicitudes[i].Folio}',");
        query.Append($"'{Solicitudes[i].TipoPersona}',");
        query.Append($"'{Solicitudes[i].TipoProyecto}',");
        query.Append($"'{Solicitudes[i].CP}',");
        query.Append($"'{Solicitudes[i].Calle}',");
        query.Append($"'{Solicitudes[i].Ciudad}',");
        query.Append($"'{Solicitudes[i].Colonia}',");
        query.Append($"'{Solicitudes[i].Estado}',");
        query.Append($"'{Solicitudes[i].FCaptura}',");
        query.Append($"'{Solicitudes[i].Modalidad}',");
        query.Append($"'{Solicitudes[i].Municipio}',");
        query.Append($"'{Solicitudes[i].NoExterior}',");
        query.Append($"'{Solicitudes[i].NoInterior}',");
        query.Append($"'{Solicitudes[i].NombreCompleto}',");
        query.Append($"'{Solicitudes[i].NumeroAsignado}',");
        query.Append($"'{Solicitudes[i].RFC}',");
        query.Append($"'{Solicitudes[i].RefNom1}',");
        query.Append($"'{Solicitudes[i].RefNom2}',");
        query.Append($"'{Solicitudes[i].RefNom3}',");
        query.Append($"'{Solicitudes[i].TTramite}',");
        query.Append($"'{Solicitudes[i].Telefono}',");
        query.Append($"'{Solicitudes[i].TelefonoNom20}',");
        query.Append($"'{Solicitudes[i].Urgente}',");
        query.Append($"'{Solicitudes[i].fechaAsignacion}',");
        query.Append($"'{Solicitudes[i].fechaVigencia}',");
        query.Append($"'{Solicitudes[i].refTel}',");
        query.Append($"'{Solicitudes[i].refTel2}',");
        query.Append($"'{Solicitudes[i].refTel3}',");
        query.Append($"'{Solicitudes[i].fechaContestado}',");
        query.Append($"'{Solicitudes[i].TelefonoRep}',");
        query.Append($"'{Solicitudes[i].RepPaterno}',");
        query.Append($"'{Solicitudes[i].obsFV}',");
        query.Append($"'{Solicitudes[i].obsTelcel}',");
        query.Append($"'{Solicitudes[i].Entrecalle}')");

        if (i != Solicitudes.Length - 1) query.Append(",");
      }
      try {
        using var conn = ctx.CreateConnection();
        var completeQuery = query.ToString();
        var total = conn.Execute(completeQuery);
      } catch (Exception ex) {
        throw new Exception(ex.Message);
      }

    }

  }
    
}
