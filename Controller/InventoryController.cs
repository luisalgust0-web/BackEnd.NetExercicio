using Microsoft.AspNetCore.Mvc;
using Namespace;
using WebExercicios.Infra.Exceptions;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class InventoryController : ControllerBase
{
    private readonly InventoryService _service;

    public InventoryController(InventoryService service)
    {
        _service = service;
    }

    [HttpGet("GetLista")]
    public IActionResult GetInventory(){
        return new JsonResult(_service.GetQuery().Include(x => x.Film).Include(x => x.Store.Address.City).MapList<InventoryOutput>());;
    }

    [HttpGet("GetListaByStoreId/{id}")]
    public IActionResult GetInventoryByStoreId(int id){
    return new JsonResult(_service.GetQuery().Where(x => x.Store_id == id).Include(x => x.Film).Include(x => x.Store.Address.City).MapList<InventoryOutput>());
    }

    [HttpGet("GetInventoryByFilmId/{id}")]
    public IActionResult GetInventoryByFilmId(int id){
        if(_service.ContainsInvetory(id)){
            return new JsonResult(_service.GetQuery().Where( x => x.Film_id == id).Include(x => x.Film).Include(x => x.Store.Address.City).MapItem<InventoryOutput>());
        }else{
            throw new LocadoraFilmeException("Titulo inexistente na loja");
        }
    } 
}
