using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class AddressController
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
        return _service.Add(input); 
    }

    [HttpDelete("DeleteItem")]
    public bool DeleteAddress(int id){
        return _service.Remove(id);
    }
}
