using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services;
using WebExercicios.Services.Base;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class CityController
{
    private readonly IServiceBase<Citys> _service;

    public CityController(IServiceBase<Citys> service)
    {
        _service = service;
    }

    
    [HttpGet("GetLista")]
    public IActionResult GetLanguages()
    {
        return new JsonResult(_service.GetQuery().MapList<CityOutput>());
    }

    [HttpGet("GetItem/{id}")]
    public IActionResult GetLanaguage(int id)
    {
        return new JsonResult(_service.GetItem<CityOutput>(id));
    }

}
