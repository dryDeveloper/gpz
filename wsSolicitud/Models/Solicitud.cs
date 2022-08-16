using System.ComponentModel.DataAnnotations;

namespace wsSolicitud.Models {

  public class Solicitud {

    private string folio = "";
    [Key]
    public string Folio { 
      get => folio; 
      set => folio = value.ToString(); 
    } 
    public string TipoPersona { get; set; } = "";
    public string TipoProyecto { get; set; } = "";
    public string CP { get; set; } = "";
    public string Calle { get; set; } = "";
    public string Ciudad { get; set; } = "";
    public string Colonia { get; set; } = "";
    public string Estado { get; set; } = "";
    public string FCaptura { get; set; } = "";
    public string Modalidad { get; set; } = "";
    public string Municipio { get; set; } = "";
    public string NoExterior { get; set; } = "";
    public string NoInterior { get; set; } = "";
    public string NombreCompleto { get; set; } = "";
    public string NumeroAsignado { get; set; } = "";
    public string RFC { get; set; } = "";
    public string RefNom1 { get; set; } = "";
    public string RefNom2 { get; set; } = "";
    public string RefNom3 { get; set; } = "";
    public string TTramite { get; set; } = "";
    public string Telefono { get; set; } = "";
    public string TelefonoNom20 { get; set; } = "";
    public string Urgente { get; set; } = "";
    public string fechaAsignacion { get; set; } = "";
    public string fechaVigencia { get; set; } = "";
    public string refTel { get; set; } = "";
    public string refTel2 { get; set; } = "";
    public string refTel3 { get; set; } = "";
    public string fechaContestado { get; set; } = "";
    public string TelefonoRep { get; set; } = "";
    public string RepPaterno { get; set; } = "";
    public string obsFV { get; set; } = "";
    public string obsTelcel { get; set; } = "";
    public string Entrecalle { get; set; } = "";
  }

}
