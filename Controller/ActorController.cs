using Microsoft.AspNetCore.Mvc;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class ActorController : ControllerBase
{
    private readonly IActorService _actorService;
    public ActorController(IActorService actorService)
    {
        _actorService = actorService;
    }

    [HttpGet("GetActors")]
    public IActionResult GetActors(){
        List<ActorOutput> actorOutputs =_actorService.GetLista();
        return new JsonResult(actorOutputs);
    }

    [HttpPost("AddActor")]
    public bool AddActor(ActorInput actorInput){
        return _actorService.Add(actorInput);
    }

    [HttpDelete("RemoveActor/{id}")]
    public bool RemoveActor(int id){
        return _actorService.Remove(id);
    }
}
