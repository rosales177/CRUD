using CRUD.Models.Data;

namespace CRUD.Models.Repository.Interfaces{

  public interface ITrabajadorRepository
  {
    Task<IEnumerable<TrabajadorDAO>> GetTrabajadores(string Sexo = "A");
    Task<TrabajadorDAO> GetTrabajador(int id);
    Task<Trabajador> AddTrabajador(Trabajador trabajador);
    Task<bool> UpdateTrabajador(Trabajador trabajador);
    Task<bool> DeleteTrabajador(int id);
  }

}