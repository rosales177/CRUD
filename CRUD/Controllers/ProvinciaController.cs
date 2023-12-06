using CRUD.Models.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers{

  public class ProvinciaController : Controller{

    private IProvinciaRepository _ProvinciaRepository;

    public ProvinciaController(IProvinciaRepository ProvinciaRepository)
    {
      _ProvinciaRepository = ProvinciaRepository;
    }

    public async Task<IActionResult> Index(int departamento){
      var list = await _ProvinciaRepository.GetProvinciasAsync(departamento);
      return View(list);
    }
  }
}