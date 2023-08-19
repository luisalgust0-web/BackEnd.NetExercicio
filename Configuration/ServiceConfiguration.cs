
using WebExercicios.Service;
using WebExercicios.Service.Interface;

namespace WebExercicios.Configuration;
public static class ServiceConfiguration2
    {
        public static IServiceCollection Configurar(this IServiceCollection serviceCollection)
        {
            // serviceCollection.AddScoped<IReceitaService, ReceitaService>();
            serviceCollection.AddScoped<ILanguageService, LanguageService>();
            serviceCollection.AddScoped<ICityService, CityService>();
            serviceCollection.AddScoped<ICountryService, CountryService>();
            serviceCollection.AddScoped<IAddressesService, AddressesService>();
            return serviceCollection;
        }

    }
