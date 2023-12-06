using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models.Data{
  
  public class Provincia{

    [Key]
    [Column(Order = 0)]
    public int IdDepartamento {get;set;}

    [Key]
    [Column(Order = 1)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdProvincia { get; set; }
    
    public string NombreProvincia {get;set;}
  }

}
