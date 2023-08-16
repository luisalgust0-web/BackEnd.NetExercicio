using WebExercicios.Infra.Models;
using WebExercicios.ViewModels.Input;

namespace Namespace;
public interface ICountryService
{
    public List<Countrys> GetLista ();
    public bool Add(CountryInput countryInput);
     public bool Delete(int id);
}
