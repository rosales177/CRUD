using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models.Data{
  
  public class Departamento{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdDepartamento { get; set; }

    public string NombreDepartamento { get; set; }


  }

}
