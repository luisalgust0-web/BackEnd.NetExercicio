using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebExercicios.Controller;
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
            serviceCollection.AddScoped<CustomerService, CustomerService>();
            serviceCollection.AddScoped<RentalService, RentalService>();
            serviceCollection.AddScoped<InventoryService , InventoryService>();
                
            return serviceCollection;
        }

    }
