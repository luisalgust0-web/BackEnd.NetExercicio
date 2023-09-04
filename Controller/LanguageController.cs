using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;

[ApiController]
[Route("[controller]")]
public class LanguageController : ControllerBase
{

    private readonly IServiceBase<Language> _service;

    public LanguageController(IServiceBase<Language> service)
    {
        _service = service;
    }

    [HttpGet("GetLista")]
    public IActionResult GetLanguages()
    {
        return new JsonResult(_service.GetQuery().MapList<LanguageOutput>());
    }

    [HttpGet("GetItem/{id}")]
    public IActionResult GetLanaguage(int id)
    {
        return new JsonResult(_service.GetItem<LanguageOutput>(id));
    }
}

