using Microsoft.AspNetCore.Mvc;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class AddressesController : ControllerBase
{
    private readonly IAddressesService _service;
    public AddressesController(IAddressesService service)
    {
        _service = service;
    }

    [HttpGet("GetAddress")]
    public IActionResult GetAddress(){
        List<AddressesOutput> addressesOutputs =_service.GetLista();
        return new JsonResult(addressesOutputs);
    }

    [HttpDelete("DeleteAddress/{id}")]
    public bool DeleteAddress(int id){
        return _service.Delete(id);
    }

    [HttpPost("AddAddress")]
    public bool AddAddress(AddressesInput addressesInput){
        return _service.Add(addressesInput);
    }
}
