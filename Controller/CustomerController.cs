using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _service;
    public CustomerController(CustomerService service)
    {
        _service = service;
    }

    [HttpGet("GetLista")]
    public IActionResult GetCustomers()
    {
        return new JsonResult(_service.GetQuery().Include(x => x.Address.City).MapList<CustomerOutput>());
    }

    [HttpGet("GetItemById/{id}")]
    public IActionResult GetListaById(int id)
    {
        return new JsonResult(_service.GetQuery().Where(x => x.Customer_id == id).Include(x => x.Address.City).MapItem<CustomerOutput>());
    }

    [HttpGet("GetCustomerByName")]
    public IActionResult GetCustomerByName(string name)
    {
        return new JsonResult(_service.GetQuery().Where(x => x.First_name.Contains(name) || x.Last_name.Contains(name)).Include(x => x.Address.City).MapList<CustomerOutput>());
    }

    [HttpPost("AddItem")]
    public bool AddCustomer(CustomerInput input)
    {
        // this.Response.StatusCode = 201;
        // return Ok();
        return _service.Add(input);
    }

    [HttpPost("UpdateItem")]
    public bool UpdateCustomer(CustomerInput input)
    {
        return _service.Update(input);
    }

    [HttpDelete("RemoveItem/{id}")]
    public bool DeleteCustomer(int id)
    {
        return _service.Remove(id);
    }
}
