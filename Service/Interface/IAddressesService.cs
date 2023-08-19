using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service.Interface;
public interface IAddressesService
{
    public List<AddressesOutput> GetLista();
    public bool Add(AddressesInput addressesInput);
    public bool Delete(int id);
}
