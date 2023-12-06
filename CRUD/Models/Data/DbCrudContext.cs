using Microsoft.EntityFrameworkCore;

namespace CRUD.Models.Data{

  public class DbCrudContext : DbContext{

    public DbCrudContext(DbContextOptions<DbCrudContext> options) : base(options) {} 

    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<Provincia> Provincias { get; set; }
    public DbSet<Distrito> Distritos { get; set; }
    public DbSet<Trabajador> Trabajadores { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Departamento>().ToTable("Departamento");
      modelBuilder.Entity<Provincia>().ToTable("Provincia");
      modelBuilder.Entity<Distrito>().ToTable("Distrito");
      modelBuilder.Entity<Trabajador>().ToTable("Trabajador");

      modelBuilder.Entity<Departamento>().HasKey(x => x.IdDepartamento).IsClustered();
      modelBuilder.Entity<Provincia>().HasKey(x => new {x.IdDepartamento, x.IdProvincia}).IsClustered();
      modelBuilder.Entity<Distrito>().HasKey(x => new {x.IdProvincia, x.IdDistrito}).IsClustered();
      modelBuilder.Entity<Trabajador>().HasKey(x => x.IdTrabajador).IsClustered();
    }

  }

}