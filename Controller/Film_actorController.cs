using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class Film_actorController : ControllerBase
{
    private readonly IServiceBase<Film_actor> _service;

    public Film_actorController(IServiceBase<Film_actor> service)
    {
        _service = service;
    }

    [HttpGet("GetLista")]
    public IActionResult GetFilm_actor(){
        return new JsonResult(_service.GetQuery().Include(x => x.Film).Include(x => x.Actor).MapList<Film_actorOutput>());
    }

    [HttpGet("GetItem/{id}")]
    public IActionResult GetItem(int id){
        return new JsonResult(_service.GetItem<Film_actorOutput>(id));
    }

}
