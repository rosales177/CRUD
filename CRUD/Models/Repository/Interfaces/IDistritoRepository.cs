using CRUD.Models.Data;

namespace CRUD.Models.Repository.Interfaces{
  public interface IDistritoRepository
  {
    Task<IEnumerable<Distrito>> GetDistritosAsync(int IdProvincia);
  }
}