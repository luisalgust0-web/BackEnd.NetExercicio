using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
public class CountryController : ControllerBase
{
    private readonly IServiceBase<Countrys> _service;

    public CountryController(IServiceBase<Countrys> service)
    {
        _service = service;
    }


    [HttpGet("GetLista")]
    public IActionResult GetCountrys()
    {
        return new JsonResult(_service.GetQuery().MapList<CountryOutput>());
    }

    [HttpGet("GetItem/{id}")]
    public IActionResult GetCountry(int id)
    {
        return new JsonResult(_service.GetItem<CountryOutput>(id));
    }

}
