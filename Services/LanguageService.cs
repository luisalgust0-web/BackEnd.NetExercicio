using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Base;

namespace WebExercicios.Services;
public class LanguageService : ServiceBase<Citys>
{
    private readonly ExercicioContext _context;
    public LanguageService(IMapper mapper, ExercicioContext context) : base(mapper, context)
    {
        _context = context;
    }


    // public override List<Citys>GetListaWithInclude()
    // {
    //     var litCITYS = base.GetListaWithInclude().Include(x =>x.Country).ToList();
    //     return litCITYS;
    // }

}
