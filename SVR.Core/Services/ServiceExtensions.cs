using Microsoft.Extensions.DependencyInjection;
using SVR.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;  

namespace SVR.Core.Services
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            var sharedAssembly = AppDomain.CurrentDomain
               .GetAssemblies()
               .SingleOrDefault(a => a.GetName().Name == "SVR.Core");

            var automapperAssemblies = new List<Assembly>();
            automapperAssemblies.Add(Assembly.GetExecutingAssembly());
            automapperAssemblies.Add(sharedAssembly);

            services.AddAutoMapper(automapperAssemblies);
            //services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient<IBillService, BillService>(); 
        }
    }
}

