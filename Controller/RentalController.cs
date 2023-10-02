using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Renci.SshNet.Messages;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Infra.Exceptions;
using WebExercicios.Services;
using WebExercicios.Services.Base;
using WebExercicios.Services.Interfaces;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Controller;
[ApiController]
[Route("[controller]")]
public class RentalController : ControllerBase
{
    private readonly RentalService _service;

    public RentalController(RentalService service)
    {
        _service = service;
    }

   [HttpGet("GetLista")]
   public IActionResult GetRentals([FromQuery]int customerId, [FromQuery]int? filmId, [FromQuery]DateTime? dataInicio, [FromQuery]DateTime? dataFinal){
        
        IConsultaBase<Rental> query = _service.GetQuery();
        
        query = query.Where(x => x.Customer_id == customerId);
          

        if(filmId.HasValue){
            if(_service.RentalCustomerCointainsFilm(customerId, (int)filmId)){
                query = query.Where(x => x.Inventory.Film.Film_id == filmId);
            }else{
                throw new LocadoraFilmeException("Cliente não tem aluguel com este titulo");
            }
        }

        if(dataInicio.HasValue){
            query = query.Where(x => x.Rental_date > dataInicio);
        }

        if(dataFinal.HasValue){
            query = query.Where(x => x.Return_date <= dataFinal);
        }


    return new JsonResult(query.Include(x => x.Customer).Include(x => x.Inventory.Film).MapList<RentalOutput>());
   }

    [HttpGet("GetItem/{id}")]
    public IActionResult GetRentalById(int id){
        return new JsonResult(_service.GetQuery().Where(x => x.Rental_id == id).Include(X => X.Customer).Include(X => X.Inventory.Film).MapItem<RentalOutput>());
    }
    
    [HttpPost("AddItem")]
    public IActionResult AddRental(RentalInput input){
        RentalOutput rentalOutput = _service.AddRental(input);
        return new JsonResult(rentalOutput);
    }

    [HttpPost("UpdateItem")]
    public bool UpdateRental(RentalInput input){
        return _service.Update(input);
    }
    
}
