using System.Text.Json.Nodes;
using CRUD.Models.Data;
using CRUD.Models.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers{

  public class TrabajadorController : Controller{

    private ITrabajadorRepository _trabajadorRepository;

    public TrabajadorController(ITrabajadorRepository trabajadorRepository)
    {
      _trabajadorRepository = trabajadorRepository;
    }

    public async Task<IActionResult> Index(string Sexo)
    {

      var list = await _trabajadorRepository.GetTrabajadores(Sexo);

      return View(list);
    }

    public ActionResult Modal(){

      return View();

    }

    [HttpPost]
    public async Task<IActionResult> AddTrabajador([FromBody] Trabajador trabajador){
      await _trabajadorRepository.AddTrabajador(trabajador);
      return Json(trabajador);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTrabajador([FromBody] Trabajador trabajador){
      await _trabajadorRepository.UpdateTrabajador(trabajador);
      return Json(new { Ok = true });
    }

    [HttpPost]
    public async Task<IActionResult> DeleteTrabajador([FromBody] JsonObject data){
      int idTrabajador = Int32.Parse(data["IdTrabajador"].ToString());
      await _trabajadorRepository.DeleteTrabajador(idTrabajador);
      return Json(new { Ok = true });
    }

    [HttpPost]
    public async Task<IActionResult> GetTrabajador([FromBody] JsonObject data){
      int idTrabajador = Int32.Parse(data["IdTrabajador"].ToString());
      var trabajador = await _trabajadorRepository.GetTrabajador(idTrabajador);
      return Json(trabajador);
    }
  }


}