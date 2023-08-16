using Namespace;
using WebExercicios.Service;

namespace WebExercicios.Configuration;
public static class ServiceConfiguration2
    {
        public static IServiceCollection Configurar(this IServiceCollection serviceCollection)
        {
            // serviceCollection.AddScoped<IReceitaService, ReceitaService>();
            serviceCollection.AddScoped<ICountryService, CountryService>();
            return serviceCollection;
        }

    }
