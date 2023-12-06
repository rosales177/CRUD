using CRUD.Models.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers{

  public class DepartamentoController : Controller{

    private IDepartamentoRepository _DepartamentoRepository;

    public DepartamentoController(IDepartamentoRepository DepartamentoRepository)
    {
      _DepartamentoRepository = DepartamentoRepository;
    }

    public async Task<IActionResult> Index(){

      var list = await _DepartamentoRepository.GetDepartamentosAsync();

      return View(list);
    }
  }
}