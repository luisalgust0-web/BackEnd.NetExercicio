using Microsoft.AspNetCore.Mvc;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class FilmController : ControllerBase
{
    public readonly IFilmService _service;
    public FilmController(IFilmService service)
    {
        _service = service;
    }
    [HttpGet("GetFilms")]
    public IActionResult GetLista(){
        List<FilmOutput> filmOutputs = _service.GetLista();
        return new JsonResult(filmOutputs);
    }
    [HttpPost("AddFilm")]
    public bool Add(FilmInput filmInput){
        return _service.Add(filmInput);
    }
    [HttpDelete("DeleteFilm/{id}")]
    public bool Remove(int id){
        return _service.Remover(id);
    }
}
