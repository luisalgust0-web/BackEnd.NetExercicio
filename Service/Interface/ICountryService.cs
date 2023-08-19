using WebExercicios.Infra.Models;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service.Interface;
public interface ICountryService
{
    public List<CountryOutput> GetLista ();
    public bool Add(CountryInput countryInput);
     public bool Delete(int id);
}
