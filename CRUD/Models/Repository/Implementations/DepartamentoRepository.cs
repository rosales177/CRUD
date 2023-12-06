using CRUD.Models.Data;
using CRUD.Models.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models.Repository.Implementations{

  public class DepartamentoRepository : IDepartamentoRepository
  {
    private readonly DbCrudContext _context;

    public DepartamentoRepository(DbCrudContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Departamento>> GetDepartamentosAsync()
    {
      return await _context.Set<Departamento>().ToListAsync();
    }

  }
}