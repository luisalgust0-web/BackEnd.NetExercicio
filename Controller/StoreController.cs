using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class StoreController : ControllerBase
{
    private readonly IServiceBase<Store> _service;

    public StoreController(IServiceBase<Store> service)
    {
        _service = service;
    }

    [HttpGet("GetLista")]
    public IActionResult GetStores()
    {
        return new JsonResult(_service.GetQuery().Include(x => x.Address.City).Include(x => x.Staff).MapList<StoreOutput>());
    }

    [HttpGet("GetItem/{id}")]
    public IActionResult GetStore(int id)
    {
        return new JsonResult(_service.GetQuery().Where(x => x.Store_id == id).Include(x => x.Address.City).Include(x => x.Staff).MapList<StoreOutput>());
    }
}
