using AutoMapper;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Infra.Exceptions;
using WebExercicios.Services.Base;
using WebExercicios.ViewModels.Input;

namespace WebExercicios.Services;
public class RentalService : ServiceBase<Rental>
{
    private readonly ExercicioContext _context;
    public RentalService(IMapper mapper, ExercicioContext context) : base(mapper, context)
    {
        _context = context;
    }

    public bool RentalCustomerCointainsFilm(int? Customerid,int Filmid){
        return _context.Rental.Any(x => x.Customer_id == Customerid && x.Inventory.Film_id == Filmid);
    }


    public override bool Add<Input>(Input input)
    {   
        var rentalInput = input as RentalInput;
        
        var inventory =_context.Inventory.Where(x => x.Inventory_id == rentalInput.Inventory_id).FirstOrDefault();

        var quantidadeInventarioFilme =_context.Inventory.Where(x => x.Film_id == inventory.Film_id).Count();

        var quantidadeFilmesAlugados = _context.Rental.Where( x => x.Inventory.Film_id == inventory.Film_id && x.Return_date == null ).Count();

        if(!(quantidadeFilmesAlugados >= quantidadeInventarioFilme)){
            return base.Add(input);
        }else{
            throw new LocadoraFilmeException("Todos filmes com esse titulo estão alugados");
        }
    }
}
