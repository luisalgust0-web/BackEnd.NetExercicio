using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly IServiceBase<Addresses> _service;

    public AddressController(IServiceBase<Addresses> service)
    {
        _service = service;
    }

    [HttpGet("GetLista")]
    public IActionResult GetAddresses(){
        return new JsonResult(_service.GetQuery().Include(x => x.City).MapList<AddressOutput>());
    }

    [HttpGet("GetItem/{id}")]
    public IActionResult GetAddress(int id){
        return new JsonResult(_service.GetItem<AddressOutput>(id));
    }

    [HttpPost("AddItem")]
    public bool AddAddress(AddressInput input){
        _service.Add(input); 
        return true;
    }

    [HttpPost("UpdateItem")]
    public bool UpdateAddress(AddressInput input){
        return _service.Update(input); 
    }

    [HttpDelete("DeleteItem/{id}")]
    public bool DeleteAddress(int id){
        return _service.Remove(id);
    }
}
