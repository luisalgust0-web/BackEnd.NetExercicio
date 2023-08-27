using Microsoft.AspNetCore.Mvc;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class FilmActorController : ControllerBase
{
    private readonly IFilmActorService _service;
    public FilmActorController(IFilmActorService service)
    {
        _service = service;
    }

    [HttpPost("AddFilmActors")]
    public bool AddFilmActors(FilmActorInput filmActorInput){
        return _service.Add(filmActorInput);
    }

    [HttpDelete("RemoveFilmActors/{filmId}/{actorId}")]
    public bool RemoveFilmActors(int filmId, int actorId){
        return _service.Remove(filmId, actorId);
    }

    [HttpGet("GetFilmActors")]
    public IActionResult GetFilmActors()
    {
        List<FilmActorOutput> filmActorOutputs = _service.GetFilmActors();
        return new JsonResult(filmActorOutputs);
    }
    [HttpGet("GetFilmByActors")]
    public IActionResult GetFilmByActors(string actorFName,string actorLName)
    {
        List<FilmActorOutput> filmActorOutputs = _service.GetFilmsByActor(actorFName, actorLName);
        return new JsonResult(filmActorOutputs);
    }
    [HttpGet("GetActorsByFilm")]
    public IActionResult GetActorsByFilm(string film)
    {
        List<FilmActorOutput> filmActorOutputs = _service.GetActorsByFilm(film);
        return new JsonResult(filmActorOutputs);
    }
}
