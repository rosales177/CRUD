using CRUD.Models.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers{

  public class DistritoController : Controller{

    private IDistritoRepository _DistritoRepository;

    public DistritoController(IDistritoRepository DistritoRepository)
    {
      _DistritoRepository = DistritoRepository;
    }

    public async Task<IActionResult> Index(int provincia){
      var list = await _DistritoRepository.GetDistritosAsync(provincia);
      return View(list);
    }

  }
  
}