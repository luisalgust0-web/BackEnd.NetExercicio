using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services;
using WebExercicios.Services.Base;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class CityController
{
    private readonly Services.IServiceBase<Citys> _service;

    public CityController(IServiceBase<Citys> service)
    {
        _service = service;
    }

    [HttpGet("GetLanguages")]
    public IActionResult GetLanguages()
    {
        List<CityOutput> lista = _service.GetQuery().Include(x => x.Country).MapList<CityOutput>();

        return new JsonResult(lista);
    }
}
