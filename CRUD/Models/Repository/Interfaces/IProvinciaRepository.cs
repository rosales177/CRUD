using CRUD.Models.Data;

namespace CRUD.Models.Repository.Interfaces{
  public interface IProvinciaRepository
  {
    Task<IEnumerable<Provincia>> GetProvinciasAsync(int IdDepartamento);
  }
}