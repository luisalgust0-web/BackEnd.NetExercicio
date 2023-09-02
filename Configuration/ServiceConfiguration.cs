using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebExercicios.Infra.Database.Models;
using WebExercicios.Services;
using WebExercicios.Services.Base;
using WebExercicios.Services.Interfaces;

namespace WebExercicios.Configuration;
public static class ServiceConfiguration
    {
        public static IServiceCollection Configurar(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IServiceBase<>),typeof(ServiceBase<>));
            
            return serviceCollection;
        }

    }
