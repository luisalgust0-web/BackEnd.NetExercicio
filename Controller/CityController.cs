using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services;
using WebExercicios.Services.Base;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class CityController : ControllerBase
{
    private readonly IServiceBase<Citys> _service;

    public CityController(IServiceBase<Citys> service)
    {
        _service = service;
    }

    
    [HttpGet("GetLista")]
    public IActionResult GetCitys()
    {
        return new JsonResult(_service.GetQuery().Include(x => x.Country).MapList<CityOutput>());
    }

    [HttpGet("GetItem/{id}")]
    public IActionResult GetCity(int id)
    {
        return new JsonResult(_service.GetItem<CityOutput>(id));
    }

}
