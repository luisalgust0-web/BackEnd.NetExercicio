using Microsoft.AspNetCore.Mvc;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class PaymentController : ControllerBase
{
    private readonly PaymentService _service;

    public PaymentController(PaymentService service)
    {
        _service = service;
    }

    [HttpGet("GetAmount")]
    public decimal GetPayment(int rental_id){
        return _service.GetAmount(rental_id);
    }

    [HttpPost("AddItem")]
    public bool AddPayment(PaymentInput input){
        return _service.Add(input);
    }

    [HttpGet("GetItemByName")]
    public IActionResult GetPaymentByCustomer(string name){
        return new JsonResult(_service.GetQuery().Where(x => x.Customer.First_name.Contains(name) || x.Customer.Last_name.Contains(name)).Include(x => x.Rental.Inventory.Film).Include(x => x.Rental.Customer).MapList<PaymentOutput>());
    }
}
