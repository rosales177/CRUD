using CRUD.Models.Data;

namespace CRUD.Models.Repository.Interfaces{
  public interface IDepartamentoRepository
  {
    Task<IEnumerable<Departamento>> GetDepartamentosAsync();
  }
}