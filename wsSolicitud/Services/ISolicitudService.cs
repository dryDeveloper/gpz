using wsSolicitud.Models;

namespace wsSolicitud.Services {

  public interface ISolicitudService {

    public List<Solicitud> GetRange(string startDate, string endDate);
    public void Add();
      
  }
    
}
