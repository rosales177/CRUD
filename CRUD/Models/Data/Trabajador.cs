using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models.Data{
  
  public class Trabajador{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int? IdTrabajador { get; set; }
    public string TipoDocumento { get; set; }
    public string NroDocumento  {get;set;}
    public string Nombres { get; set; }
    public string Sexo {get;set;}
    public int IdDistrito {get;set;}
    
  }

}
