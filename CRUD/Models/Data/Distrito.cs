using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models.Data{
  
  public class Distrito{

    [Key]
    [Column(Order = 0)]
    public int IdProvincia {get;set;}

    [Key]
    [Column(Order = 1)]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdDistrito {get;set;}

    public string NombreDistrito {get;set;}
  }

}
