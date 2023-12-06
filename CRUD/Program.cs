using CRUD.Models.Data;
using CRUD.Models.Repository.Implementations;
using CRUD.Models.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<DbCrudContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbCrudConnection"));
});

builder.Services.AddTransient<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<IProvinciaRepository, ProvinciaRepository>();
builder.Services.AddTransient<IDistritoRepository, DistritoRepository>();
builder.Services.AddTransient<ITrabajadorRepository, TrabajadorRepository>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DbCrudContext>();  
    context.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
