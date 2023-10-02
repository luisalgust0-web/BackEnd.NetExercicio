using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Report;
using WebExercicios.Services;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class ActorController : ControllerBase
{
    private readonly IServiceBase<Actor> _service;
    private readonly ReportEngine _serviceReportEngine;


    public ActorController(IServiceBase<Actor> service, ReportEngine serviceReportEngine)
    {
        _service = service;
        _serviceReportEngine = serviceReportEngine;
    }

    [HttpGet("GetLista")]
    public IActionResult GetActors()
    {
        return new JsonResult(_service.GetQuery().MapList<ActorOutput>());
    }

    [HttpGet("GetItem/{id}")]
    public IActionResult GetActor(int id)
    {
        return new JsonResult(_service.GetItem<ActorOutput>(id));
    }
}
