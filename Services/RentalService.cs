using AutoMapper;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Infra.Exceptions;
using WebExercicios.Services.Base;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Services;
public class RentalService : ServiceBase<Rental>
{
    private readonly ExercicioContext _context;
    private readonly IMapper _mapper;
    public RentalService(IMapper mapper, ExercicioContext context) : base(mapper, context)
    {
        _mapper = mapper;
        _context = context;
    }

    public bool RentalCustomerCointainsFilm(int? Customerid,int Filmid){
        return _context.Rental.Any(x => x.Customer_id == Customerid && x.Inventory.Film_id == Filmid);
    }


    public RentalOutput AddRental(RentalInput input)
    {   
        
        var inventory =_context.Inventory.Where(x => x.Inventory_id == input.Inventory_id).FirstOrDefault();

        var quantidadeInventarioFilme =_context.Inventory.Where(x => x.Film_id == inventory.Film_id).Count();

        var quantidadeFilmesAlugados = _context.Rental.Where( x => x.Inventory.Film_id == inventory.Film_id && x.Return_date == null ).Count();

        if(!(quantidadeFilmesAlugados >= quantidadeInventarioFilme)){
            Rental rental = base.Add(input);
            return _mapper.Map<RentalOutput>(rental);
        }else{
            throw new LocadoraFilmeException("Todos filmes com esse titulo estão alugados");
        }
    }
}
