using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services;
using WebExercicios.Services.Base;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;

[ApiController]
[Route("[controller]")]
public class LanguageController : ControllerBase
{

    private readonly LanguageService _service;

    public LanguageController(LanguageService service)
    {
        _service = service;
    }

    [HttpGet("GetLanguages")]
    public IActionResult GetLanguages()
    {
        return new JsonResult(_service.GetLista<LanguageOutput>());
    }

    [HttpGet("GetLanguage/{id}")]
    public IActionResult GetLanaguage(int id)
    {
        return new JsonResult(_service.GetItem<LanguageOutput>(id));
    }
}

