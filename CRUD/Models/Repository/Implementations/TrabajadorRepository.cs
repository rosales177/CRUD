using CRUD.Models.Data;
using CRUD.Models.Repository.Interfaces;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Models.Repository.Implementations{

    public class TrabajadorRepository : ITrabajadorRepository
    {
        protected readonly DbCrudContext _context;

        public TrabajadorRepository(DbCrudContext context)
        {
            _context = context;
        }

        public async Task<Trabajador> AddTrabajador(Trabajador trabajador)
        {
            await _context.Trabajadores.AddAsync(trabajador);
            await _context.SaveChangesAsync();

            return trabajador;
        }

        public async Task<bool> DeleteTrabajador(int id)
        {
            var trabajador = _context.Set<Trabajador>().Find(id);
            if(trabajador == null) {
              return false;
            }

            _context.Set<Trabajador>().Remove(trabajador);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<TrabajadorDAO> GetTrabajador(int id)
        {
            var trabajadorDAO = await _context.Trabajadores
            .OrderByDescending(t => t.IdTrabajador)
            .Select(t => new TrabajadorDAO
            {
                Trabajador = t,
                Distrito = _context.Distritos
                    .Where(d => d.IdDistrito == t.IdDistrito)
                    .FirstOrDefault(),
                Provincia = _context.Provincias
                    .Where(p => p.IdProvincia == _context.Distritos
                        .Where(d => d.IdDistrito == t.IdDistrito)
                        .Select(d => d.IdProvincia)
                        .FirstOrDefault())
                    .FirstOrDefault(),
                Departamento = _context.Departamentos
                    .Where(dep => dep.IdDepartamento == _context.Provincias
                        .Where(p => p.IdProvincia == _context.Distritos
                            .Where(d => d.IdDistrito == t.IdDistrito)
                            .Select(d => d.IdProvincia)
                            .FirstOrDefault())
                        .Select(p => p.IdDepartamento)
                        .FirstOrDefault())
                    .FirstOrDefault()
            }).FirstOrDefaultAsync(x => x.Trabajador.IdTrabajador == id);

            return trabajadorDAO;
        }

        public async Task<IEnumerable<TrabajadorDAO>> GetTrabajadores(string Sexo = "A")
        {
            var trabajadoresDAO = await _context.Trabajadores
            .OrderByDescending(t => t.IdTrabajador)
            .Select(t => new TrabajadorDAO
            {
                Trabajador = t,
                Distrito = _context.Distritos
                    .Where(d => d.IdDistrito == t.IdDistrito)
                    .FirstOrDefault(),
                Provincia = _context.Provincias
                    .Where(p => p.IdProvincia == _context.Distritos
                        .Where(d => d.IdDistrito == t.IdDistrito)
                        .Select(d => d.IdProvincia)
                        .FirstOrDefault())
                    .FirstOrDefault(),
                Departamento = _context.Departamentos
                    .Where(dep => dep.IdDepartamento == _context.Provincias
                        .Where(p => p.IdProvincia == _context.Distritos
                            .Where(d => d.IdDistrito == t.IdDistrito)
                            .Select(d => d.IdProvincia)
                            .FirstOrDefault())
                        .Select(p => p.IdDepartamento)
                        .FirstOrDefault())
                    .FirstOrDefault()
            })
            .ToListAsync();

          if (Sexo != "A")
          {
            trabajadoresDAO = trabajadoresDAO.Where(t => t.Trabajador.Sexo == Sexo).ToList();
          }

          return trabajadoresDAO;
            
        }

        public async Task<bool> UpdateTrabajador(Trabajador trabajador)
        {
            _context.Entry(trabajador).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }
    }

}