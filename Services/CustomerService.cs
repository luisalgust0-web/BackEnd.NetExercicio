using AutoMapper;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Infra.Exceptions;
using WebExercicios.Services.Base;
using WebExercicios.ViewModels.Input;

namespace WebExercicios.Services;
public class CustomerService : ServiceBase<Customer>
{
    private readonly ExercicioContext _context;
    public CustomerService(IMapper mapper, ExercicioContext context) : base(mapper, context)
    {
        _context = context;
    }

    public override bool Add<Input>(Input input)
    {
        CustomerInput customer = input as CustomerInput;
        if (!_context.Customer.Any(x => x.First_name == customer.First_name && x.Last_name == customer.Last_name))
        {
            return base.Add(input);
        }
        else
        {
            throw new LocadoraFilmeException("Customer alredy existing");
        }
    }
}
