using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service.Interface;
public interface ICityService
{
    public List<CityOutput> GetAll();
    public bool Add(CityInput cityInput);
    public bool Delete(int Id);
}
