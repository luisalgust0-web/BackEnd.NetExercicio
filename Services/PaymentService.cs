using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Namespace;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Base;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Services;
public class PaymentService : ServiceBase<Payment>
{
    private ExercicioContext _context;
    public PaymentService(IMapper mapper, ExercicioContext context) : base(mapper, context)
    {
        _context = context;
    }

     public decimal GetAmount(int rental_id){
         Rental rental = _context.Rental. Where(x => x.Rental_id == rental_id).Include(x => x.Inventory.Film).FirstOrDefault();
         if(rental.Return_date != null){
            TimeSpan intervalo = (TimeSpan)(rental.Return_date - rental.Rental_date);
            double valorAmount = intervalo.TotalDays * Convert.ToDouble(rental.Inventory.Film.Rental_rate);
            return Convert.ToDecimal(valorAmount);
         }else{
            throw new Exception("filme ainda não foi devolvido");
         }
         
     }


 }
