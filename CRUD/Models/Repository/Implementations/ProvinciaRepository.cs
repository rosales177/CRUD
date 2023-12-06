using CRUD.Models.Data;
using CRUD.Models.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models.Repository.Implementations{

  public class ProvinciaRepository : IProvinciaRepository
  {
    private readonly DbCrudContext _context;

    public ProvinciaRepository(DbCrudContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Provincia>> GetProvinciasAsync(int IdDepartamento)
    {
      return await _context.Provincias.Where(p => p.IdDepartamento == IdDepartamento).ToListAsync();
    }

  }
}