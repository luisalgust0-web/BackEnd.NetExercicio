using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class FilmController : ControllerBase
{
    private readonly IServiceBase<Film> _service;

    public FilmController(IServiceBase<Film> service)
    {
        _service = service;
    }

    [HttpGet("GetLista")]
    public IActionResult GetFilms(){
        return new JsonResult(_service.GetQuery().Include(x => x.Language).Include(x => x.Original_language).MapList<FilmOutput>());
    }

    [HttpGet("GetListaByTitle")]
    public IActionResult GetFilmsByTitle(string title){
        return new JsonResult(_service.GetQuery().Where(x => x.Title.Contains(title)).Include(x => x.Language).Include(x => x.Original_language).MapList<FilmOutput>());
    }

    [HttpGet("GetItem/{id}")]
    public IActionResult GetFilm(int id){
        return new JsonResult(_service.GetItem<FilmOutput>(id));
    }

}
