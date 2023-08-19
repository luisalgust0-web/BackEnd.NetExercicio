using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebExercicios.Infra.Database;
using WebExercicios.Infra.Models;
using WebExercicios.Service.Interface;
using WebExercicios.ViewModels.Input;
using WebExercicios.ViewModels.Output;

namespace WebExercicios.Service;
public class AddressesService : IAddressesService
{
    private readonly IMapper _mapper;
    private readonly ExercicioContext _context;
    public string erro;
    public AddressesService(IMapper mapper, ExercicioContext context)
    {
        _mapper = mapper;
        _context = context;
    }


    public bool Add(AddressesInput addressesInput)
    {
        if (addressesInput.Address_id == 0)
        {
            try
            {
                Addresses addresses = _mapper.Map<Addresses>(addressesInput);
                _context.Address.Add(addresses);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                return false;
            }
        }
        else
        {
            try
            {
                Addresses addresses = _mapper.Map<Addresses>(addressesInput);
                _context.Address.Update(addresses);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                return false;
            }
        }
    }

    public bool Delete(int id)
    {
        try
        {
            Addresses addresses = _context.Address.Where(x => x.Address_id == id).FirstOrDefault();
            _context.Address.Remove(addresses);
            _context.SaveChanges();
            return true;
        }
        catch (Exception ex)
        {
            erro = ex.Message;
            return false;
        }
    }

    public List<AddressesOutput> GetLista()
    {
        try
        {
            List<Addresses> listAddresses = _context.Address.Include(x => x.City).AsEnumerable().ToList();
            List<AddressesOutput> addressesOutputs = _mapper.Map<List<AddressesOutput>>(listAddresses);
            return addressesOutputs;
        }
        catch (Exception ex)
        {
            erro = ex.Message;
            return null;
        }
    }
}
