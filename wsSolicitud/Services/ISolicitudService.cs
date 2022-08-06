using wsSolicitud.Models;

namespace wsSolicitud.Services {

  public interface ISolicitudService {

    public Task<IEnumerable<Solicitud>> GetByDay(string dayOfCapture);
    public void Add(Solicitud[] Solicitudes);
      
  }
    
}
