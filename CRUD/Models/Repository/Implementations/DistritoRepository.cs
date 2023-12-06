using CRUD.Models.Data;
using CRUD.Models.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models.Repository.Implementations{

  public class DistritoRepository : IDistritoRepository
  {
    private readonly DbCrudContext _context;

    public DistritoRepository(DbCrudContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Distrito>> GetDistritosAsync(int IdProvincia)
    {
      return await _context.Distritos.Where(d => d.IdProvincia == IdProvincia).ToListAsync();
    }

  }
}