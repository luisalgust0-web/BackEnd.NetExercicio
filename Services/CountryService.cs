using AutoMapper;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services.Base;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Services;
public class CitysService : ServiceBase<Citys>
{
    public CitysService(IMapper mapper, ExercicioContext context) : base(mapper, context)
    {
    }
}
