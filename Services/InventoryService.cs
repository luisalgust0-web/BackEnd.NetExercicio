using AutoMapper;
using Namespace;
using WebExercicios.Infra.Database;
using WebExercicios.Services.Base;

namespace WebExercicios.Controller;
public class InventoryService : ServiceBase<Inventory>
{
    private readonly ExercicioContext _context;

    public InventoryService(IMapper mapper, ExercicioContext context) : base(mapper, context)
    {
        _context = context;
    }

    public bool ContainsInvetory(int id){
        if(_context.Inventory.Any(x => x.Film_id == id)){
            return true;
        }else
        return false;
    }
}
